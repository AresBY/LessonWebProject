using DataLayer.Models.DB;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interfaces
{
    public interface IUserTaskRepository
    {
        IEnumerable<UserTaskDBModel> GetAllUserTasksDBModels();
        IEnumerable<UserTaskDBModel> GetAllUserTasksByID(string userID);
        void RemoveUserTasksByID(string userID, int[] tasksID);
        int GetCountTasksByID(string userID);
        UserTaskDBModel GetTaskById(int directoryID);
        void SaveUserTask(UserTaskDBModel model);
        void DeleteUserTask(UserTaskDBModel model);
    }
}
