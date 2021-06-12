
using System.Collections.Generic;
using System.Text;

namespace LessonWebProject.BusinessLogic.Services
{
    public class ServicesManager
    {
        public readonly UserTaskService _userTaskService;
        public readonly AdsService _adsService;
        public ServicesManager(UserTaskService userTaskService, AdsService adsService)
        {
            _userTaskService = userTaskService;
            _adsService = adsService;
        }
    }
}
