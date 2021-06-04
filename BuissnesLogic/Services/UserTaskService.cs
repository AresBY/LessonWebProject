using System.Collections.Generic;
using LessonWebProject.Data.Models.View;
using LessonWebProject.Data.Models.DB;
using LessonWebProject.Data.Interfaces.Repository;

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
