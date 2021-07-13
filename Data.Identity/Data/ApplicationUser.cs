using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace LessonWebProject.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string TelegrammRegisterCode { get; set; }
        public long? TelegramUserID { get; set; }
    }
}
