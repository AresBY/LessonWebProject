using BusinessLayer.Models.View;
using DataLayer.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PresentationLayer
{
    public class PresentationManager
    {
        public IEnumerable<UserTaskViewModel> ConvertDBModelToView(IEnumerable<UserTaskDBModel> enumerable)
        {
            throw new NotImplementedException();
        }
    }
}
