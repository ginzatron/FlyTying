using FlyTying.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyTying.Contexts
{
    public class AppUserContext : DbContext
    {
        public AppUserContext(DbContextOptions<AppUserContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        public DbSet<AppUser> AppUsers { get; set; }
    }
}
