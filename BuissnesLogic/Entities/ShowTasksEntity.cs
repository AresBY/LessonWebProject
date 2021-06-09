using LessonWebProject.Data.Models.View;
using System;
using System.Collections.Generic;
using System.Text;

namespace LessonWebProject.BusinessLogic.Entities
{
    public class ShowTasksEntity
    {
        public ShowTasksEntity(List<UserTaskViewModel> tasks, List<AdViewModel> ads)
        {
            Tasks = tasks;
            Ads = ads;
        }
        public List<UserTaskViewModel> Tasks;
        public List<AdViewModel> Ads;
    }
}
