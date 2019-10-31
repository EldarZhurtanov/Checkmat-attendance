using DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Converters
{
    public static class UserResponceToUser
    {
        public static User ToUser(this UserResponce userResponce)
        {
            return new User()
            {
                Id = userResponce.id,
                Presence = Presence.present
            };
        }

    }
}
