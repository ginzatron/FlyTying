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

        public DbSet<FlyRecipe> Flies { get; set; }
        public DbSet<Pattern> FlyCategories { get; set; }
        public DbSet<Ingredient> FlyMaterials { get; set; }
        public DbSet<IngredientSepcification> FlyMaterialOptions { get; set; }
    }
}