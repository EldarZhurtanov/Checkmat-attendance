using BL;
using DevExpress.Mvvm;

namespace CheckmatAttendance.ViewModels
{
    public class CreateTrialTrainingVM : ViewModelBase
    {
        private Training _training;

        public string FirstName { get; set; }
        public string MidleName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public DelegateCommand CreateTrialTraining;

        public CreateTrialTrainingVM(Training training)
        {
            _training = training;

            CreateTrialTraining = new DelegateCommand(() =>_training.SignUpForATrialTraining(new TrialUser
            {
                firstName = FirstName,
                midleName = MidleName,
                lastName = LastName,
                phoneNumber = PhoneNumber,
                email = Email
            }), () => FirstName != null && MidleName != null && PhoneNumber != null);
        }
    }
}