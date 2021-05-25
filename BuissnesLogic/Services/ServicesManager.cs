
using System.Collections.Generic;
using System.Text;

namespace LessonWebProject.BusinessLogic.Services
{
    public class ServicesManager
    {
        public readonly UserTaskService _userTaskService;
        public ServicesManager( UserTaskService userTaskService)
        {
            _userTaskService = userTaskService;
        }
    }
}
