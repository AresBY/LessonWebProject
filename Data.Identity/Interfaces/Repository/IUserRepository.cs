using System;
using System.Collections.Generic;
using System.Text;

namespace LessonWebProject.Data.Identity.Interfaces.Repository
{
    public interface IUserRepository
    {
        void SaveTelegramRegisterCode(string userID, string code);
        string GetTelegrammRegisterCode(string userID);
        ApplicationUser GetUserByTelegramToken(string token);
        bool IsRegisteredUser(long id);
        string GetUserIdByTelegramChatID(long token);
        public void SaveTelegramUserID(ApplicationUser user, long id);
    }
}
