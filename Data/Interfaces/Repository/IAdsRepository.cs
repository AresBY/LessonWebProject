using LessonWebProject.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;


namespace LessonWebProject.Data.Interfaces.Repository
{
    public interface IAdsRepository
    {
        void SaveAds(List<AdDBModel> output);
        IEnumerable<AdDBModel> GetAllAds();
        IEnumerable<AdDBModel> GetAllUserAds(string userID);
        IEnumerable<AdDBModel> GetAdsByIdTask(int taskID);
        void Clear();
        void SaveFreshAds(List<AdDBModel> output);

    }
}
