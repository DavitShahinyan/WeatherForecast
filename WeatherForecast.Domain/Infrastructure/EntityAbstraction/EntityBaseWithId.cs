using System.ComponentModel.DataAnnotations;

namespace WeatherForecast.Domain.Infrastructure.EntityAbstractions
{
    public class EntityBaseWithId : EntityBase
    {
        [Key]
        public int Id { get; set; }
    }
}
