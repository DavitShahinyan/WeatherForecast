using WeatherForecast.Domain.Entities;
using WeatherForecast.Domain.Infrastructure.RepositoryAbstraction;

namespace WeatherForecast.Domain.Infrastructure.RepositoryInterfaces
{
    public interface IWeatherForecastRepository : IRepositoryBase<DailyWeatherForecast>
    {
        IEnumerable<DailyWeatherForecast> GetWeeklyForecast(string countryName, string cityName);
    }
}
