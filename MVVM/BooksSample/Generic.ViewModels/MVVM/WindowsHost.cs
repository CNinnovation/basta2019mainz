using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GenericViewModels
{
    public static class WindowsHost
    {
        public static IHostBuilder CreateWindowsBuilder()
        {
            HostBuilder hostBuilder = new HostBuilder();
            hostBuilder.UseContentRoot(Directory.GetCurrentDirectory());
            hostBuilder.ConfigureHostConfiguration(delegate (IConfigurationBuilder config)
            {
                config.AddEnvironmentVariables("DOTNET_");
            });
            hostBuilder.ConfigureAppConfiguration(delegate (HostBuilderContext hostingContext, IConfigurationBuilder config)
            {
                IHostEnvironment hostingEnvironment = hostingContext.HostingEnvironment;
                config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true).AddJsonFile("appsettings." + hostingEnvironment.EnvironmentName + ".json", optional: true, reloadOnChange: true);
                config.AddEnvironmentVariables();

            }).ConfigureLogging(delegate (HostBuilderContext hostingContext, ILoggingBuilder logging)
            {
                logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                logging.AddDebug();
              
            }).UseDefaultServiceProvider(delegate (HostBuilderContext context, ServiceProviderOptions options)
            {
                bool validateOnBuild = options.ValidateScopes = context.HostingEnvironment.IsDevelopment();
                options.ValidateOnBuild = validateOnBuild;
            });
            return hostBuilder;
        }
    }
}
