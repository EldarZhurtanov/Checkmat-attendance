using BL;
using DevExpress.Mvvm;
using Egor92.UINavigation.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckmatAttendance.ViewModels.Helpers;
using CheckmatAttendance.Views;

namespace CheckmatAttendance.ViewModels
{
    class UserMarkerVM : ViewModelBase
    {
        private readonly NavigationManager _navigationService;
        private string _searchString;
        private Training _training;
        private ObservableCollection<User> _users => _training.Users;

        public string TrainigDate { get => _training.TrainingDate.ToShortDateString(); }
        public string TrainigType { get => _training.TrainingType; }
        public ObservableCollection<User> Users { get => _searchString == null? _users : _users.SearchByString(_searchString); }
        public User SelectedUser { get; set; }
        public string SearchString
        {
            get => _searchString;
            set
            {
                _searchString = value;
                RaisePropertiesChanged("SearchString", "Users");
            }
        }
        public int PresentUserCount { get => _users.ToList().FindAll((user) => user.Presence == Presence.present).Count; }
        public int UserCount { get => _users.Count; }

        public DelegateCommand Search { get; }
        public DelegateCommand MarkUser { get; }
        public DelegateCommand CheckAttendance { get; }
        public DelegateCommand LogOut { get; }

        public CreateTrialTrainingVM TrialTrainingDataContext { get; }

        public UserMarkerVM(NavigationManager navigationService, Training training)
        {
            _navigationService = navigationService;
            _training = training;

            Search = new DelegateCommand(() => SearchString = _searchString, () => _searchString != null && _searchString != string.Empty);

            MarkUser = new DelegateCommand(() => 
            {
                _training.TagUser(SelectedUser, Presence.present);

                RaisePropertiesChanged("Users");
            }
            ,() => SelectedUser != null);

            CheckAttendance = new DelegateCommand(() =>
                {
                    _navigationService.Register<AttendaceChecker>("AttendaceChecker", () => new AttendaceCheckerVM(_navigationService, _training));
                    _navigationService.Navigate("AttendaceChecker");
                });

            LogOut = new DelegateCommand(() => _navigationService.Navigate("Login"));
        }
    }
}
