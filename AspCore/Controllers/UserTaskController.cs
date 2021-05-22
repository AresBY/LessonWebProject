
using BusinessLayer.Models.View;
using BusinessLayer.Services;
using DataLayer.Enums;
using DataLayer.Models.DB;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PresentationLayer.Controllers
{
    public class UserTaskController : Controller
    {
        private readonly ServicesManager _servicesManager;

        public UserTaskController(ServicesManager servicesManager)
        {
            _servicesManager = servicesManager;
        }
        public IActionResult ShowTasks()
        {
            return View(_servicesManager._userTaskService.GetAllTasks(User.FindFirstValue(ClaimTypes.NameIdentifier)));
        }

        public IActionResult DeleteTasks(params int[] tasksID)
        {
            _servicesManager._userTaskService.RemoveTasksByID(User.FindFirstValue(ClaimTypes.NameIdentifier), tasksID);
            return RedirectToAction("ShowTasks");
        }

        [HttpPost]
        public IActionResult OperationWithTask(int tasksID, string operation)
        {
            var nameMethod = operation.CompareTo("delete") == 0 ? "DeleteTasks" : "EditTask";
            return RedirectToAction(nameMethod, new { tasksID });
        }

        public IActionResult EditTask(int tasksID)
        {
            UserTaskDBModel model = _servicesManager._userTaskService.GetTaskById(tasksID);
            if (model != null)
            {
                return View(_servicesManager._userTaskService.ConvertDBModelToView(model));
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
            _servicesManager._userTaskService.CreateTask(User.FindFirstValue(ClaimTypes.NameIdentifier),userTaskViewModel);

            return RedirectToAction("ShowTasks");
        }
    }
}
