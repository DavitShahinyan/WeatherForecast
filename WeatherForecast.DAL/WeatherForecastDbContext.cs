using Microsoft.EntityFrameworkCore;
using WeatherForecast.Domain.Entities;

namespace WeatherForecast.DAL
{
    public class WeatherForecastDbContext : DbContext
    {
        public WeatherForecastDbContext(DbContextOptions<WeatherForecastDbContext> options) : base(options) { }

        public DbSet<DailyWeatherForecast> DailyWeatherForecasts { get; set; }
        public DbSet<HourlyWeatherForecast> HourlyWeatheForecasts { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
    }
}
