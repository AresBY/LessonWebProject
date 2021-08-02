using LessonWebProject.BusinessLogic.Models;
using LessonWebProject.Common;
using LessonWebProject.Data.Models;
using LessonWebProject.Web.Extensions;
using LessonWebProject.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Linq;
using System;
using LessonWebProject.BusinessLogic.Interfaces;
using Web.Additions;

namespace LessonWebProject.Web.Controllers
{
    public class UserTaskController : Controller
    {
        private readonly UserTaskControllerAddition _userTaskControllerAddition;
        private readonly IServicesManager _servicesManager;


        public UserTaskController(IServicesManager servicesManager, UserTaskControllerAddition userTaskControllerAddition)
        {
            _servicesManager = servicesManager;
            _userTaskControllerAddition = userTaskControllerAddition;
        }
        public IActionResult ShowTasks(int? taskID = null)
        {
            string userID = User.FindFirstValue(ClaimTypes.NameIdentifier);

            ShowTasksViewModel showTasksModel = _userTaskControllerAddition.ShowTasks(taskID, userID);

            return View(showTasksModel);
        }
       
        public IActionResult DeleteTasks(params int[] taskID)
        {
            string userID = User.FindFirstValue(ClaimTypes.NameIdentifier);

            _userTaskControllerAddition.DeleteTasks(taskID, userID);

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

            _userTaskControllerAddition.GetEditTaskData(taskID, userTaskViewModel, userID);
           
            return RedirectToAction("ShowTasks");
        }

        [HttpPost]
        public IActionResult GetNewTaskData(UserTaskViewModel userTaskViewModel)
        {
            string userID =  User.FindFirstValue(ClaimTypes.NameIdentifier);

            _userTaskControllerAddition.GetNewTaskData(userTaskViewModel, userID);

            return RedirectToAction("ShowTasks");
        }
    }
}
