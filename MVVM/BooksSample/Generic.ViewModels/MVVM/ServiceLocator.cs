using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;

namespace GenericViewModels.MVVM
{
    public enum HostType
    {
        Default,
        WindowsLimited
    }

    public class ServiceLocator
    {
        private static ServiceLocator? s_instance;
        private static object s_sync = new object();
        public static ServiceLocator Instance
        {
            get
            {
                lock (s_sync)
                {
                    return s_instance ?? (s_instance = new ServiceLocator());
                }
            }
        }

        private const string InitializeFirst = "Initialize the ServiceProvider first";

        private static IHost? s_host;

        public void Init(
            Action<IServiceCollection> configureServices, 
            Action<ILoggingBuilder> configureLogging,
            HostType hostType)
        {
            if (configureServices == null) throw new ArgumentNullException(nameof(configureServices));
            if (configureLogging == null) throw new ArgumentNullException(nameof(configureLogging));

            IHostBuilder builder;
            switch (hostType)
            {
                case HostType.Default:
                    builder = Host.CreateDefaultBuilder();
                    break;
                case HostType.WindowsLimited:
                    builder = WindowsHost.CreateWindowsBuilder();
                    break;
                default:
                    throw new InvalidOperationException("invalid host type");
            }

            s_host = builder.ConfigureServices((context, services) =>
                {
                    configureServices(services);
                })
                .ConfigureLogging(logging =>
                {
                    configureLogging(logging);
                }).Build();
        }

        public IServiceScope CreateScope()
            => s_host?.Services.CreateScope() ?? throw new InvalidOperationException(InitializeFirst);

        public T GetService<T>()
        {
            if (s_host == null) throw new InvalidOperationException(InitializeFirst);

            return s_host.Services.GetService<T>();
        }
    }
}
