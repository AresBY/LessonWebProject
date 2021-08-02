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
using Web.Additions;

namespace Web.Tests
{
    [TestClass]
    public class UserTaskControllerAdditionTests
    {
        private readonly ServicesManager _servicesManager;
        private readonly UserTaskControllerAddition _userTaskControllerAddition;
        private readonly Mock<IUserTaskService> _userTaskService = new Mock<IUserTaskService>();
        private readonly Mock<IAdsService> _adsService = new Mock<IAdsService>();
        private readonly Mock<IHomeService> _homeService = new Mock<IHomeService>();
        public UserTaskControllerAdditionTests()
        {
            _servicesManager = new ServicesManager(_userTaskService.Object, _adsService.Object, _homeService.Object);
            _userTaskControllerAddition = new UserTaskControllerAddition(_servicesManager);
        }

        [TestMethod]
        public void ShowTasks_ShouldShowTasks()
        {
            //Arrange
            ShowTasksViewModel tasksViewModel = FictionGetTasksViewModel();

            _userTaskService.Setup(t => t.GetAllUserTasks(It.IsAny<string>())).Returns(FictionGetUserTasks());

            //Act
            var result = _userTaskControllerAddition.ShowTasks(null, It.IsAny<string>());

            //Assert
            _userTaskService.Verify(x => x.GetAllUserTasks(It.IsAny<string>()), Times.Once());
            Assert.IsInstanceOfType(result, typeof(ShowTasksViewModel));
            Assert.AreEqual(result.Tasks.Count, tasksViewModel.Tasks.Count);
        }

        private ShowTasksViewModel FictionGetTasksViewModel()
        {
            ShowTasksViewModel output = new ShowTasksViewModel();
            output.Tasks = FictionGetUserTasks().toContract().ToList();
            return output;
        }
        private IEnumerable<UserTaskModel> FictionGetUserTasks()
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


        [TestMethod]
        public void DeleteTasks_ShouldDeleteTasks()
        { 
            //Act
            _userTaskControllerAddition.DeleteTasks(It.IsAny<int[]>(), It.IsAny<string>());
            //Assert
            _userTaskService.Verify(x => x.RemoveTasksByID(It.IsAny<string>(), It.IsAny<int[]>()), Times.Once());
        }

        [TestMethod]
        public void GetEditTaskData_ShouldReturnEditTaskData()
        { 
            //Act
            _userTaskControllerAddition.GetEditTaskData(It.IsAny<int>(), new UserTaskViewModel(),  It.IsAny<string>());
            //Assert
            _userTaskService.Verify(x => x.RemoveTasksByID(It.IsAny<string>(), It.IsAny<int[]>()), Times.Once());
            _userTaskService.Verify(x => x.CreateTask(It.IsAny<UserTaskModel>()), Times.Once());
        }

        [TestMethod]
        public void GetNewTaskData_ShouldReturnNewTaskData()
        {
            //Act
            _userTaskControllerAddition.GetNewTaskData(new UserTaskViewModel(), It.IsAny<string>());

            //Assert
            _userTaskService.Verify(x => x.CreateTask(It.IsAny<UserTaskModel>()), Times.Once());
        }
    }
}
