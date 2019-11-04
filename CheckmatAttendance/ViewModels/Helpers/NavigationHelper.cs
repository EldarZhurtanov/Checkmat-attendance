using System;
using System.Collections.Generic;
using System.Linq;

namespace CheckmatAttendance.ViewModels.Helpers
{
    public enum PageType
    {
        Login = 0,
        AttendanceCheker = 1,
        TrainingChoice = 2,
        UserMaker = 3
    }
    public enum KeyType
    {
        Last = 0,
        New = 1
    }
    public static class NavigationHelper
    {
        private static List<string> _loginKeys = new List<string>();
        private static List<string> _attendanceCheckerKeys = new List<string>();
        private static List<string> _trainingChoiceKeys = new List<string>();
        private static List<string> _UserMakerKeys = new List<string>();

        public static string GetKey(PageType pageType, KeyType keyType)
        {
            if(keyType == KeyType.New)
            {
                string newKey = Guid.NewGuid().ToString();

                switch (pageType)
                {
                    case PageType.Login:
                        _loginKeys.Add(newKey);
                        break;
                    case PageType.AttendanceCheker:
                        _attendanceCheckerKeys.Add(newKey);
                        break;
                    case PageType.TrainingChoice:
                        _trainingChoiceKeys.Add(newKey);
                        break;
                    case PageType.UserMaker:
                        _UserMakerKeys.Add(newKey);
                        break;
                }
                return newKey;
            }
            else
            {
                switch (pageType)
                {
                    case PageType.Login:
                        return _loginKeys.LastOrDefault();
                    case PageType.AttendanceCheker:
                        return _attendanceCheckerKeys.LastOrDefault();
                    case PageType.TrainingChoice:
                        return _trainingChoiceKeys.LastOrDefault();
                    case PageType.UserMaker:
                        return _UserMakerKeys.LastOrDefault();
                }
                return null;
            }
        }
    }
}
