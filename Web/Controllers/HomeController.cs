using LessonWebProject.BusinessLogic.Services;
using LessonWebProject.Data.Identity;
using LessonWebProject.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;


namespace LessonWebProject.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ServicesManager _servicesManager;
        public HomeController(ServicesManager servicesManager)
        {
            _servicesManager = servicesManager;
        }
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("ShowTasks", "UserTask");
            }
            else
            {
                return RedirectToPage("/Account/Login", new { area = "Identity" });
            }
        }

        public IActionResult TelegramRegister()
        {
            if (User.Identity.IsAuthenticated)
            {
                string registerCode = _servicesManager._homeService.GenerateTelegrammRegisterCode();

                _servicesManager._homeService.SaveTelegrammRegisterCode(User.FindFirstValue(ClaimTypes.NameIdentifier), registerCode);

                object code = _servicesManager._homeService.GetTelegrammRegisterCode(User.FindFirstValue(ClaimTypes.NameIdentifier));
                return View(code);
            }
            else
            {
                return RedirectToPage("/Account/Login", new { area = "Identity" });
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
