using LessonWebProject.Common.Models.DB;
using System.Collections.Generic;

namespace LessonWebProject.BusinessLogic.Repository.Interfaces
{
    public interface IUserTaskRepository
    {
        IEnumerable<UserTaskDBModel> GetAllUserTasksByID(string userID);
        void RemoveUserTasksByID(string userID, int[] tasksID);
        int GetCountTasksByID(string userID);
        UserTaskDBModel GetTaskById(int directoryID);
        void SaveUserTask(UserTaskDBModel model);
    }
}
