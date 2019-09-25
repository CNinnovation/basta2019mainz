using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using BooksApp_Avalonia2.Services;
using BooksLib.ViewModels;
using GenericViewModels.MVVM;
using Microsoft.Extensions.DependencyInjection;

namespace BooksApp_Avalonia2
{
    public class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private IServiceScope _scope;

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);

            _scope = ServiceLocator.Instance.CreateScope();
            Closed += (sender, e) => _scope.Dispose();

            ViewModel = _scope.ServiceProvider.GetRequiredService<BooksViewModel>();
            var winService = _scope.ServiceProvider.GetRequiredService<IAvaloniaWindowService>();
            winService.Window = this;

            DataContext = this;
        }


        public BooksViewModel ViewModel { get; private set; }
    }
}
