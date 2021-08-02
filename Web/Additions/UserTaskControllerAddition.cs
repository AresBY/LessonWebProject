using LessonWebProject.BusinessLogic.Interfaces;
using LessonWebProject.Web.Extensions;
using LessonWebProject.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Additions
{
    public class UserTaskControllerAddition
    {
        private readonly IServicesManager _servicesManager;

        public UserTaskControllerAddition(IServicesManager servicesManager)
        {
            _servicesManager = servicesManager;
        }

        public ShowTasksViewModel ShowTasks(int? taskID, string userID)
        {
            ShowTasksViewModel output = new ShowTasksViewModel();
            output.Tasks = _servicesManager._userTaskService.GetAllUserTasks(userID).toContract().ToList();
            output.Ads = taskID != null ? _servicesManager._adsService.GetAdsByTaskID((int)taskID).toContract().ToList() : null;
            return output;
        }

        public void DeleteTasks(int[] taskID, string userID)
        {
            _servicesManager._userTaskService.RemoveTasksByID(userID, taskID);
        }

        public void GetEditTaskData(int taskID, UserTaskViewModel userTaskViewModel, string userID)
        {
            _servicesManager._userTaskService.RemoveTasksByID(userID, taskID);

            userTaskViewModel.UserID = userID;
            _servicesManager._userTaskService.CreateTask(userTaskViewModel.toUserTaskModel());
        }

        public void GetNewTaskData(UserTaskViewModel userTaskViewModel, string userID)
        {
            userTaskViewModel.UserID = userID;
            _servicesManager._userTaskService.CreateTask(userTaskViewModel.toUserTaskModel());
        }
    }
}
