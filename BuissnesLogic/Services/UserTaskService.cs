using System.Collections.Generic;
using LessonWebProject.Data.Models.View;
using LessonWebProject.Data.Models.DB;
using LessonWebProject.Data.Interfaces.Repository;
using System;
using System.Security.Claims;
using LessonWebProject.BusinessLogic.Entities;
using System.Linq;

namespace LessonWebProject.BusinessLogic.Services
{
    public class UserTaskService
    {
        private readonly IUserTaskRepository _userTaskRepository;
        private readonly IAdsRepository _adsRepository;
        public UserTaskService(IUserTaskRepository userTaskRepository, IAdsRepository adsRepository)
        {
            _userTaskRepository = userTaskRepository;
            _adsRepository = adsRepository;
        }

        public void CreateTask(string userID, UserTaskViewModel userTaskViewModel)
        {
            _userTaskRepository.SaveUserTask(userTaskViewModel.toDBModel(userID));
        }

        public void RemoveTasksByID(string userID, params int[] tasksID)
        {
            _userTaskRepository.RemoveUserTasksByID(userID, tasksID);
        }

        public ShowTasksEntity GetTasksData(string userID, int? taskID = null)
        {
            IEnumerable<UserTaskViewModel> tasks = GetAllUserTasks(userID);
            IEnumerable<AdViewModel> ads = null;
            if (taskID != null)
            {
                var result = _adsRepository.GetAdsByIdTask((int)taskID);
                if (result != null && result.Count() > 0)
                {
                    ads = result.toContract();
                }
            }

            return new ShowTasksEntity(tasks.ToList(), ads != null ? ads.ToList() : null);
        }

        public IEnumerable<UserTaskViewModel> GetAllUserTasks(string userID)
        {
            return _userTaskRepository.GetAllUserTasksByID(userID).toContract();
        }

        public int GetCountTasks(string userID)
        {
            return _userTaskRepository.GetCountTasksByUserID(userID);
        }

        public UserTaskDBModel GetTaskById(int tasksID)
        {
            return _userTaskRepository.GetTaskById(tasksID);
        }
    }
}
