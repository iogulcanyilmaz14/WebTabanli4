using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Entities.Concrete;

namespace Web.DataAccess.Concrete.EntityFramework
{
    public class OyuncakSatisContext :DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=(localdb)\mssqllocaldb;database=OyuncakSatis;Trusted_Connection=True");
        }

        public DbSet<PlushToy> PlushToys { get; set; }
    }
}
