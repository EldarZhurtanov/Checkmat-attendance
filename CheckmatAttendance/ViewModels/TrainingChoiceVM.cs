using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Egor92.UINavigation.Wpf;
using BL;
using System.Collections.ObjectModel;
using CheckmatAttendance.Views;
using CheckmatAttendance.ViewModels.Helpers;

namespace CheckmatAttendance.ViewModels
{
    class TrainingChoiceVM : ViewModelBase
    {
        private readonly NavigationManager _navigationService;
        private List<Training> _trainings;
        private DateTime _selectedDate;

        public string SelectedTrainingType { get; set; }
        public string Error { get; set; }
        public DateTime SelectedDate
        {
            get => _selectedDate;
            set
            {
                _selectedDate = value;
                RaisePropertiesChanged("SelectedDate", "TrainingTypes");
            }
        }
        public bool SelectedDateIsValid {
            get
            {
                return (from t
                        in _trainings
                        where t.TrainingDate.Date == SelectedDate.Date
                        orderby t.TrainingDate
                        select t.TrainingType).ToList().Count > 0;
            }
        }
        public List<string> TrainingTypes
        {
            get
            {
                List<string> dates = (from t
                                     in _trainings
                                     where t.TrainingDate.Date == SelectedDate.Date
                                     orderby t.TrainingDate
                                     select t.TrainingType).ToList();
                if (dates.Count > 0)
                    return dates;
                return null;
                    
            }
        }

        public DelegateCommand ChoiceTrainingCommand { get; }

        public TrainingChoiceVM(NavigationManager navigationService, List<Training> trainings)
        {
            this._navigationService = navigationService;
            _trainings = trainings;

            SelectedDate = (from t
                           in _trainings
                           where t.TrainingDate.Date == DateTime.Now.Date
                           select t.TrainingDate).FirstOrDefault();

            ChoiceTrainingCommand = new DelegateCommand(() =>
            {
                string userMakerKey = NavigationHelper.GetKey(PageType.UserMaker, KeyType.New);

                _navigationService.Register<UserMarker>(userMakerKey, () => new UserMarkerVM(_navigationService, (from t
                                                                                                                     in _trainings
                                                                                                                 where t.TrainingDate == SelectedDate
                                                                                                                 && t.TrainingType == SelectedTrainingType
                                                                                                                 select t).FirstOrDefault()));
                _navigationService.Navigate(userMakerKey);
                

            }, () =>
            {
                if (SelectedDate != null && SelectedTrainingType != null)
                    return true;
                return false;
            });
        }

    }
}
