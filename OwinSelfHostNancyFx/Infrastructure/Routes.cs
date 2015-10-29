namespace OwinSelfHostNancyFx.Infrastructure
{
    public class Routes : IRoute
    {
        public string HangfireIndex
        {
            get
            {
                return "/hangfire";
            }
        }
    }
}