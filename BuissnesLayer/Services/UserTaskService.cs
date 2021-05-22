using BusinessLayer;
using BusinessLayer.Interfaces;
using BusinessLayer.Models.View;
using DataLayer.Enums;
using DataLayer.Models.DB;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
    public class UserTaskService
    {
        public readonly IUserTaskRepository _userTaskRepository;

        public UserTaskService(IUserTaskRepository userTaskRepository)
        {
            _userTaskRepository = userTaskRepository;
        }
        public void CreateTask(string UserID, CategoryType category, int maxPrice, string keyWords)
        {
            UserTaskDBModel dbModel = new UserTaskDBModel();
            dbModel.CategoryType = category;
            dbModel.Price = maxPrice;
            dbModel.Keywords = keyWords;
            dbModel.UserID = UserID;
            _userTaskRepository.SaveUserTask(dbModel);
        }

        public void RemoveTasksByID(string userID, params int[] tasksID)
        {
            _userTaskRepository.RemoveUserTasksByID(userID, tasksID);
        }

        public IEnumerable<UserTaskViewModel> GetAllTasks(string userID)
        {
            return ConvertDBModelsToView(_userTaskRepository.GetAllUserTasksByID(userID));
        }

        public int GetCountTasks(string userID)
        {
            return _userTaskRepository.GetCountTasksByID(userID);
        }

        public UserTaskViewModel ConvertDBModelToView(UserTaskDBModel input)
        {
            UserTaskViewModel output = new UserTaskViewModel()
            {
                ID = input.ID,
                CategoryType = input.CategoryType,
                Price = input.Price,
                Keywords = input.Keywords
            };

            return output;
        }
        public IEnumerable<UserTaskViewModel> ConvertDBModelsToView(IEnumerable<UserTaskDBModel> input)
        {
            List<UserTaskViewModel> output = new List<UserTaskViewModel>();
            foreach (var v in input)
            {
                output.Add(ConvertDBModelToView(v));
            }
            return output;
        }

       
    }
}
