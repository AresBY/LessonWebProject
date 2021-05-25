
using LessonWebProject.BusinessLogic.Services;
using LessonWebProject.Common.Models.DB;
using LessonWebProject.Common.Models.View;
using Microsoft.AspNetCore.Mvc;
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
