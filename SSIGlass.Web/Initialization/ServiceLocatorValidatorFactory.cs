using System;
using System.Collections.Generic;
using System.Reflection;

namespace SSIGlass.Web.Initialization
{
    using Castle.Windsor;
    using Castle.MicroKernel.Registration;
    using FluentValidation;

    public class ServiceLocatorValidatorFactory : ValidatorFactoryBase
    {
        private readonly IList<string> _validatorTypes;
        private readonly IWindsorContainer _container;

        public ServiceLocatorValidatorFactory(IWindsorContainer container)
        {
            _container = container;
            _validatorTypes = new List<string>();
            var validatorScanResults = AssemblyScanner.FindValidatorsInAssembly(Assembly.GetExecutingAssembly());
            if (validatorScanResults != null)
            {
                foreach (var t in validatorScanResults)
                {
                    //register all validator types
                    _container.Register(Component.For(t.InterfaceType).ImplementedBy(t.ValidatorType).Named(t.ValidatorType.FullName).LifeStyle.Singleton);
                    _validatorTypes.Add(t.InterfaceType.AssemblyQualifiedName);
                }
            }
        }

        public override IValidator CreateInstance(Type validatorType)
        {
            IValidator validator = null;
            if (_validatorTypes.Contains(validatorType.AssemblyQualifiedName))
                validator = _container.Resolve(validatorType) as IValidator;

            return validator;
        }
    }
}