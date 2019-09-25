using Avalonia;
using Avalonia.Markup.Xaml;

namespace BooksApp_Avalonia2
{
    public class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
