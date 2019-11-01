using DL;

namespace BL
{
    public class TrialUser
    {
        public string firstName;
        public string midleName;
        public string lastName;
        public string phoneNumber;
        public string email;

        public TrialUserResponce ToResponce()
        {
            return new TrialUserResponce {};
        }
    }
}