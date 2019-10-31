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

    }
    public class test :ViewModelBase
    {
        public List<User> Users
        {
            get
            {
                return new List<User>() { new User { Id = 123, Presence = DL.Presence.present, FirstName = "Ваня", MidleName = "Иванов" },
                                          new User { Id = 123, Presence = DL.Presence.present, FirstName = "Пётр", MidleName = "Пётров" } };
            }
        }
    }
}
