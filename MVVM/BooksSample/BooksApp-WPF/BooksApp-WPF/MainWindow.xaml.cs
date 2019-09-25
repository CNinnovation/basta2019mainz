using BooksLib.ViewModels;
using GenericViewModels.MVVM;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BooksApp_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IServiceScope _scope;
        public MainWindow()
        {
            InitializeComponent();
            _scope = ServiceLocator.Instance.CreateScope();
            Closed += (sender, e) => _scope.Dispose();

            ViewModel = _scope.ServiceProvider.GetRequiredService<BooksViewModel>();

            DataContext = this;

        }

        public BooksViewModel ViewModel { get; }
    }
}
