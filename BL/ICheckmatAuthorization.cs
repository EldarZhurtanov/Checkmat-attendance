using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public abstract class ICheckmatAuthorization
    {
        abstract public ICollection<ITraining> Authorization(string login, string password);
    }
}
