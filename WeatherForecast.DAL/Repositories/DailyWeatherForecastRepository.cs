using Microsoft.EntityFrameworkCore;
using WeatherForecast.Domain.Entities;
using WeatherForecast.Domain.Infrastructure.RepositoryInterfaces;

namespace WeatherForecast.DAL.Repositories
{
    public class DailyWeatherForecastRepository : RepositoryBase<DailyWeatherForecast>, IWeatherForecastRepository
    {
        public DailyWeatherForecastRepository(WeatherForecastDbContext weatherForecastContext) : base(weatherForecastContext) { }

        public IEnumerable<DailyWeatherForecast> GetWeeklyForecast(string countryName, string cityName)
        {
            return _dbSet
                .Include(x => x.HourlyWeatherForecasts)
                .Include(c => c.City)
                .ThenInclude(c => c.Country)
                .Where(
                    x => x.City.Country.Name.ToLower() == countryName.ToLower() && 
                    x.City.Name.ToLower() == cityName.ToLower() && 
                    x.Date >= DateOnly.FromDateTime(DateTime.Now) && 
                    x.Date <= DateOnly.FromDateTime(DateTime.Now).AddDays(7)).ToList();
        }
    }
}