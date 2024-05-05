using WeatherForecast.Domain.Entities;

namespace WeatherForecast.DTO
{
    public class DailyWeatherForecastDTO
    {
        public DateOnly Date { get; set; }
        public float Temperature { get; set; }
        public byte Humidity { get; set; }
        public double WindSpeed { get; set; }
        public ICollection<HourlyWeatherForecast> HourlyWeatherForecasts { get; set; }
    }
}
