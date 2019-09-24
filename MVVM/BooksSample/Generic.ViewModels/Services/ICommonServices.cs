using GenericViewModels.Services;
using Microsoft.Extensions.Logging;

namespace GenericViewModels.Services
{
    public interface ICommonServices<T>
        where T : class
    {
        IDialogService DialogService { get; }
        ILoggerFactory LoggerFactory { get; }
        IMessageService MessageService { get; }
        ISharedItems<T> SharedItems { get; }
    }
}
