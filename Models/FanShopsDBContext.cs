using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace FanShopsDB.Models
{
    public class FanShopsDBContext : DbContext
    {
        public virtual DbSet<Assortment> Assortments { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Fandom> Fandoms { get; set; }
        public virtual DbSet<Producer> Producers { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Shop> Shops { get; set; }

        public FanShopsDBContext(DbContextOptions<FanShopsDBContext> options):base(options)
        {
            Database.EnsureCreated();
        }
    }
}
