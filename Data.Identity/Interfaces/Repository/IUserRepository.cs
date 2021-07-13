using System;
using System.Collections.Generic;
using System.Text;

namespace LessonWebProject.Data.Identity.Interfaces.Repository
{
    public interface IUserRepository
    {
        void SaveTelegramRegisterCode(string userID, string code);
        string GetTelegrammRegisterCode(string userID);
        bool TelegramUserRegistration(string token, long id);
        bool isRegisteredUser(long id);
        string GetUserIdByTelegramChatID(long token);
    }
}
