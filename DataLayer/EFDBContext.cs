﻿using DataLayer.Models.DB;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
    public class EFDBContext : DbContext
    {
        public DbSet<UserTaskDBModel> UserTask { get; set; }
      

        public EFDBContext(DbContextOptions<EFDBContext> options) : base(options) { }

    }
}
