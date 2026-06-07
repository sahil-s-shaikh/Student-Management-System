using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Data
{
    public class ApplicationDbContext:DbContext
    {
        
            public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
                : base(options)
            {
            }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Students>()
                .HasIndex(s => s.Email)
                .IsUnique();
        }
        public DbSet<Students> Students { get; set; }
        public DbSet<User> Users { get; set; }



        
    }
    }
