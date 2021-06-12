using LessonWebProject.Data;
using LessonWebProject.Data.Interfaces.Repository;
using LessonWebProject.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LessonWebProject.Data.Implementations.Repository
{
    public class AdsRepository : IAdsRepository
    {
        private readonly EFContext _context;
        public AdsRepository(EFContext context)
        {
            _context = context;
        }

        public IEnumerable<AdDBModel> GetAllAds()
        {
            return _context.Ads;
        }

        public void SaveAds(List<AdDBModel> output)
        {
            foreach (var model in output)
            {
                model.WasFoundedDate = DateTime.Now;
            }
            _context.Ads.AddRange(output);
            var result = _context.SaveChanges();
            Console.WriteLine($"Save  {result} ads Count: { _context.Ads.Count()}");
        }
        public IEnumerable<AdDBModel> GetAdsByIdTask(int taskID)
        {
            return _context.Ads.Where(t => t.TaskID == taskID);
        }

        public void Clear()
        {
            _context.Ads.RemoveRange(_context.Ads);
            _context.SaveChanges();
        }

        public void SaveFreshAds(List<AdDBModel> input)
        {
            var res = _context.Ads.Where(t => input.Select(x => x.KufarID).Contains(t.KufarID));
            _context.Ads.RemoveRange(res);
            _context.SaveChanges();
            SaveAds(input);
        }
    }
}

