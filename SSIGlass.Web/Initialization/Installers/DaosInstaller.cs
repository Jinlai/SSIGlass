namespace SSIGlass.Web.Initialization.Installers
{
    using Core.DataAccess;
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;

    public class DaosInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                AllTypes.FromAssemblyContaining<IDao>()
                    .BasedOn<MyBatisNetDao>().WithService.FromInterface(typeof(IDao))
                    .Configure(c => c.Named(c.Implementation.FullName).LifeStyle.Singleton));
        }
    }
}