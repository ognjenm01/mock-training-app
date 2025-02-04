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
    }
}
