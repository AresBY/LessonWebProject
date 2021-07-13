
using System.Collections.Generic;
using System.Text;

namespace LessonWebProject.BusinessLogic.Services
{
    public class ServicesManager
    {
        public readonly UserTaskService _userTaskService;
        public readonly AdsService _adsService;
        public readonly HomeService _homeService;
        public ServicesManager(UserTaskService userTaskService, AdsService adsService, HomeService homeService)
        {
            _userTaskService = userTaskService;
            _adsService = adsService;
            _homeService = homeService;
        }
    }
}
