using WeatherForecast.Domain.Entities;
using WeatherForecast.Domain.Infrastructure.ServiceAbstraction;

namespace WeatherForecast.Domain.Infrastructure.ServiceInterfaces
{
    public interface IDailyWeatherForecastService : IServiceBase<DailyWeatherForecast>
    {
        IEnumerable<DailyWeatherForecast> GetWeeklyForecast(string countryName, string cityName);

        DailyWeatherForecast GetWarmestDayFrom(string countryName, string cityName, DateOnly date);

        void DeleteOneMonthOldForecasts();
    }
}
