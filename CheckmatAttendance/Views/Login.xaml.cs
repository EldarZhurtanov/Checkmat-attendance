using CheckmatAttendance.ViewModels;
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

namespace CheckmatAttendance.Views
{
    /// <summary>
    /// Логика взаимодействия для Login.xaml
    /// </summary>
    public partial class Login : UserControl
    {
        public Login()
        {
            InitializeComponent();
        }

        private bool _isСleared = false;
        private void TextBoxPassword_GotFocus(object sender, RoutedEventArgs e)
        {
            if (DataContext is LoginVM)
                (DataContext as LoginVM).HarvestPassword += (send, args) => args.Password = PasswordBox.Password;

            if (!_isСleared)
                    if (sender is PasswordBox)
                    {
                        (sender as PasswordBox).Password = string.Empty;
                        _isСleared = true;
                    }
        }
    }

}
