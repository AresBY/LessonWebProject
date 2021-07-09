using LessonWebProject.BusinessLogic.Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Moq
{
    class Program
    {
        public static void Main(string[] args)
        {
            AdsServiceTests adsServiceTests = new AdsServiceTests();
            adsServiceTests.GetAdsByTaskID_ShouldReturnAds_WhenExists();

            UserTaskServiceTests userTaskServiceTests = new UserTaskServiceTests();
            userTaskServiceTests.CreateTask();
            userTaskServiceTests.RemoveTasksByID();
            userTaskServiceTests.GetAllUserTasks();
            userTaskServiceTests.GetCountTasks();
            userTaskServiceTests.GetTaskById();
            Console.ReadKey();
        }
    }
}
