using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using WeatherForecast.Domain.Infrastructure.EntityAbstractions;

namespace WeatherForecast.Domain.Entities
{
    public class City : EntityBaseWithId
    {
        [MaxLength(255)]
        public string Name { get; set; }
        public int CountryId { get; set; }
        [JsonIgnore]
        public Country? Country { get; set; } = null;
    }
}
