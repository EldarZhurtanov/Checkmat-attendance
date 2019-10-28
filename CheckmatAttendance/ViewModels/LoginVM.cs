using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Mvvm;
using Egor92.UINavigation.Abstractions;
using BL;

namespace CheckmatAttendance.ViewModels
{
    class LoginVM : ViewModelBase
    {
        private readonly INavigationManager _navigationManager;

        public LoginVM(INavigationManager navigationManager)
        {
            _navigationManager = navigationManager;
            LoginCommand = new DelegateCommand(_loginAction);
        }

        public string Login { get; set; }
        public string Password { get; set; }
        public static string Error { get; set; }
        public DelegateCommand LoginCommand;

        private Action _loginAction = new Action(() =>
        {
            try
            {
                /*авторизцая*/
            }
            catch (Exception ex)
            { 
                Error = ex.Message;
            }
        });

        public event EventHandler<HarvestPasswordEventArgs> HarvestPassword;
        public class HarvestPasswordEventArgs
        {
            public string Password;
        }
    }
}
