using FlyTying.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyTying.Contexts
{
    public class MaterialContext : DbContext
    {
        public MaterialContext(DbContextOptions<MaterialContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        public DbSet<Material> Materials { get; set; }
        public DbSet<MaterialOption> MaterialOptions { get; set; }
        public DbSet<MaterialCategory> MaterialCategories { get; set; }
    }
}
