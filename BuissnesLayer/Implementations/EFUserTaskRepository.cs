using BusinessLayer.Interfaces;
using BusinessLayer.Models.DB;
using DataLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Implementations
{
    public class EFUserTaskRepository : IUserTaskRepository
    {
        private EFDBContext context;
        public EFUserTaskRepository(EFDBContext context)
        {
            this.context = context;
        }
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
            
            context.Add(model);
            var c = context.SaveChanges();
        }
    }
}
