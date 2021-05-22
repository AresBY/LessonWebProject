﻿using BusinessLayer.Interfaces;
using DataLayer;
using DataLayer.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLayer.Implementations
{
    public class EFUserTaskRepository : IUserTaskRepository
    {
        private readonly EFDBContext context;
        public EFUserTaskRepository(EFDBContext context)
        {
            this.context = context;
        }

        public void RemoveUserTasksByID(string userID, int[] tasksID)
        {
            context.UserTasks.RemoveRange(context.UserTasks.Where(p => p.UserID == userID && tasksID.Contains(p.ID)));
            context.SaveChanges();
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
            context.Add(model);
            context.SaveChanges();
        }
    }
}
