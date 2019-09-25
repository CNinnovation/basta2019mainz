using BooksLib.ViewModels;
using GenericViewModels.MVVM;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace BooksAppUno
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private IServiceScope _scope;

        public MainPage()
        {
            InitializeComponent();

            _scope = ServiceLocator.Instance.CreateScope();

            Unloaded += (sender, e) => _scope.Dispose();

            // BookDetailUC.ViewModel = _scope.ServiceProvider.GetRequiredService<BookDetailViewModel>();
            ViewModel = _scope.ServiceProvider.GetRequiredService<BooksViewModel>();
            this.DataContext = this;
        }

        public BooksViewModel ViewModel { get; }
    }
}
