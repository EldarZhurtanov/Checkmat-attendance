using BL.Converters;
using DL.DataProviders;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace BL
{
    public class Training
    {
        private TestDataProvider _dataProvider = new TestDataProvider();
        private ObservableCollection<User> _users;

        internal Training(int groupId, User trainer, DateTime trainingDate, string trainingType)
        {
            GroupId = groupId;
            Trainer = trainer;
            TrainingDate = trainingDate;
            TrainingType = trainingType;
        }

        public int GroupId { get; }
        public User Trainer { get; }
        public string TrainingType { get; }
        public DateTime TrainingDate { get; }

        public ObservableCollection<User> Users {
            get
            {
                if (_users == null)
                    _users = new ObservableCollection<User>((from UserResponces
                            in _dataProvider.GetUsersInGroup(GroupId)
                            select UserResponces.ToUser()).ToList());
                return _users;
            }
        }

        public void TagUser(User user, Presence presence)
        {
            if (user.Presence != presence)
            {
                _dataProvider.MarkUser(user.Id, Convert.ToBoolean((int)presence));

                Users.Remove(user);
                user.Presence = presence;
                Users.Add(user);
            }
        }
        public void SignUpForATrialTraining(TrialUser trialUser)
        {
            _dataProvider.CreateTrialTraining(trialUser.ToResponce());
        }
    }
}
