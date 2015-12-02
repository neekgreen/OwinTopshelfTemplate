namespace SelfHost
{
    using System;
    using System.Linq;
    using SelfHost.DependencyResolution;
    using Serilog;
    using StructureMap;
    using Topshelf;

    class Program
    {
        public static StructureMapDependencyResolver ParentScope { get; set; }

        static void Main(string[] args)
        {
            ConfigureGlobalLogger();

            IContainer container = IoC.Initialize();
            ParentScope = new SelfHost.DependencyResolution.StructureMapDependencyResolver(container);

            HostFactory.Run(x =>
            {
                x.Service<LocalService>(s =>
                {
                    s.BeforeStartingService(sc => sc.RequestAdditionalTime(TimeSpan.FromSeconds(30)));
                    s.BeforeStoppingService(sc => sc.RequestAdditionalTime(TimeSpan.FromSeconds(30)));

                    s.ConstructUsing(() =>
                    {
                        return ParentScope.GetInstance<LocalService>();
                    });

                    s.WhenStarted(service => { service.Start(); });

                    s.WhenStopped(service =>
                    {
                        service.Stop();

                        if (ParentScope != null)
                        {
                            ParentScope.Dispose();
                        }
                    });

                    s.WhenShutdown(service =>
                    {
                        service.Stop();

                        if (ParentScope != null)
                        {
                            ParentScope.Dispose();
                        }
                    });
                });

                x.EnableShutdown();
                x.RunAsLocalSystem();
                x.StartAutomatically();
                x.SetServiceName("SelfHost");
                x.SetDisplayName("SelfHost");
                x.SetDescription("Do Some Stuff");
            });
        }

        private static void ConfigureGlobalLogger()
        {
            Log.Logger =
                new LoggerConfiguration()
                    .MinimumLevel.Debug()
                    .WriteTo
                    .ColoredConsole()
                    .CreateLogger()
                    .ForContext("ApplicationName", "SelfHost");
        }
    }
}