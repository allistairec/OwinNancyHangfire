using Nancy;

namespace OwinSelfHostNancyFx.Modules
{
    public class Index : NancyModule
    {
        public Index()
        {
            Get["/"] = _ =>
            {
                return Response.AsRedirect("/hangfire");
            };
        }
    }
}