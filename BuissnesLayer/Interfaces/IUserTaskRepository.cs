using PresentationLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interfaces
{
    public interface IUserTaskRepository
    {
        IEnumerable<UserTaskDBModel> GetAllUserTasksDBModels();
        UserTaskDBModel GetTaskById(int directoryID);
        void SaveUserTask(UserTaskDBModel model);
        void DeleteUserTask(UserTaskDBModel model);
    }
}
