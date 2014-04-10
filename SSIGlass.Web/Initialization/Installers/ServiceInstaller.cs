namespace SSIGlass.Web.Initialization.Installers
{
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;
    using Core.Services;
    using Contract.Services;

    public class ServiceInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                AllTypes.FromAssemblyContaining(typeof(ApplicationService<,>))
                    .BasedOn(typeof(IApplicationService)).WithService.FromInterface()
                    .Configure(c => c.Named(c.Implementation.FullName).LifeStyle.PerWebRequest)
                );
        }
    }
}