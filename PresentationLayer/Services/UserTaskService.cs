using BusinessLayer;
using BusinessLayer.Models.DB;
using DataLayer.Entityes;
using System;
using System.Collections.Generic;
using System.Text;

namespace PresentationLayer.Services
{
    public class UserTaskService
    {
        BusinessManager _businessManager;
        public UserTaskService(BusinessManager businessManager)
        {
            _businessManager = businessManager;
        }
        public void CreateTask(UserTask userTask)
        {
            UserTaskDBModel ds = new UserTaskDBModel();
            ds.CategoryType = (int)userTask.CategoryType;
            ds.Price = userTask.Price;
            ds.Keywords = userTask.Keywords;
            _businessManager.UserTaskRepositiry.SaveUserTask(ds);
        }
    }
}
