
using LessonWebProject.Data.Models;
using System.Collections.Generic;

namespace LessonWebProject.Data.Interfaces.Repository
{
    public interface IUserTaskRepository
    {
        IEnumerable<UserTaskDBModel> GetAllUsersTasks();
        IEnumerable<UserTaskDBModel> GetAllUserTasksByID(string userID);
        void RemoveUserTasksByID(string userID, int[] tasksID);
        int GetCountTasksByUserID(string userID);
        UserTaskDBModel GetTaskById(int directoryID);
        void SaveUserTask(UserTaskDBModel model);
       
    }
}
