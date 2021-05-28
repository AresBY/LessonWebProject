using LessonWebProject.Common.Models.DB;
using Microsoft.EntityFrameworkCore;

namespace LessonWebProject.Data
{
    public class EFDBUserTaskContext : DbContext
    {
        public DbSet<UserTaskDBModel> UserTasks { get; set; }

        public EFDBUserTaskContext(DbContextOptions<EFDBUserTaskContext> options) : base(options) { }

    }
}
