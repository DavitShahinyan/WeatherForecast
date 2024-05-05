using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WeatherForecast.Domain.Entities;

namespace WeatherForecast.Domain.Infrastructure.EntityConfigurations
{
    public class HourlyWeatherForecastConfiguration : IEntityTypeConfiguration<HourlyWeatherForecast>
    {
        public void Configure(EntityTypeBuilder<HourlyWeatherForecast> builder)
        {
            builder
                .HasOne(x => x.DailyWeatherForecast)
                .WithMany(x => x.HourlyWeatherForecasts)
                .HasForeignKey(x => x.DailyWeatherForecastId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
