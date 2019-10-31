using BL;
using DevExpress.Mvvm;
using Egor92.UINavigation.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckmatAttendance.ViewModels
{
    class UserMarkerVM : ViewModelBase
    {
        private readonly NavigationManager _navigationService;
        private Training _training;

        public UserMarkerVM(NavigationManager navigationService, Training training)
        {
            _navigationService = navigationService;
            _training = training;
        }
    }
}
