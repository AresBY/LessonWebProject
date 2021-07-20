using LessonWebProject.BusinessLogic.Models;
using LessonWebProject.Data.Interfaces.Repository;
using LessonWebProject.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using LessonWebProject.BusinessLogic.Extensions;
using LessonWebProject.BusinessLogic.Interfaces;

namespace LessonWebProject.BusinessLogic.Implementations
{
    public class AdsService : IAdsService
    {
        private readonly IAdsRepository _adsRepository;
        public AdsService(IAdsRepository adsRepository)
        {
            _adsRepository = adsRepository;
        }

        public IEnumerable<AdModel> GetAdsByTaskID(int taskID)
        {
            return _adsRepository.GetAdsByIdTask(taskID).toAdModel();
        }
    }
}
