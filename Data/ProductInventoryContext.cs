 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductInventory.Models;

namespace ProductInventory.Data
{
    public class ProductInventoryContext : DbContext
    {
        public ProductInventoryContext (DbContextOptions<ProductInventoryContext> options)
            : base(options)
        {
        }

        public DbSet<ProductInventory.Models.Product> Product { get; set; }
    }
}
 