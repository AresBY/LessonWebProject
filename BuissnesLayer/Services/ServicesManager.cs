using BusinessLayer;
using BusinessLayer.Interfaces;
using BusinessLayer.Models.View;
using DataLayer.Models.DB;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
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
