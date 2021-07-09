using LessonWebProject.BusinessLogic.Models;
using LessonWebProject.BusinessLogic.Services;
using LessonWebProject.Common;
using LessonWebProject.Data.Models;
using LessonWebProject.Web.Extensions;
using LessonWebProject.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Linq;
using System;


namespace LessonWebProject.Web.Controllers
{
    public class UserTaskController : Controller
    {
        private readonly ServicesManager _servicesManager;
     
        public UserTaskController(ServicesManager servicesManager)
        {
            _servicesManager = servicesManager;
        }
        public IActionResult ShowTasks(int? taskID = null)
        {
            string userID = User.FindFirstValue(ClaimTypes.NameIdentifier);

            ShowTasksViewModel showTasksModel = new ShowTasksViewModel();
            showTasksModel.Tasks = _servicesManager._userTaskService.GetAllUserTasks(userID).toContract().ToList();
            showTasksModel.Ads = taskID != null ? _servicesManager._adsService.GetAdsByTaskID((int)taskID).toContract().ToList() : null;
            return View(showTasksModel);
        }

      

       
        public IActionResult DeleteTasks(params int[] taskID)
        {
            _servicesManager._userTaskService.RemoveTasksByID(User.FindFirstValue(ClaimTypes.NameIdentifier), taskID);
            return RedirectToAction("ShowTasks");
        }

        [HttpPost]
        public IActionResult OperationWithTask(int taskID, string operation)
        {
            string nameMethod = string.Empty;
            switch (operation)
            {
                case "delete":
                    {
                        nameMethod = "DeleteTasks";
                        break;
                    }
                case "edit":
                    {
                        nameMethod = "EditTask";
                        break;
                    }
                case "info":
                    {
                        nameMethod = "ShowTasks";
                        break;
                    }
                case "create":
                    {
                        nameMethod = "CreateNewTask";
                        break;
                    }
            }
            return RedirectToAction(nameMethod, new { taskID });
        }

        public IActionResult EditTask(int taskID)
        {
            var model = _servicesManager._userTaskService.GetTaskById(taskID);
            if (model != null)
            {
                return View(model.toContract());
            }
            else
            {
                return RedirectToAction("ShowTasks");
            }
        }

        public IActionResult CreateNewTask()
        {
            return View(new UserTaskViewModel());
        }
        [HttpPost]
        public IActionResult GetEditTaskData(int taskID, UserTaskViewModel userTaskViewModel)
        {
            string userID = User.FindFirstValue(ClaimTypes.NameIdentifier);
            _servicesManager._userTaskService.RemoveTasksByID(userID, taskID);

            userTaskViewModel.UserID = userID;
            _servicesManager._userTaskService.CreateTask(userTaskViewModel.toUserTaskModel());
            return RedirectToAction("ShowTasks");
        }

        [HttpPost]
        public IActionResult GetNewTaskData(UserTaskViewModel userTaskViewModel)
        {
            userTaskViewModel.UserID = User.FindFirstValue(ClaimTypes.NameIdentifier);
            _servicesManager._userTaskService.CreateTask(userTaskViewModel.toUserTaskModel());

            return RedirectToAction("ShowTasks");
        }
    }
}
