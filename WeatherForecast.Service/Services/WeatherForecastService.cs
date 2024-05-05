using WeatherForecast.Domain.Entities;
using WeatherForecast.Domain.Infrastructure.RepositoryInterfaces;
using WeatherForecast.Domain.Infrastructure.ServiceInterfaces;
using WeatherForecast.Service.Descriptor;
using WeatherForecast.Service.Exceptions.CommonExceptions;
using WeatherForecast.Service.Helper;

namespace WeatherForecast.Service.Services
{
    public class WeatherForecastService : ServiceBase<DailyWeatherForecast>, IDailyWeatherForecastService
    {
        private readonly IWeatherForecastRepository _dailyWeatherForecastRepository;
        public WeatherForecastService(IWeatherForecastRepository repository) : base(repository)
        {
            _dailyWeatherForecastRepository = repository;
        }

        public override IEnumerable<DailyWeatherForecast> GetAll()
        {
            return _repository.GetAll();
        }
        public IEnumerable<DailyWeatherForecast> GetWeeklyForecast(string countryName, string cityName)
        {
            return _dailyWeatherForecastRepository.GetWeeklyForecast(countryName, cityName);
        }
        public override IEnumerable<DailyWeatherForecast> AddWeeklyForecast(IEnumerable<DailyWeatherForecast> weeklyForecast)
        {
            ForecastValidator.ValidateRange(weeklyForecast);
            weeklyForecast.FillAveragesRange();
            return _repository.AddRange(weeklyForecast);
        }
        public override DailyWeatherForecast Update(DailyWeatherForecast forecast)
        {
            DailyWeatherForecast forecastToUpdate = null;
            if (forecast != null)
            {
                forecastToUpdate = _repository.GetByIdWithInclude(forecast.Id, x => x.HourlyWeatherForecasts);
            }

            if (forecastToUpdate != null)
            {
                forecastToUpdate.HourlyWeatherForecasts = forecast.HourlyWeatherForecasts;
                ForecastValidator.Validate(forecastToUpdate);
                forecastToUpdate.FillAverages();
            }
            return base.Update(forecastToUpdate);
        }
        public override DailyWeatherForecast AddDailyForecast(DailyWeatherForecast forecast)
        {
            ForecastValidator.Validate(forecast);
            forecast.FillAverages();
            return base.AddDailyForecast(forecast);
        }

        public DailyWeatherForecast GetWarmestDayFrom(string countryName, string cityName, DateOnly date)
        {
            IEnumerable<DailyWeatherForecast> weeklyForecast = GetWeeklyForecast(countryName, cityName);
            return weeklyForecast.Where(x => x.Date > date).MaxBy(x => x.Temperature) ?? throw new NotFoundException(CommonMessages.CannotFind);
        }

        public void DeleteOneMonthOldForecasts()
        {
            _repository.DeleteWhere(x => x.Date.AddDays(30) <= DateOnly.FromDateTime(DateTime.Now));
        }
    }
}
