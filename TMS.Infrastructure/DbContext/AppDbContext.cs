namespace TMS.Infrastructure.DbContext
{
    using System;
    using System.Collections.Generic;
    using Microsoft.EntityFrameworkCore;
    using Entities;

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) 
            : base(options) 
        {
        }

        public DbSet<Notification> Notifications { get; set; }

        public DbSet<Project> Projects { get; set; }

        public DbSet<Task> Tasks { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<UserTask> UsersTasks { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserTask>()
                        .HasKey(u => new { u.UserId });
            modelBuilder.Entity<UserTask>()
                        .HasOne(u => u.User);
        }
    }
}
