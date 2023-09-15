namespace TMS.Infrastructure.DbContext
{
    using Microsoft.EntityFrameworkCore;
    using Entities;
    using Microsoft.Extensions.Configuration;

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

            modelBuilder.Entity<Task>()
                        .HasOne(p => p.Project)
                        .WithMany(t => t.Tasks);
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
