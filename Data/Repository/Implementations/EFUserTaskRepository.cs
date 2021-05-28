using LessonWebProject.Data.Repository.Interfaces;
using LessonWebProject.Common.Models.DB;
using LessonWebProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LessonWebProject.Data.Repository.Implementations
{
    public class EFUserTaskRepository : IUserTaskRepository
    {
        private readonly EFDBUserTaskContext context;
        public EFUserTaskRepository(EFDBUserTaskContext context)
        {
            this.context = context;
        }

        public void RemoveUserTasksByID(string userID, int[] tasksID)
        {
            context.UserTasks.RemoveRange(context.UserTasks.Where(p => p.UserID == userID && tasksID.Contains(p.ID)));
            context.SaveChanges();
        }
        public IEnumerable<UserTaskDBModel> GetAllUsersTasks()
        {
            return context.UserTasks;
        }
        public IEnumerable<UserTaskDBModel> GetAllUserTasksByID(string userID)
        {
            return context.UserTasks.Where(p => p.UserID == userID);
        }

        public int GetCountTasksByID(string userID)
        {
            return context.UserTasks.Where(p => p.UserID == userID).Count();
        }

        public UserTaskDBModel GetTaskById(int ID)
        {
            return context.UserTasks.Where(p => p.ID == ID).FirstOrDefault();
        }

        public void SaveUserTask(UserTaskDBModel model)
        {
            context.UserTasks.Add(model);
            context.SaveChanges();
        }
       
    }
}
