using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using WeatherForecast.Domain.Infrastructure.EntityAbstractions;
using WeatherForecast.Domain.Infrastructure.EntityConfigurations;

namespace WeatherForecast.Domain.Entities
{
    [EntityTypeConfiguration(typeof(DailyWeatherForecastConfiguration))]
    public class DailyWeatherForecast : EntityBaseWithId
    {
        public DateOnly Date { get; set; }
        public float Temperature { get; set; }
        public byte Humidity { get; set; }
        public double WindSpeed { get; set; }
        public int CityId { get; set; }
        [JsonIgnore]
        public City? City { get; set; }
        public ICollection<HourlyWeatherForecast>? HourlyWeatherForecasts { get; set; } = null;
    }
}
