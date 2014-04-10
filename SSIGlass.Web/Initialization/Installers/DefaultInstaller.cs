namespace SSIGlass.Web.Initialization.Installers
{
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;
    using Core.Logging;

    public class DefaultInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                //log
                Component.For<ILoggerManager>().ImplementedBy<LoggerManager>().LifeStyle.Singleton
            );
        }
    }
}