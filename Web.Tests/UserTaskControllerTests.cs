using LessonWebProject.BusinessLogic.Implementations;
using LessonWebProject.BusinessLogic.Interfaces;
using LessonWebProject.BusinessLogic.Models;
using LessonWebProject.Web.Controllers;
using LessonWebProject.Web.Extensions;
using LessonWebProject.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Web.Tests
{
    [TestClass]
    public class UserTaskControllerTests
    {
        private readonly UserTaskController _userTaskController;
        private readonly ServicesManager _servicesManager;
        private readonly Mock<IUserTaskService> _userTaskService = new Mock<IUserTaskService>();
        private readonly Mock<IAdsService> _adsService = new Mock<IAdsService>();
        private readonly Mock<IHomeService> _homeService = new Mock<IHomeService>();
        public UserTaskControllerTests()
        {
            _servicesManager = new ServicesManager(_userTaskService.Object, _adsService.Object, _homeService.Object);
          
            _userTaskController = new UserTaskController(_servicesManager);
        }
        
        [TestMethod]
        public void ShowTasks_ShouldShowTasks()
        {
            //Arrange
            ShowTasksViewModel tasksViewModel = GetTasksViewModel();

            _userTaskService.Setup(t => t.GetAllUserTasks(It.IsAny<string>())).Returns(GetUserTasks());

            //Act
            var result = _userTaskController.ShowTasks();
            //Assert
            _userTaskService.Verify(x => x.GetAllUserTasks(It.IsAny<string>()), Times.Once());
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            Assert.AreEqual((((ViewResult)result).Model as ShowTasksViewModel).Tasks.Count, tasksViewModel.Tasks.Count);
        }
        
        private ShowTasksViewModel GetTasksViewModel()
        {
            ShowTasksViewModel output = new ShowTasksViewModel();
            output.Tasks = GetUserTasks().toContract().ToList();
            return output;
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
