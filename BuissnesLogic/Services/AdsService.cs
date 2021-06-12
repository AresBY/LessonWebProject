using LessonWebProject.BusinessLogic.Models;
using LessonWebProject.Data.Interfaces.Repository;
using LessonWebProject.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LessonWebProject.BusinessLogic.Services
{
    public class AdsService
    {
        private readonly IAdsRepository _adsRepository;
        public AdsService(IAdsRepository adsRepository)
        {
            _adsRepository = adsRepository;
        }

        public IEnumerable<AdModel> GetAdsByTaskID(int taskID)
        {
            return ConvertToAdModel(_adsRepository.GetAdsByIdTask(taskID));
        }
        private IEnumerable<AdModel> ConvertToAdModel(IEnumerable<AdDBModel> input)
        {
            return input.Select(t => new AdModel(t));
        }
        private AdModel ConvertToAdModel(AdDBModel input)
        {
            return new AdModel(input);
        }
    }
}
