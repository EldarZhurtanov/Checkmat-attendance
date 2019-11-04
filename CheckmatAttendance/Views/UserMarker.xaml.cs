using BL;
using DevExpress.Mvvm;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CheckmatAttendance.Views
{
    /// <summary>
    /// Логика взаимодействия для UserMarker.xaml
    /// </summary>
    public partial class UserMarker : UserControl
    {
        public UserMarker()
        {
            InitializeComponent();
        }

        private void OpenMenuHyperlink_Click(object sender, RoutedEventArgs e)
        {
            var animation1 = new DoubleAnimation();
            animation1.From = 0;
            animation1.To = TrialMenu.ActualWidth;
            animation1.Duration = TimeSpan.FromSeconds(0.2);
            Storyboard.SetTarget(animation1, HelpMenu);
            Storyboard.SetTargetProperty(animation1, new PropertyPath(WidthProperty));

            var storyboard = new Storyboard();
            storyboard.Children = new TimelineCollection { animation1 };

            storyboard.Begin();
        }

        private void CloseMenuHyperlink_Click(object sender, RoutedEventArgs e)
        {
            var animation1 = new DoubleAnimation();
            animation1.From = TrialMenu.ActualWidth;
            animation1.To = 0;
            animation1.Duration = TimeSpan.FromSeconds(0.2);
            Storyboard.SetTarget(animation1, HelpMenu);
            Storyboard.SetTargetProperty(animation1, new PropertyPath(WidthProperty));

            var storyboard = new Storyboard();
            storyboard.Children = new TimelineCollection { animation1 };

            storyboard.Begin();
        }
    }
}
