using Egor92.UINavigation.Wpf;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace CheckmatAttendance
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var window = new MainWindow();
            var navigationManager = new NavigationManager(window);

            /*
            navigationManager.Register<FirstView>("FirstKey", () => new FirstViewModel(navigationManager));
            navigationManager.Register<SecondView>("SecondKey", () => new SecondViewModel(navigationManager));
            */

            navigationManager.Navigate("FirstKey");
            window.Show();
        }
    }
}
