using LessonWebProject.BusinessLogic.Models;
using System.Collections.Generic;

namespace LessonWebProject.BusinessLogic.Interfaces
{
    public interface IAdsService
    {
        IEnumerable<AdModel> GetAdsByTaskID(int taskID);
    }
}