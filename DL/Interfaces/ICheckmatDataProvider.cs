using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public abstract class ICheckmatDataProvider
    {
        public abstract List<UserResponce> GetUsersInGroup(string groupID);
        public abstract UserResponce GetUser(string groupID);

        public abstract List<TrainingResponce> GetTraining(string trainigID);
        public abstract void MarkUser(string user, Presence presence);
    }
}
