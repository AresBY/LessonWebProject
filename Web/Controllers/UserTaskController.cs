using LessonWebProject.BusinessLogic.Models;
using LessonWebProject.BusinessLogic.Services;
using LessonWebProject.Common;
using LessonWebProject.Data.Models;
using LessonWebProject.Web.Exrensions;
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

            ShowTasksModel showTasksModel = new ShowTasksModel();
            showTasksModel.Tasks = ConvertToUserTaskViewModel(_servicesManager._userTaskService.GetAllUserTasks(userID)).ToList();
            showTasksModel.Ads = taskID != null ? ConvertToAdsViewModel(_servicesManager._adsService.GetAdsByTaskID((int)taskID)).ToList() : null;
            return View(showTasksModel);
        }

        private IEnumerable<AdViewModel> ConvertToAdsViewModel(IEnumerable<AdModel> input)
        {
            return input.Select(t => new AdViewModel(t));
        }

        private IEnumerable<UserTaskViewModel> ConvertToUserTaskViewModel(IEnumerable<UserTaskModel> input)
        {
            return input.Select(t => new UserTaskViewModel(t));
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
                return View(new UserTaskViewModel(model));
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
            _servicesManager._userTaskService.CreateTask(userTaskViewModel.ToModel());
            return RedirectToAction("ShowTasks");
        }

        [HttpPost]
        public IActionResult GetNewTaskData(UserTaskViewModel userTaskViewModel)
        {
            userTaskViewModel.UserID = User.FindFirstValue(ClaimTypes.NameIdentifier);
            _servicesManager._userTaskService.CreateTask(userTaskViewModel.ToModel());

            return RedirectToAction("ShowTasks");
        }
    }
}
