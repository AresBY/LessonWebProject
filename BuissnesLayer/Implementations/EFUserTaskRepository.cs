using BusinessLayer.Interfaces;
using PresentationLayer.Models;
using PresentationLayer.Models.DB;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Implementations
{
    public class EFUserTaskRepository : IUserTaskRepository
    {
        public void DeleteUserTask(UserTaskDBModel model)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserTaskDBModel> GetAllUserTasksDBModels()
        {
            throw new NotImplementedException();
        }

        public UserTaskDBModel GetTaskById(int directoryID)
        {
            throw new NotImplementedException();
        }

        public void SaveUserTask(UserTaskDBModel model)
        {
            throw new NotImplementedException();
        }
    }
}
