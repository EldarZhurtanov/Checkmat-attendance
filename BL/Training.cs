using DL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Training
    {
        private ICheckmatDataProvider _dataProvider;

        internal Training(int groupId, User trainer, DateTime trainingDate)
        {
            GroupId = groupId;
            Trainer = trainer;
            TrainingDate = trainingDate;
        }

        public int GroupId { get; }
        public User Trainer { get; }
        public DateTime TrainingDate { get; }

        public ObservableCollection<User> Users { get; set; }
        public void TagUser(User user, Presence presence)
        {

            _dataProvider.MarkUser(user.Id, presence);

            Users.Remove(user);
            user.Presence = presence;
            Users.Add(user);
        }
        public void SignUpForATrialTraining(TrialUser trialUser)
        {
            _dataProvider.CreateTrialTraining(trialUser.ToResponce());
        }
    }
}
