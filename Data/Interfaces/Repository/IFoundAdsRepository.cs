using LessonWebProject.Data.Models.DB;
using System;
using System.Collections.Generic;
using System.Text;


namespace LessonWebProject.Data.Interfaces.Repository
{
    public interface IFoundAdsRepository
    {
        void SaveAds(List<AdDBModel> output);
        IEnumerable<AdDBModel> GetAllFoundAds();
    }
}
