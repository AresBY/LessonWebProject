
using BusinessLayer.Services;
using DataLayer.Enums;
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
        ServicesManager _servicesManager;
     
        public UserTaskController(ServicesManager servicesManager)
        {
            _servicesManager = servicesManager;
        }
        public IActionResult ShowTasks()
        {
            return View(_servicesManager._userTaskService.GetAllTasks(User.FindFirstValue(ClaimTypes.NameIdentifier)));
        }
        [HttpPost]
        public IActionResult DeleteTasks(int[] tasksID)
        {
            _servicesManager._userTaskService.RemoveTasksByID(User.FindFirstValue(ClaimTypes.NameIdentifier), tasksID);
            return RedirectToAction("ShowTasks");
        }


        public IActionResult CreateNewTask()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GetNewTaskData(CategoryType category, int maxPrice, string keyWords)
        {
            _servicesManager._userTaskService.CreateTask(User.FindFirstValue(ClaimTypes.NameIdentifier), category,  maxPrice,  keyWords);

            return RedirectToAction("ShowTasks");
        }
    }
}
