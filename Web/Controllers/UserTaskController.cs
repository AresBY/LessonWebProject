using LessonWebProject.BusinessLogic.Services;
using LessonWebProject.Common;
using LessonWebProject.Data.Models.DB;
using LessonWebProject.Data.Models.View;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;

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
            return View(_servicesManager._userTaskService.GetTasksData(User.FindFirstValue(ClaimTypes.NameIdentifier), taskID));
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
            UserTaskDBModel model = _servicesManager._userTaskService.GetTaskById(taskID);
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
            _servicesManager._userTaskService.RemoveTasksByID(User.FindFirstValue(ClaimTypes.NameIdentifier), taskID);

            _servicesManager._userTaskService.CreateTask(User.FindFirstValue(ClaimTypes.NameIdentifier), userTaskViewModel);
            return RedirectToAction("ShowTasks");
        }

        [HttpPost]
        public IActionResult GetNewTaskData(UserTaskViewModel userTaskViewModel)
        {
            _servicesManager._userTaskService.CreateTask(User.FindFirstValue(ClaimTypes.NameIdentifier), userTaskViewModel);

            return RedirectToAction("ShowTasks");
        }
    }
}
