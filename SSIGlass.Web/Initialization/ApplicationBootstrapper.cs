using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSIGlass.Web.Initialization
{    
    using Castle.Facilities.TypedFactory;
    using Castle.MicroKernel.Registration;
    using Castle.Windsor;
    using Castle.Windsor.Installer;
    using CommonServiceLocator.WindsorAdapter;
    using Microsoft.Practices.ServiceLocation;

    public class ApplicationBootstrapper : IDisposable
    {
        public IWindsorContainer Container { get; private set; }

        public void Run()
        {
            Container = new WindsorContainer();
            Container.AddFacility<TypedFactoryFacility>();            
            Container.Install(Configuration.FromXmlFile("Config/Windsor.config"));
            Container.Install(FromAssembly.This());

            Container.Register(Component.For<IServiceLocator>().Instance(new WindsorServiceLocator(Container)));

            ServiceLocator.SetLocatorProvider(Container.Resolve<IServiceLocator>);
        }

        public void Dispose()
        {
            if (Container != null) Container.Dispose();
        }
    }
}