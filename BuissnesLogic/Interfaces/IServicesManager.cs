namespace LessonWebProject.BusinessLogic.Interfaces
{
    public interface IServicesManager
    {
        IAdsService _adsService { get; set; }
        IHomeService _homeService { get; set; }
        IUserTaskService _userTaskService { get; set; }
    }
}