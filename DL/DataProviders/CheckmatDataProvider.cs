using System;
using System.Collections.Generic;

namespace DL.DataProviders
{
    class CheckmatDataProvider : ICheckmatDataProvider
    {
        public override UserResponce Auth(string login, string password)
        {
            throw new NotImplementedException();
        }

        public override void CreateTrialTraining(TrialUserResponce user)
        {
            throw new NotImplementedException();
        }

        public override List<TrainingResponce> GetTrainings(int trainerID)
        {
            throw new NotImplementedException();
        }

        public override UserResponce GetUser(int userID)
        {
            throw new NotImplementedException();
        }

        public override List<UserResponce> GetUsersInGroup(int groupID)
        {
            throw new NotImplementedException();
        }

        public override void MarkUser(int userID, bool presence)
        {
            throw new NotImplementedException();
        }
    }
}