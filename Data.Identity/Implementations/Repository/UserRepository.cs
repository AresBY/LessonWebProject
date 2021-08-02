using LessonWebProject.Data.Identity.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LessonWebProject.Data.Identity.Implementations.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserDbContext _context;
        public UserRepository(UserDbContext context)
        {
            _context = context;
        }

        public string GetTelegrammRegisterCode(string userID)
        {
            return _context.Users.First(t => t.Id == userID).TelegrammRegisterCode;
        }

        public string GetUserIdByTelegramChatID(long token)
        {
            return _context.Users.First(t => t.TelegramUserID == token).Id;
        }

        public bool IsRegisteredUser(long id)
        {
            return _context.Users.FirstOrDefault(t => t.TelegramUserID == id) != null;
        }

        private void RemoveAllUsers()
        {
            _context.Users.RemoveRange(_context.Users);
            _context.SaveChanges();
        }

        public void SaveTelegramRegisterCode(string userID, string code)
        {
            _context.Users.First(t => t.Id == userID).TelegrammRegisterCode = code;
            _context.SaveChanges();
        }

        public void SaveTelegramUserID(ApplicationUser user, long id)
        {
            user.TelegramUserID = id;
            _context.SaveChanges();
        }
        public ApplicationUser GetUserByTelegramToken(string token)
        {
            return _context.Users.FirstOrDefault(t => t.TelegrammRegisterCode == token);
        }

       
    }
}
