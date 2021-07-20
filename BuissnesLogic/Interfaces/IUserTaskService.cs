using LessonWebProject.BusinessLogic.Models;
using System.Collections.Generic;

namespace LessonWebProject.BusinessLogic.Interfaces
{
    public interface IUserTaskService
    {
        void CreateTask(UserTaskModel userTaskModel);
        IEnumerable<UserTaskModel> GetAllUserTasks(string userID);
        int GetCountTasks(string userID);
        UserTaskModel GetTaskById(int tasksID);
        void RemoveTasksByID(string userID, params int[] tasksID);
    }
}