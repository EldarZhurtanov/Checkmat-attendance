using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Egor92.UINavigation.Wpf;
using BL;

namespace CheckmatAttendance.ViewModels
{
    class TrainingChoiceVM : ViewModelBase
    {
        private readonly NavigationManager _navigationService;

        public TrainingChoiceVM(NavigationManager navigationService, List<Training> trainings)
        {
            this._navigationService = navigationService;
        }
    }
}
