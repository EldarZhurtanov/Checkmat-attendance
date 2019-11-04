using BL;
using CheckmatAttendance.ViewModels.Helpers;
using DevExpress.Mvvm;
using Egor92.UINavigation.Wpf;
using System.Collections.ObjectModel;
using System.Linq;

namespace CheckmatAttendance.ViewModels
{
    public class AttendaceCheckerVM : ViewModelBase
    {
        private NavigationManager _navigationManager;
        private Training _training;
        private ObservableCollection<User> _users => _training.Users;
        private User _selectedPresentUser;
        private User _selectedAbsentUser;

        public string TrainigDate { get => _training.TrainingDate.ToShortDateString(); }
        public string TrainigType { get => _training.TrainingType; }

        public User SelectedPresentUser { get => _selectedPresentUser; set
            {
                _selectedPresentUser = value;

                _selectedAbsentUser = null;
                RaisePropertiesChanged("SelectedPresentUser", "SelectedAbsentUser");
            }
        }
        public User SelectedAbsentUser { get => _selectedAbsentUser; set
            {
                _selectedAbsentUser = value;

                _selectedPresentUser = null;
                RaisePropertiesChanged("SelectedPresentUser", "SelectedAbsentUser");
            }
        }

        public ObservableCollection<User> PresentUsers
        {
            get
            {
                return new ObservableCollection<User>(from u
                                                      in _users
                                                      where u.Presence == Presence.present
                                                      select u);
            }
        }
        public ObservableCollection<User> AbsentUsers
        {
            get
            {
                return new ObservableCollection<User>(from u
                                                      in _users
                                                      where u.Presence == Presence.absent
                                                      select u);
            }
        }

        public DelegateCommand ComeBack { get; }
        public DelegateCommand FromPresentToAbsent { get; }
        public DelegateCommand FromAbsentToPresent { get; }

        public AttendaceCheckerVM(NavigationManager navigationService, Training training)
        {
            _navigationManager = navigationService;
            _training = training;

            FromPresentToAbsent = new DelegateCommand(() => 
            {
                _training.TagUser(SelectedPresentUser, Presence.absent);
                SelectedPresentUser = null;

                RaisePropertiesChanged("PresentUsers", "AbsentUsers");

            }, () => SelectedPresentUser != null);

            FromAbsentToPresent = new DelegateCommand(() =>
            {
                _training.TagUser(SelectedAbsentUser, Presence.present);
                SelectedAbsentUser = null;

                RaisePropertiesChanged("PresentUsers", "AbsentUsers");

            }, () => SelectedAbsentUser != null);

            ComeBack = new DelegateCommand(() =>  _navigationManager.Navigate(NavigationHelper.GetKey(PageType.UserMaker, KeyType.Last)));
        }
    }
}