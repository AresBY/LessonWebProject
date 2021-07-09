using System;
using System.Collections.Generic;
using System.Text;

namespace LessonWebProject.Web.Models
{
    public class ShowTasksViewModel
    {
        public ShowTasksViewModel() { }
        public ShowTasksViewModel(List<UserTaskViewModel> tasks, List<AdViewModel> ads)
        {
            Tasks = tasks;
            Ads = ads;
        }
        public List<UserTaskViewModel> Tasks;
        public List<AdViewModel> Ads;
    }
}
