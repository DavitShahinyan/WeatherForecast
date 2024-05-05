using WeatherForecast.Domain.Entities;

namespace WeatherForecast.DAL.Repositories
{
    public class HourlyWeatherForecastRepository : RepositoryBase<HourlyWeatherForecast>
    {
        public HourlyWeatherForecastRepository(WeatherForecastDbContext context) : base(context) { }
    }
}
