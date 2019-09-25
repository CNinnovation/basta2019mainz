using GenericViewModels.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;

namespace BooksAppUno.Shared.Services
{
    public class UnoDialogService : IDialogService
    {
        public async Task ShowAsync(string title, Exception ex, string ok = "Ok")
        {
            await ShowAsync(title, ex.Message, ok);
        }

        public async Task<bool> ShowAsync(string title, string content, string ok = "Ok", string cancel = null)
        {
            var dialog = new MessageDialog(content, title);
            await dialog.ShowAsync();
            return true;
        }
    }
}
