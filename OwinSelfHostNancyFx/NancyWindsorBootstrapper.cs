using Castle.Windsor;
using Nancy.Bootstrappers.Windsor;

namespace OwinSelfHostNancyFx
{
    public class NancyWindsorBootstrapper : WindsorNancyBootstrapper
    {
        private IWindsorContainer _container;

        public NancyWindsorBootstrapper(IWindsorContainer container)
        {
            _container = container;
        }

        protected override IWindsorContainer GetApplicationContainer()
        {
            return _container;
        }
    }
}