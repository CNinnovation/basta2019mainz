using BooksLib.Models;
using GenericViewModels.Services;
using Microsoft.Extensions.Logging;

namespace BooksApp_Xamarin.Services
{
    public class CommonBookServices : ICommonServices<Book>
    {
        public CommonBookServices(
            IDialogService dialogService,
            ILoggerFactory loggerFactory,
            IMessageService messageService,
            ISharedItems<Book> sharedItemsService)
        {
            DialogService = dialogService;
            LoggerFactory = loggerFactory;
            MessageService = messageService;
            SharedItems = sharedItemsService;
        }

        public IDialogService DialogService { get; }

        public ILoggerFactory LoggerFactory { get; }

        public IMessageService MessageService { get; }

        public ISharedItems<Book> SharedItems { get; }
    }
}
