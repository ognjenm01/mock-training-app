using Microsoft.EntityFrameworkCore;
using TrainingAppBackend.Context;
using TrainingAppBackend.Models;

namespace TrainingAppBackend.Services
{
    public class WeatherForecastService
    {
        private readonly ApplicationDbContext _context;

        public WeatherForecastService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<WeatherForecast>> GetAllAsync()
        {
            return await _context.WeatherForecasts.ToListAsync();
        }

        public async Task<WeatherForecast?> GetByIdAsync(int id)
        {
            return await _context.WeatherForecasts.FindAsync(id);
        }
    }
}
