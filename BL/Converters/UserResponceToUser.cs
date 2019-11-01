using DL;

namespace BL.Converters
{
    public static class UserResponceToUser
    {
        public static User ToUser(this UserResponce userResponce)
        {
            return new User()
            {
                Id = userResponce.id,
                Presence = userResponce.presence == 0 ? Presence.absent : Presence.present,
                FirstName = userResponce.midleName,
                MidleName = userResponce.midleName
            };
        }

    }
}
