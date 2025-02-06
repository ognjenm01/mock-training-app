using Microsoft.EntityFrameworkCore;
using TrainingAppBackend.Models;

namespace TrainingAppBackend.Context
{
    public class ApplicationDbContext : DbContext
    {
        protected readonly IConfiguration _configuration;

        public ApplicationDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_configuration.GetConnectionString("PostgresDB"));
        }

        public DbSet<WeatherForecast> WeatherForecasts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<TrainingType> TrainingTypes { get; set; }
        public DbSet<Training> Trainings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasMany<Training>(u => u.Trainings)
                .WithOne()
                .HasForeignKey("UserId")
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Training>()
                .HasOne<User>(t => t.User)
                .WithMany(u => u.Trainings)
                .HasForeignKey(t => t.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Training>()
                .HasOne<TrainingType>()
                .WithMany(tt => tt.Trainings)
                .HasForeignKey(t => t.TrainingTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TrainingType>()
                .HasMany<Training>(tt => tt.Trainings)
                .WithOne()
                .HasForeignKey("TrainingTypeId")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
