using BooksApp_Windows.Services;
using BooksLib.Models;
using BooksLib.Services;
using BooksLib.ViewModels;
using GenericViewModels.MVVM;
using GenericViewModels.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksApp_Windows
{
    public static class Startup
    {
        public static void Init()
        {
            ServiceLocator.Instance.Init(ConfigureServices, ConfigureLogging, HostType.WindowsLimited);
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IMessageService, MessageService>();
            services.AddSingleton<IDialogService, UWPDialogService>();

           // services.AddScoped<INavigationService, UWPNavigationService>();
            services.AddScoped<ICommonServices<Book>, CommonBookServices>();

            // view-models
            services.AddTransient<BooksViewModel>();
            // services.AddTransient<BookDetailViewModel>();

            // services
            services.AddTransient<IItemsService<Book>, BooksService>();
            services.AddTransient<IShowProgressInfo, ShowProgressInfo>();

            // stateful services
            services.AddScoped<IItemToViewModelMap<Book, BookItemViewModel>, BookToBookItemViewModelMap>();
            services.AddScoped<ISharedItems<Book>, SharedItems<Book>>();
            services.AddScoped<IRepository<Book, int>, BooksSampleRepository>();

            //services.AddHttpClient("cni", client =>
            //{
            //    // TODO: get base address from configuration, use the context
            //}).AddTypedClient<ICustomerClientService, CustomerClientService>();
        }

        private static void ConfigureLogging(ILoggingBuilder logging)
        {
#if DEBUG
            logging.AddDebug().SetMinimumLevel(LogLevel.Trace);
#endif
        }
    }
}
