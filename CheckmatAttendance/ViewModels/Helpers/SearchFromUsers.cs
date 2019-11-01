using BL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckmatAttendance.ViewModels.Helpers
{
    public static class SearchFromUsersList
    {
        public static ObservableCollection<User> SearchByString(this ObservableCollection<User> users, string searchString)
        {
            if (users != null && users.Count > 0 && searchString != null)
                return new ObservableCollection<User>((from u
                                                       in users
                                                       where u.IsMatch(searchString)
                                                       select u).ToList());
            return null;
        }

        private static bool IsMatch(this User user, string searchString)
        {
            return user.CardNumber.Contains(searchString)
                || user.FirstName.Contains(searchString)
                || user.MidleName.Contains(searchString);
        }
    }
}
