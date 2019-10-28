using CheckmatAttendance.ViewModels;
using CheckmatAttendance.Views;
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

            navigationManager.Register<Login>("Login", () => new LoginVM(navigationManager));

            navigationManager.Navigate("Login");
            window.Show();
        }
    }
}
