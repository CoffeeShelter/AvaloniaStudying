using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using AvaloniaStudying01.ViewModels;
using AvaloniaStudying01.Views;

namespace AvaloniaStudying01
{
    public partial class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                //desktop.MainWindow = new MainWindow
                //{
                //    DataContext = new MainWindowViewModel(),
                //};
                desktop.MainWindow = new SidebarMenuView
                {
                    DataContext = new SidebarMenuViewModel(),
                };
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}