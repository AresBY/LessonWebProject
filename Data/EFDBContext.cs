using LessonWebProject.Common.Models.DB;
using Microsoft.EntityFrameworkCore;

namespace LessonWebProject.Data
{
    public class EFDBContext : DbContext
    {
        public DbSet<UserTaskDBModel> UserTasks { get; set; }
      

        public EFDBContext(DbContextOptions<EFDBContext> options) : base(options) { }

    }
}
