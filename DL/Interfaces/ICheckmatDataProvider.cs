using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public abstract class ICheckmatDataProvider
    {
        public abstract UserResponce Auth(string login, string password);
        public abstract List<UserResponce> GetUsersInGroup(string groupID);

        public abstract UserResponce GetUser(string groupID);
        public abstract List<TrainingResponce> GetTrainings(string trainerID);
        public abstract void MarkUser(int userID, Presence presence);
        public abstract void CreateTrialTraining(TrialUserResponce user);
    }
}
