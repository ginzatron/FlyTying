using System;
using FlyTying.Entities;
using Microsoft.EntityFrameworkCore;

namespace FlyTying.Contexts
{
    public class FlyContext : DbContext
    {
        public FlyContext(DbContextOptions<FlyContext> options)
            : base(options)
        {
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        public DbSet<Pattern> Flies { get; set; }
        public DbSet<Pattern> FlyCategories { get; set; }
        public DbSet<Material> FlyMaterials { get; set; }
        public DbSet<MaterialSepcification> FlyMaterialOptions { get; set; }
    }
}