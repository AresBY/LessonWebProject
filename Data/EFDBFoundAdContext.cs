using LessonWebProject.Common.Models.DB;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LessonWebProject.Data
{
    public class EFDBFoundAdContext : DbContext
    {
        public DbSet<FoundAdDBModel> FoundAds { get; set; }

        public EFDBFoundAdContext(DbContextOptions<EFDBFoundAdContext> options) : base(options) { }
    }
}
