using LessonWebProject.Data;
using LessonWebProject.Data.Interfaces.Repository;
using LessonWebProject.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LessonWebProject.Data.Implementations.Repository
{
    public class UserTaskRepository : IUserTaskRepository
    {
        private readonly EFContext context;
        public UserTaskRepository(EFContext context)
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

        public int GetCountTasksByUserID(string userID)
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
