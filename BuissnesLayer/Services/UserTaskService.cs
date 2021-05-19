using BusinessLayer;
using DataLayer.Enums;
using DataLayer.Models.DB;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
    public class UserTaskService
    {
        BusinessManager _businessManager;
        public UserTaskService(BusinessManager businessManager)
        {
            _businessManager = businessManager;
        }
        public void CreateTask(CategoryType category, int maxPrice, string keyWords)
        {
            UserTaskDBModel dbModel = new UserTaskDBModel();
            dbModel.CategoryType = category;
            dbModel.Price = maxPrice;
            dbModel.Keywords = keyWords;
            _businessManager.UserTaskRepositiry.SaveUserTask(dbModel);
        }
    }
}
