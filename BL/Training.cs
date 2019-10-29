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

        public abstract ObservableCollection<User> Users { get => _dataProvider.GetUsersInGroup(GroupId); }
        public abstract bool TagUser(User user, Presence presence)
        {
            _dataProvider.MarkUser(user.id, Presence);

        }
        public abstract void SignUpForATrialTraining(User user); 
    }
}
