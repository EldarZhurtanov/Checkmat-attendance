using DL;
using DL.DataProviders;
using System;
using System.Collections.Generic;

namespace BL
{
    public static class AuthorizationService
    {
        private static TestDataProvider _dataProvider = new TestDataProvider();
        public static ICollection<Training> Authorization(string login, string password)
        {
            UserResponce trainer = _dataProvider.Auth(login, password);

            if (trainer == null)
                throw new Exception("Неправильный логин или пароль");

            if (trainer.role == "trainer" || trainer.role == "admin")
            {
                List<Training> trainings = new List<Training>();

                var trainingResponeses = _dataProvider.GetTrainings(trainer.id);

                foreach (var training in trainingResponeses)
                {
                    trainings.Add(new Training(training.groupId, new User { Id = trainer.id }, training.trainingDate, training.trainingType));
                }

                return trainings;
            }
            else
            {
                throw new Exception("Вы не являетесь тренером");
            }
        }
    }
}
