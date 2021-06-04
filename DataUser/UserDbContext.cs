using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace LessonWebProject.DataUser
{
    public class UserDbContext : IdentityDbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options)
            : base(options)
        {

        }
        public string GetEmailByID(string userID)
        {
            return Users.Where(t => t.Id == userID).FirstOrDefault().Email;
        }
    }
}
