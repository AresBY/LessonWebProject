using BusinessLayer;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
    public class ServicesManager
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
