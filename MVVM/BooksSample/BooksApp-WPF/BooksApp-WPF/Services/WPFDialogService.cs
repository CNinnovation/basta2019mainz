using GenericViewModels.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BooksApp_WPF.Services
{
    public class WPFDialogService : IDialogService
    {
        public Task ShowAsync(string title, Exception ex, string ok = "Ok")
        {
            return ShowAsync(title, ex.Message, ok);
        }

        public Task<bool> ShowAsync(string title, string content, string ok = "Ok", string cancel = null)
        {
            var result = MessageBox.Show(content, title);
            return Task.FromResult(result == MessageBoxResult.OK);
        }
    }
}
