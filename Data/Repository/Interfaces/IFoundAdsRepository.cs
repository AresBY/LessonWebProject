using LessonWebProject.Common.Models.DB;
using System;
using System.Collections.Generic;
using System.Text;


namespace LessonWebProject.Data.Repository.Interfaces
{
    public interface IFoundAdsRepository
    {
        void SaveAds(List<FoundAdDBModel> output);
        IEnumerable<FoundAdDBModel> GetAllFoundAds();
    }
}
