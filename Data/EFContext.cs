using LessonWebProject.Data.Models.DB;
using Microsoft.EntityFrameworkCore;

namespace LessonWebProject.Data
{
    public class EFContext : DbContext
    {
        public DbSet<UserTaskDBModel> UserTasks { get; set; }
        public DbSet<AdDBModel> FoundAds { get; set; }

        public EFContext(DbContextOptions<EFContext> options) : base(options) { }

    }
}
