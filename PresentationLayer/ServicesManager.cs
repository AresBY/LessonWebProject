using BusinessLayer;
using PresentationLayer.Services;
using System.Collections.Generic;
using System.Text;

namespace PresentationLayer
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
