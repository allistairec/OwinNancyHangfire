using Topshelf;

namespace OwinSelfHostNancyFx
{
    class Program
    {
        static void Main(string[] args)
        {
            HostFactory.Run(x =>
            {
                x.RunAsPrompt();

                x.Service<IService>(s =>
                {
                    s.ConstructUsing(name => new Service());
                    s.WhenStarted(tc => tc.Start());
                    s.WhenStopped(tc => tc.Stop());
                });

                //x.RunAsLocalSystem();
                x.RunAsPrompt();

                //x.SetDescription(appSettings.Service.Description);
                //x.SetDisplayName(appSettings.Service.DisplayName);
                //x.SetServiceName(appSettings.Service.Name);
            });
        }
    }
}
