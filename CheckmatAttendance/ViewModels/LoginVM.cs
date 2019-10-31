using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Mvvm;
using Egor92.UINavigation.Abstractions;
using BL;
using Egor92.UINavigation.Wpf;
using CheckmatAttendance.Views;

namespace CheckmatAttendance.ViewModels
{
    class LoginVM : ViewModelBase
    {
        private readonly NavigationManager _navigationManager;

        public LoginVM(NavigationManager navigationManager)
        {
            _navigationManager = navigationManager;


            LoginCommand = new DelegateCommand(() =>
            {
                try
                {
                    if (HarvestPassword == null)
                        Error = "Ошибка";

                    var hpeargs = new HarvestPasswordEventArgs();
                    HarvestPassword(this, hpeargs);

                    var trainings = AuthorizationService.Authorization(Login, hpeargs.Password);

                    if (trainings == null)
                        Error ="У вас нет занятий";
                    else
                    {
                        _navigationManager.Register<TrainingChioce>("TrainingChoice", () => new TrainingChoiceVM(navigationManager, trainings.ToList()));
                        _navigationManager.Navigate("TrainingChoice");
                    }
                }
                catch (Exception ex)
                {
                    Error = ex.Message;
                }
            });
        }

        public string Login { get; set; }
        public string Error { get; set; }
        public DelegateCommand LoginCommand { get; }


        public event EventHandler<HarvestPasswordEventArgs> HarvestPassword;
        public class HarvestPasswordEventArgs
        {
            public string Password;
        }
    }
}
