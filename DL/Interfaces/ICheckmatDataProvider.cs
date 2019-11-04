using System.Collections.Generic;

namespace DL
{
    public abstract class ICheckmatDataProvider
    {
        public abstract UserResponce Auth(string login, string password);
        public abstract List<UserResponce> GetUsersInGroup(int groupID);

        public abstract UserResponce GetUser(int userID);
        public abstract List<TrainingResponce> GetTrainings(int trainerID);
        public abstract void MarkUser(int userID, bool presence);
        public abstract void CreateTrialTraining(TrialUserResponce user);
    }
}
