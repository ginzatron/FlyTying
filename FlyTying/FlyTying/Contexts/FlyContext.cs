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

        public DbSet<Fly> Flies { get; set; }
        public DbSet<FlyCategory> FlyCategories { get; set; }
        public DbSet<FlyMaterial> FlyMaterials { get; set; }
        public DbSet<FlyMaterialOption> FlyMaterialOptions { get; set; }
        public DbSet<FlyMaterialPosition> FlyMaterialPositions { get; set; }
    }
}