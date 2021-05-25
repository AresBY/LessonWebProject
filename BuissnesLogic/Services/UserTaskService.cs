using LessonWebProject.Common;
using LessonWebProject.BusinessLogic.Repository.Interfaces;
using LessonWebProject.Common.Models.DB;
using LessonWebProject.Common.Models.View;
using System.Collections.Generic;

namespace LessonWebProject.BusinessLogic.Services
{
    public class UserTaskService
    {
        private readonly IUserTaskRepository _userTaskRepository;

        public UserTaskService(IUserTaskRepository userTaskRepository)
        {
            _userTaskRepository = userTaskRepository;
        }

        public void CreateTask(string userID, UserTaskViewModel userTaskViewModel)
        {
            _userTaskRepository.SaveUserTask(userTaskViewModel.toDBModel(userID));
        }

        public void RemoveTasksByID(string userID, params int[] tasksID)
        {
            _userTaskRepository.RemoveUserTasksByID(userID, tasksID);
        }

        public IEnumerable<UserTaskViewModel> GetAllUserTasks(string userID)
        {
            return _userTaskRepository.GetAllUserTasksByID(userID).toContract();
        }

        public int GetCountTasks(string userID)
        {
            return _userTaskRepository.GetCountTasksByID(userID);
        }

        public UserTaskDBModel GetTaskById(int tasksID)
        {
            return _userTaskRepository.GetTaskById(tasksID);
        }
    }
}
