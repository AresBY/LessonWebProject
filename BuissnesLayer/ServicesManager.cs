using BusinessLayer.Services;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer
{
    class ServicesManager
    {
        BusinessManager _businessManager;
        public UserTaskService _userTaskService;
        public ServicesManager(BusinessManager businessManager, UserTaskService userTaskService)
        {
            _userTaskService = userTaskService;
            _businessManager = businessManager;
        }
    }
}
