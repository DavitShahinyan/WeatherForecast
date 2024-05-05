using Hangfire;
using WeatherForecast.Domain.Infrastructure.ServiceInterfaces;

namespace WeatherForecast.BackgroundServices
{
    public static class BackgroundServicesConfiguration
    {
        public static void AddBackgroundTasks(this IServiceProvider services)
        {
            using (var scope = services.CreateScope())
            {
                var forecastService = scope.ServiceProvider.GetRequiredService<IDailyWeatherForecastService>();

                var lifetime = services.GetRequiredService<IHostApplicationLifetime>();
                lifetime.ApplicationStarted.Register(() =>
                {
                    RecurringJob.AddOrUpdate(
                        BackgroundServiceConstants.DeleteOldWeatherForecasts,
                        () => forecastService.DeleteOneMonthOldForecasts(),
                        Cron.Daily(4));
                });
            }
        }
    }
}
