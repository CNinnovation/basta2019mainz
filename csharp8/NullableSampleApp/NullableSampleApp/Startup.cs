using Microsoft.Extensions.DependencyInjection;
using System;

namespace NullableSampleApp
{
#nullable disable

    public class Startup
    {
        public Startup()
        {
            RegisterServices();
        }

        public IServiceProvider Services { get; private set; }

        public void RegisterServices()
        {
            var services = new ServiceCollection();
            // ... register services
            services.AddDbContext<BooksContext>();
            Services = services.BuildServiceProvider();
        }
    }

#nullable restore
}
