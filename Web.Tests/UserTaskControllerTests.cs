using LessonWebProject.BusinessLogic.Models;
using LessonWebProject.BusinessLogic.Services;
using LessonWebProject.Web.Controllers;
using LessonWebProject.Web.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Security.Claims;

namespace Web.Tests
{
    [TestClass]
    public class UserTaskControllerTests
    {
        private readonly UserTaskController _userTaskController;
        private readonly Mock<ServicesManager> _servicesManager = new Mock<ServicesManager>();

        public UserTaskControllerTests()
        {
            _userTaskController = new UserTaskController(_servicesManager.Object);
        }
        //public IActionResult ShowTasks(int? taskID = null)
        //{
        //    string userID = User.FindFirstValue(ClaimTypes.NameIdentifier);


        //    ShowTasksViewModel showTasksModel = new ShowTasksViewModel();
        //    showTasksModel.Tasks = _servicesManager._userTaskService.GetAllUserTasks(userID).toContract().ToList();
        //    showTasksModel.Ads = taskID != null ? _servicesManager._adsService.GetAdsByTaskID((int)taskID).toContract().ToList() : null;
        //    return View(showTasksModel);
        //}
        [TestMethod]
        public void ShowTasks_ShouldShowTasksAndAds()
        {
            //Arrange
            IEnumerable<UserTaskModel> UserTasks = GetUserTasks();

            _servicesManager.Setup(t => t._userTaskService.GetAllUserTasks(It.IsAny<string>())).Returns(UserTasks);

            //Act
            var result = _userTaskController.ShowTasks();
            //var result2 = _userTaskController.ShowTasks(15);

            //Assert
            Assert.IsInstanceOfType(result, typeof(ShowTasksViewModel));
            Assert.AreEqual(((ShowTasksViewModel)result).Tasks, UserTasks);
            Assert.AreEqual(((ShowTasksViewModel)result).Ads, null);
        }

        private IEnumerable<UserTaskModel> GetUserTasks()
        {
            return new List<UserTaskModel>()
            {
                new UserTaskModel() {
                    ID = 1,
                    UserID = string.Empty
                },
                new UserTaskModel() {
                    ID = 2,
                    UserID = string.Empty
                }
            };
        }
    }
}
