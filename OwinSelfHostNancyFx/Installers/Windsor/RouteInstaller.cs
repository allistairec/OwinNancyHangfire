using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using OwinSelfHostNancyFx.Infrastructure;

namespace OwinSelfHostNancyFx.Installers.Windsor
{
    public class RouteInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IRoute>().ImplementedBy<Routes>());
        }
    }
}