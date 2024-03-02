 using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
 using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using WebApplicationTest1.Models;

namespace WebApplicationTest1.Data
{
        public class ApplicationDbContext : IdentityDbContext
        {
            public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
                : base(options)
            {
            }

            public DbSet<Person> People { get; set; }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);

                // Additional model configurations
                modelBuilder.Entity<Person>().HasKey(p => p.Id);
                modelBuilder.Entity<Person>().Property(p => p.Name).IsRequired();
                modelBuilder.Entity<Person>().Property(p => p.Age).IsRequired();
            }


    }
}
