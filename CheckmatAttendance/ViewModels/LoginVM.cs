using BL;
using CheckmatAttendance.ViewModels.Helpers;
using CheckmatAttendance.Views;
using DevExpress.Mvvm;
using Egor92.UINavigation.Wpf;
using System;
using System.Linq;

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
                    {
                        Error = "Ошибка";
                        return;
                    }

                    var hpeargs = new HarvestPasswordEventArgs();
                    HarvestPassword(this, hpeargs);

                    var trainings = AuthorizationService.Authorization(Login, hpeargs.Password);

                    if (trainings == null)
                        Error ="У вас нет занятий";
                    else
                    {
                        string trainingChoiceKey = NavigationHelper.GetKey(PageType.TrainingChoice, KeyType.New);

                        _navigationManager.Register<TrainingChioce>(trainingChoiceKey, () => new TrainingChoiceVM(navigationManager, trainings.ToList()));
                        _navigationManager.Navigate(trainingChoiceKey);
                    }
                }
                catch (Exception ex)
                {
                    Error = ex.Message;
                }
            });
        }

        public string Login { get;
            set; }
        public string Error { get; set; }
        public DelegateCommand LoginCommand { get; }


        public event EventHandler<HarvestPasswordEventArgs> HarvestPassword;
        public class HarvestPasswordEventArgs
        {
            public string Password;
        }
    }
}
