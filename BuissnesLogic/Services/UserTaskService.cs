using System.Collections.Generic;
using LessonWebProject.Data.Interfaces.Repository;
using System;
using System.Security.Claims;
using System.Linq;
using LessonWebProject.BusinessLogic.Models;
using LessonWebProject.Data.Models;
using LessonWebProject.BusinessLogic.Extensions;


namespace LessonWebProject.BusinessLogic.Services
{
    public class UserTaskService
    {
        private readonly IUserTaskRepository _userTaskRepository;
        public UserTaskService(IUserTaskRepository userTaskRepository)
        {
            _userTaskRepository = userTaskRepository;
        }

        public void CreateTask(UserTaskModel userTaskModel)
        {
            _userTaskRepository.SaveUserTask(userTaskModel.ToDBModel());
        }

        public void RemoveTasksByID(string userID, params int[] tasksID)
        {
            _userTaskRepository.RemoveUserTasksByID(userID, tasksID);
        }

        public IEnumerable<UserTaskModel> GetAllUserTasks(string userID)
        {
            return ConvertToUserTaskModel(_userTaskRepository.GetAllUserTasksByID(userID));
        }

        private IEnumerable<UserTaskModel> ConvertToUserTaskModel(IEnumerable<UserTaskDBModel> input)
        {
            return input.Select(t => new UserTaskModel(t));
        }

        public int GetCountTasks(string userID)
        {
            return _userTaskRepository.GetCountTasksByUserID(userID);
        }

        public UserTaskModel GetTaskById(int tasksID)
        {
            return new UserTaskModel(_userTaskRepository.GetTaskById(tasksID));
        }
    }
}
