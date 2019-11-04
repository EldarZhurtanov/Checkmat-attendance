﻿using BL;
using CheckmatAttendance.ViewModels.Helpers;
using CheckmatAttendance.Views;
using DevExpress.Mvvm;
using Egor92.UINavigation.Wpf;
using System.Collections.ObjectModel;
using System.Linq;

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
              //  RaisePropertiesChanged("SearchString", "Users");
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

            Search = new DelegateCommand(() => SearchString = _searchString);

            MarkUser = new DelegateCommand(() => 
            {
                _training.TagUser(SelectedUser, Presence.present);

                RaisePropertiesChanged("Users");
            }
            ,() => SelectedUser != null);

            CheckAttendance = new DelegateCommand(() =>
                {
                    string attendaceCheckerKey = NavigationHelper.GetKey(PageType.AttendanceCheker, KeyType.New);

                    _navigationService.Register<AttendaceChecker>(attendaceCheckerKey, () => new AttendaceCheckerVM(_navigationService, _training));
                    _navigationService.Navigate(attendaceCheckerKey);
                });

            LogOut = new DelegateCommand(() => 
            {
                string loginKey = NavigationHelper.GetKey(PageType.Login, KeyType.New);

                _navigationService.Register<Login>(loginKey, () => new LoginVM(_navigationService));
                _navigationService.Navigate(loginKey);
            });
        }
    }
}
