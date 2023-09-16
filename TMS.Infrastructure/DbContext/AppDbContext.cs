namespace TMS.Infrastructure.DbContext
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Entities;

    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {  
        }

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
                        .HasMany(t => t.Tasks);

            modelBuilder.Entity<UserTask>()
                        .HasOne(u => u.User);

            modelBuilder.Entity<AppTask>()
                        .HasOne(p => p.Project)
                        .WithMany(t => t.AppTasks);

            modelBuilder.Entity<Project>()
                        .HasMany(p => p.AppTasks);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

    }
}
