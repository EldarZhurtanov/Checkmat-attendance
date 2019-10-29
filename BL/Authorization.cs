using DL;
using System;
using System.Collections.Generic;

namespace BL
{
    public static class AuthorizationService
    {
        private static ICheckmatDataProvider _dataProvider;
        public static ICollection<Training> Authorization(string login, string password)
        {
            UserResponce trainer = _dataProvider.Auth(login, password);

            if (trainer.role == "trainer" || trainer.role == "admin")
            {
                List<Training> trainings = new List<Training>();

                var trainingResponeses = _dataProvider.GetTrainings(trainer.id.ToString());

                foreach (var training in trainingResponeses)
                {
                    trainings.Add(new Training(training.groupId, new User { Id = trainer.id }, training.trainingDate));
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
