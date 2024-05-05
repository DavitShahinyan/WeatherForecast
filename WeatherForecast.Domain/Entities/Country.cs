using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using WeatherForecast.Domain.Infrastructure.EntityAbstractions;
using WeatherForecast.Domain.Infrastructure.EntityConfigurations;

namespace WeatherForecast.Domain.Entities
{
    [EntityTypeConfiguration(typeof(CountryConfiguration))]
    public class Country : EntityBaseWithId
    {
        [MaxLength(255)]
        public string Name { get; set; }
        public ICollection<City>? Cities { get; set; } = null;
    }
}
