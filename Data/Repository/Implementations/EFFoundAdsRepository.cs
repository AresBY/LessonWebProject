using LessonWebProject.Common.Models.DB;
using LessonWebProject.Data.Repository.Interfaces;
using LessonWebProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LessonWebProject.Data.Repository.Implementations
{
    public class EFFoundAdsRepository : IFoundAdsRepository
    {
        private readonly EFDBFoundAdContext context;
        public EFFoundAdsRepository(EFDBFoundAdContext context)
        {
            this.context = context;
        }

        public IEnumerable<FoundAdDBModel> GetAllFoundAds()
        {
            return context.FoundAds;
        }

        public void SaveAds(List<FoundAdDBModel> output)
        {
            foreach (var model in output)
                context.Add(model);

            context.SaveChanges();
        }
    }
}

