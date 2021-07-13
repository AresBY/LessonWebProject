using LessonWebProject.Data.Identity;
using LessonWebProject.Data.Identity.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace LessonWebProject.BusinessLogic.Services
{
    public class HomeService
    {
        private readonly IUserRepository _userRepository;

        public HomeService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public string GenerateTelegrammRegisterCode()
        {
            return Guid.NewGuid().ToString();
        }

        public void SaveTelegrammRegisterCode(string userID, string registerCode)
        {
            _userRepository.SaveTelegramRegisterCode(userID, registerCode);
        }

        public string GetTelegrammRegisterCode(string userID)
        {
            return _userRepository.GetTelegrammRegisterCode(userID);
        }
    }
}
