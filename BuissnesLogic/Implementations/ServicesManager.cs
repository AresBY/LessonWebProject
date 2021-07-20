
using LessonWebProject.BusinessLogic.Interfaces;
using System.Collections.Generic;
using System.Text;

namespace LessonWebProject.BusinessLogic.Implementations
{
    public class ServicesManager : IServicesManager
    {
        public IUserTaskService _userTaskService { get; set; }
        public IAdsService _adsService { get; set; }
        public IHomeService _homeService { get; set; }
        public ServicesManager(IUserTaskService userTaskService, IAdsService adsService, IHomeService homeService)
        {
            _userTaskService = userTaskService;
            _adsService = adsService;
            _homeService = homeService;
        }
    }
}
