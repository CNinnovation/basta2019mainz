using GenericViewModels.Services;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BooksApp_Xamarin.Services
{
    public class XamarinDialogService : IDialogService
    {
        private readonly Page _page;

        public XamarinDialogService(IXamarinPageService pageService)
        {
            _page = pageService.Page;
        }

        
        public Task ShowAsync(string title, Exception ex, string ok = "Ok")
        {
            return ShowAsync(title, ex.Message, ok);
        }

        public async Task<bool> ShowAsync(string title, string content, string ok = "Ok", string cancel = null)
        {
            await _page.DisplayAlert(title, content, "Cancel");
            return true;
        }
    }
}
