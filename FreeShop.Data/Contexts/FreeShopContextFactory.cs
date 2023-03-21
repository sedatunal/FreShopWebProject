using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeShop.Data.Contexts
{
    public class FreeShopContextFactory : IDesignTimeDbContextFactory<FreeShopContext>
    {
        public FreeShopContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<FreeShopContext>();
            optionsBuilder.UseSqlServer("server=DESKTOP-FNC15LB\\SQLEXPRESS; database=FreeShop; Trusted_Connection=true");

            return new FreeShopContext(optionsBuilder.Options);
        }
    }
}
