

using BusinessLayer;
using BusinessLayer.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PresentationLayer.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PresentationLayer.Controllers
{

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly UserManager<IdentityUser> _userManager;
        private readonly UserTaskService _userTaskService;

        public HomeController(UserTaskService userTaskService, UserManager<IdentityUser> manager, ILogger<HomeController> logger)
        {
            _userTaskService = userTaskService;
            _logger = logger;
            _userManager = manager;
        }

        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                string nameMethod = _userTaskService.GetCountTasks(User.FindFirstValue(ClaimTypes.NameIdentifier)) > 0 ? "ShowTasks" : "CreateNewTask";
                return RedirectToAction(nameMethod, "UserTask");
            }
            else
            {
                return RedirectToPage("/Account/Login", new { area = "Identity" });
            }
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
