using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public abstract class ITraining
    {
        public IUser Trainer { get; }
        public DateTime TrainingDate { get; }

        public abstract ICollection<IUser> GetUsers();
        public abstract bool TagUser(IUser user);
        public abstract void SignUpForATrialTraining(IUser user);

    }
}
