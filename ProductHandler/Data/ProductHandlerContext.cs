using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductHandler.Models;

namespace ProductHandler.Data
{
    public class ProductHandlerContext : DbContext
    {
        public ProductHandlerContext (DbContextOptions<ProductHandlerContext> options)
            : base(options)
        {
        }

        public DbSet<ProductModel> Products { get; set; }
    }
}
