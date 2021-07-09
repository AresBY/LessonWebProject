using LessonWebProject.BusinessLogic.Extensions;
using LessonWebProject.BusinessLogic.Models;
using LessonWebProject.BusinessLogic.Services;
using LessonWebProject.Common.Enums;
using LessonWebProject.Data.Interfaces.Repository;
using LessonWebProject.Data.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace LessonWebProject.BusinessLogic.Moq
{
    class UserTaskServiceTests
    {
        private readonly UserTaskService _userTaskService;
        private readonly Mock<IUserTaskRepository> _userTaskRepoMock = new Mock<IUserTaskRepository>();

        public UserTaskServiceTests()
        {
            _userTaskService = new UserTaskService(_userTaskRepoMock.Object);
        }
        public void CreateTask()
        {
            //Arrange
            _userTaskRepoMock.Setup(t => t.SaveUserTask(It.IsAny<UserTaskDBModel>()));
            //Act
            _userTaskService.CreateTask(new UserTaskModel());
            //Assert
            _userTaskRepoMock.Verify(x => x.SaveUserTask(It.IsAny<UserTaskDBModel>()), Times.Once());
        }
        public void RemoveTasksByID()
        {
            //Arrange
            string taskID = "3";
            _userTaskRepoMock.Setup(t => t.RemoveUserTasksByID(taskID, It.IsAny<int[]>()));
            //Act
            _userTaskService.RemoveTasksByID(taskID, It.IsAny<int[]>());
            //Assert
            _userTaskRepoMock.Verify(x => x.RemoveUserTasksByID(taskID, It.IsAny<int[]>()), Times.Once());
        }
        public void GetAllUserTasks()
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
            Assert.Equal(expected.Count(), actual.Count());
        }
        public void GetCountTasks()
        {
            //Arrange
            string userID = "3";
            _userTaskRepoMock.Setup(t => t.GetCountTasksByUserID(userID));
            //Act
            _userTaskService.GetCountTasks(userID);
            //Assert
            _userTaskRepoMock.Verify(x => x.GetCountTasksByUserID(userID), Times.Once());
        }
        public void GetTaskById()
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
