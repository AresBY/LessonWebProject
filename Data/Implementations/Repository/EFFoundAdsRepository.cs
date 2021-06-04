using LessonWebProject.Data;
using LessonWebProject.Data.Interfaces.Repository;
using LessonWebProject.Data.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LessonWebProject.Data.Implementations.Repository
{
    public class EFFoundAdsRepository : IFoundAdsRepository
    {
        private readonly EFContext _context;
        public EFFoundAdsRepository(EFContext context)
        {
            this._context = context;
        }

        public IEnumerable<AdDBModel> GetAllFoundAds()
        {
            return _context.FoundAds;
        }

        public void SaveAds(List<AdDBModel> output)
        {
            foreach (var model in output)
                _context.Add(model);

            _context.SaveChanges();
        }
    }
}

