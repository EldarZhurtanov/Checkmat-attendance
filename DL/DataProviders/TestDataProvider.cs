using System;
using System.Collections.Generic;
using System.Linq;

namespace DL.DataProviders
{
    public class TestDataProvider : ICheckmatDataProvider
    {
        private readonly List<UserResponce> _users = new List<UserResponce>
        {
            new UserResponce { role = "trainer", id = 1},
            new UserResponce { role = "admin", id = 2 },
            new UserResponce { role = "client", id = 10, groupId = 1, presence = 0, lastName = "Абубакир", midleName = "Абдулов", cardNumber = "1231231231" },
            new UserResponce { role = "client", id = 11, groupId = 1, presence = 0, lastName = "Станислав ", midleName = "Медведев", cardNumber = "2231231231"  },
            new UserResponce { role = "client", id = 12, groupId = 1, presence = 1, lastName = "Роман ", midleName = "Петров", cardNumber = "3231231231"  },
            new UserResponce { role = "client", id = 13, groupId = 1, presence = 2, lastName = "Костя ", midleName = "Панов", cardNumber = "4231231231"  },
        };

        public override UserResponce Auth(string login, string password)
        {
            if (login == "123" && password == "123")
                return _users[0];

            if (login == "1234" && password == "1234")
                return _users[1];
            return null;
        }

        public override void CreateTrialTraining(TrialUserResponce user)
        {

        }

        public override List<TrainingResponce> GetTrainings(int trainerID)
        {
            if (GetUser(trainerID).role == "trainer")
                return new List<TrainingResponce>()
                {
                    new TrainingResponce {groupId = 1, trainingDate = DateTime.Now, trainingType = "Айкидо"},
                    new TrainingResponce {groupId = 2, trainingDate = DateTime.Now, trainingType = "Дзюдо"},
                    new TrainingResponce {groupId = 3, trainingDate = DateTime.Now.AddDays(-7), trainingType = "Дзюдо"}
                };
            return null;
        }

        public override UserResponce GetUser(int userId)
        {
            return (from u
                    in _users
                    where u.id == userId
                    select u).FirstOrDefault();
        }

        public override List<UserResponce> GetUsersInGroup(int groupID)
        {
            return (from u
                    in _users
                    where u.groupId == groupID
                    select u).ToList();
        }

        public override void MarkUser(int userID, bool presence)
        {
            UserResponce user = (from u
                                in _users
                                 where u.id == userID
                                 select u).FirstOrDefault();

            _users.Remove(user);

            user.presence = Convert.ToInt32(presence);
            _users.Add(user);
        }
    }
}