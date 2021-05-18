using AspCore.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace AspCore.Classes
{
    public class ProductContext : DbContext
    {
        public ProductContext(IConfiguration configuration) : base(configuration.GetConnectionString("DefaultConnection"))
        {
           
        }

      
        //public ProductContext()
        //   : base("Server=localhost;Database=DBAspCore;Trusted_Connection=True;")
        //{ }

        public DbSet<ProductModel> Products { get; set; }
    }
}
