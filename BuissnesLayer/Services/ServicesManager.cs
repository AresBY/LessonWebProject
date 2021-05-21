using BusinessLayer;
using BusinessLayer.Interfaces;
using BusinessLayer.Models.View;
using DataLayer.Models.DB;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
    public class ServicesManager
    {
        public readonly UserTaskService _userTaskService;
        public readonly IUserTaskRepository _userTaskRepository;
        public ServicesManager(IUserTaskRepository userTaskRepository, UserTaskService userTaskService)
        {
            _userTaskService = userTaskService;
            _userTaskRepository = userTaskRepository;
        }
       
        public IEnumerable<UserTaskViewModel> ConvertDBModelToView(IEnumerable<UserTaskDBModel> input)
        {
            List<UserTaskViewModel> output = new List<UserTaskViewModel>();
            foreach (var v in input)
            {
                output.Add(
                    new UserTaskViewModel()
                    {
                        ID = v.ID,
                        CategoryType = v.CategoryType,
                        Price = v.Price,
                        Keywords = v.Keywords
                    });
            }
            return output;
        }
    }
}
