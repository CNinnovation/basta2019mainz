using BooksLib.ViewModels;
using GenericViewModels.MVVM;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel;
using Xamarin.Forms;

namespace BooksApp_Xamarin
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        private IServiceScope _scope;
        public MainPage()
        {
            InitializeComponent();
            _scope = ServiceLocator.Instance.CreateScope();

            ViewModel = _scope.ServiceProvider.GetRequiredService<BooksViewModel>();

            BindingContext = this;
        }

        public BooksViewModel ViewModel { get; }
    }
}
