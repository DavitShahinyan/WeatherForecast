using WeatherForecast.Domain.Entities;

namespace WeatherForecast.Service.Helper
{
    public static class ForecastAveragesExtensions
    {
        public static void FillAverages(this DailyWeatherForecast forecast)
        {
            forecast.Temperature = forecast.HourlyWeatherForecasts.Average(x => x.Temperature);
            forecast.Humidity = Convert.ToByte(forecast.HourlyWeatherForecasts.Average(x => x.Humidity));
            forecast.WindSpeed = forecast.HourlyWeatherForecasts.Average(x => x.WindSpeed);
        }
        public static void FillAveragesRange(this IEnumerable<DailyWeatherForecast> forecasts)
        {
            foreach (var forecast in forecasts)
            {
                forecast.FillAverages();
            }
        }
    }
}
