using LessonWebProject.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace LessonWebProject.Data
{
    public class EFContext : DbContext
    {
        public DbSet<UserTaskDBModel> UserTasks { get; set; }
        public DbSet<AdDBModel> Ads { get; set; }

        public EFContext(DbContextOptions<EFContext> options) : base(options) { }

    }
}
