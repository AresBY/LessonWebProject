using AspCore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace AspCore.Classes
{
    public class ProductContext : DbContext
    {
        public ProductContext()
           : base("Server=localhost;Database=DBAspCore;Trusted_Connection=True;")
        { }

        public DbSet<ProductModel> Products { get; set; }
    }
}
