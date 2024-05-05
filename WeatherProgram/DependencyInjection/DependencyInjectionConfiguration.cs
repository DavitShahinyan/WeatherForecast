using WeatherForecast.DAL.Repositories;
using WeatherForecast.Domain.Infrastructure.RepositoryInterfaces;
using WeatherForecast.Domain.Infrastructure.ServiceInterfaces;
using WeatherForecast.Service.Services;

namespace WeatherForecast.DependencyInjection
{
    public static class DependencyInjectionConfiguration
    {
        public static void AddDAL(this IServiceCollection services)
        {
            services.AddScoped<ILocationRepository, CountryRepository>();
            services.AddScoped<IWeatherForecastRepository, DailyWeatherForecastRepository>();
        }

        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<ILocationService, LocationService>();
            services.AddScoped<IDailyWeatherForecastService, WeatherForecastService>();
        }
    }
}
