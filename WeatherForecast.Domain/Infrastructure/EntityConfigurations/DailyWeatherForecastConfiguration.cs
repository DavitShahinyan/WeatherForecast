using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WeatherForecast.Domain.Entities;

namespace WeatherForecast.Domain.Infrastructure.EntityConfigurations
{
    public class DailyWeatherForecastConfiguration : IEntityTypeConfiguration<DailyWeatherForecast>
    {
        public void Configure(EntityTypeBuilder<DailyWeatherForecast> builder)
        {
            builder.HasIndex(x => new { x.Date, x.CityId }).IsUnique();

            builder
                .HasOne(x => x.City)
                .WithMany()
                .HasForeignKey(x => x.CityId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
