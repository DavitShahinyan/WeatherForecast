using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using WeatherForecast.Domain.Infrastructure.EntityAbstractions;
using WeatherForecast.Domain.Infrastructure.EntityConfigurations;

namespace WeatherForecast.Domain.Entities
{
    [EntityTypeConfiguration(typeof(HourlyWeatherForecastConfiguration))]
    public class HourlyWeatherForecast : EntityBaseWithId
    {
        public TimeOnly Hour { get; set; }
        public float Temperature { get; set; }
        public byte Humidity { get; set; }
        public double WindSpeed { get; set; }
        public int DailyWeatherForecastId { get; set; }
        [JsonIgnore]
        public DailyWeatherForecast? DailyWeatherForecast { get; set; } = null;
    }
}
