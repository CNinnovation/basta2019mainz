using Avalonia.Controls;
using GenericViewModels.Services;
using MessageBox.Avalonia;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BooksApp_Avalonia2.Services
{
    public class AvaloniaDialogService : IDialogService
    {
        private readonly Window _window;
        public AvaloniaDialogService(IAvaloniaWindowService avaloniaWindowService)
        {
            _window = avaloniaWindowService.Window;
        }
        public Task ShowAsync(string title, Exception ex, string ok = "Ok")
        {
            return ShowAsync(title, ex.Message, ok);
        }

        public async Task<bool> ShowAsync(string title, string content, string ok = "Ok", string cancel = null)
        {
            var window = new MessageBoxWindow(title, content);
            string result = await window.ShowDialog(_window);
            return true;
        }
    }
}
