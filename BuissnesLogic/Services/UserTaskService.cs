using LessonWebProject.BusinessLogic.Repository.Interfaces;
using LessonWebProject.Common.Models.DB;
using LessonWebProject.Common.Models.View;
using System.Collections.Generic;

namespace LessonWebProject.BusinessLogic.Services
{
    public class UserTaskService
    {
        private readonly IUserTaskRepository _userTaskRepository;

        public UserTaskService(IUserTaskRepository userTaskRepository)
        {
            _userTaskRepository = userTaskRepository;
        }

        public void CreateTask(string userID, UserTaskViewModel userTaskViewModel)
        {
            _userTaskRepository.SaveUserTask(ConvertViewModelToDBModel(userID, userTaskViewModel));
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
        public UserTaskDBModel ConvertViewModelToDBModel(string userID, UserTaskViewModel input)
        {
            UserTaskDBModel output = new UserTaskDBModel()
            {
                ID = input.ID,
                UserID = userID,
                CategoryType = input.CategoryType,
                Price = input.Price,
                Keywords = input.Keywords
            };
            return output;
        }

        public UserTaskDBModel GetTaskById(int tasksID)
        {
            return _userTaskRepository.GetTaskById(tasksID);
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
