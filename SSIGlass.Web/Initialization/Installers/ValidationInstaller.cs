using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SSIGlass.Web.Initialization.Installers
{
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;

    public class ValidationInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            //validation
            FluentValidation.IValidatorFactory validatorFactory = new ServiceLocatorValidatorFactory(container);

            //mvc
            ModelValidatorProviders.Providers.Add(new FluentValidation.Mvc.FluentValidationModelValidatorProvider(validatorFactory));
            DataAnnotationsModelValidatorProvider.AddImplicitRequiredAttributeForValueTypes = false;
        }
    }
}