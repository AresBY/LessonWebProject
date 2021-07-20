namespace LessonWebProject.BusinessLogic.Interfaces
{
    public interface IHomeService
    {
        string GenerateTelegrammRegisterCode();
        string GetTelegrammRegisterCode(string userID);
        void SaveTelegrammRegisterCode(string userID, string registerCode);
    }
}