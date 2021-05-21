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

        public void RemoveTasksByID(string userID, int[] tasksID)
        {
            _userTaskRepository.DeleteUserTasksByID(userID, tasksID);
        }

        public IEnumerable<UserTaskViewModel> GetAllTasks(string userID)
        {
            return ConvertDBModelToView(_userTaskRepository.GetAllUserTasksByID(userID));
        }

        public int GetCountTasks(string userID)
        {
            return _userTaskRepository.GetCountTasksByID(userID);
        }
        public IEnumerable<UserTaskViewModel> ConvertDBModelToView(IEnumerable<UserTaskDBModel> input)
        {
            List<UserTaskViewModel> output = new List<UserTaskViewModel>();
            foreach (var v in input)
            {
                output.Add(
                    new UserTaskViewModel()
                    {
                        ID = v.ID,
                        CategoryType = v.CategoryType,
                        Price = v.Price,
                        Keywords = v.Keywords
                    });
            }
            return output;
        }
    }
}
