using System.Reflection;
using System.Web.Mvc;

namespace SSIGlass.Web.Initialization.Installers
{
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;
    using MvcContrib.Castle;

    public class ControllersInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IActionInvoker>().ImplementedBy<WindsorActionInvoker>());

            container.Register(
                AllTypes.FromAssembly(Assembly.GetExecutingAssembly())
                    .BasedOn<IController>()
                    .Configure(c => c.Named(c.Implementation.FullName).OnCreate((k, instance) => ((Controller)instance).ActionInvoker = k.Resolve<IActionInvoker>()).LifeStyle.Transient)
                    );

            ControllerBuilder.Current.SetControllerFactory(new WindsorControllerFactory(container));
        }
    }
}