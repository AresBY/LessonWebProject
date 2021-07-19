using LessonWebProject.BusinessLogic.Extensions;
using LessonWebProject.BusinessLogic.Models;
using LessonWebProject.BusinessLogic.Services;
using LessonWebProject.Common.Enums;
using LessonWebProject.Data.Interfaces.Repository;
using LessonWebProject.Data.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LessonWebProject.BusinessLogic.Tests
{
    [TestClass]
    public class UserTaskServiceTests
    {
        private readonly UserTaskService _userTaskService;
        private readonly Mock<IUserTaskRepository> _userTaskRepoMock = new Mock<IUserTaskRepository>();

        public UserTaskServiceTests()
        {
            _userTaskService = new UserTaskService(_userTaskRepoMock.Object);
        }
        [TestMethod]
        public void CreateTask_ShouldSendModelToRepository()
        {
            //Arrange
            _userTaskRepoMock.Setup(t => t.SaveUserTask(It.IsAny<UserTaskDBModel>()));
            //Act
            _userTaskService.CreateTask(new UserTaskModel());
            //Assert
            _userTaskRepoMock.Verify(x => x.SaveUserTask(It.IsAny<UserTaskDBModel>()), Times.Once());
        }
        [TestMethod]
        public void RemoveTasksByID_ShouldSendInformationToRemoveMethodFromRepository()
        {
            //Arrange
            string taskID = "3";
            _userTaskRepoMock.Setup(t => t.RemoveUserTasksByID(taskID, It.IsAny<int[]>()));
            //Act
            _userTaskService.RemoveTasksByID(taskID, It.IsAny<int[]>());
            //Assert
            _userTaskRepoMock.Verify(x => x.RemoveUserTasksByID(taskID, It.IsAny<int[]>()), Times.Once());
        }
        [TestMethod]
        public void GetAllUserTasks_ShouldReturnAllTaskOfUser()
        {
            //Arrange
            string taskID = "3";
            IEnumerable<UserTaskDBModel> dbo = new List<UserTaskDBModel>()
            {
                new UserTaskDBModel(){UserID = "1", CategoryType = CategoryType.Cars, Price = 1},
                new UserTaskDBModel(){UserID = "3", CategoryType = CategoryType.Birds, Price = 2},
                new UserTaskDBModel(){UserID = "3", CategoryType = CategoryType.Phones, Price = 3}
            };

            _userTaskRepoMock.Setup(x => x.GetAllUserTasksByID(taskID)).Returns(dbo.Where(t => t.UserID == taskID));

            IEnumerable<UserTaskModel> expected = new List<UserTaskModel>()
            {
                new UserTaskModel(){ UserID = "3", CategoryType = CategoryType.Birds,  Price = 2},
                new UserTaskModel(){ UserID = "3", CategoryType = CategoryType.Phones, Price = 3}
            };

            ////Act
            var actual = _userTaskService.GetAllUserTasks(taskID);

            ////Assert
            Assert.AreEqual(expected.Count(), actual.Count());
        }
        [TestMethod]
        public void GetCountTasks_ShouldReturnCountTaksOfUser()
        {
            //Arrange
            string userID = "3";
            _userTaskRepoMock.Setup(t => t.GetCountTasksByUserID(userID));
            //Act
            _userTaskService.GetCountTasks(userID);
            //Assert
            _userTaskRepoMock.Verify(x => x.GetCountTasksByUserID(userID), Times.Once());
        }
        [TestMethod]
        public void GetTaskById_ShouldReturnTaskByID()
        {
            //Arrange
            int taskID = 3;
            _userTaskRepoMock.Setup(t => t.GetTaskById(taskID)).Returns(
                new UserTaskDBModel() { ID = 1, CategoryType = CategoryType.Cars, Price = 1 });
            //Act
            _userTaskService.GetTaskById(taskID);
            //Assert
            _userTaskRepoMock.Verify(x => x.GetTaskById(taskID), Times.Once());
        }
    }
}
