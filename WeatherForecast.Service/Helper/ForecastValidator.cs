using WeatherForecast.Domain.Entities;
using WeatherForecast.Service.Descriptor;
using WeatherForecast.Service.Exceptions.DailyForecast;
using WeatherForecast.Service.Exceptions.HourlyForecast;

namespace WeatherForecast.Service.Helper
{
    public static class ForecastValidator
    {
        public static void ValidateRange(IEnumerable<DailyWeatherForecast> forecasts)
        {
            if (forecasts.Count() != 7)
            {
                throw new InvalidForecastCountException(WeatherServiceMessages.OnlySevenElements);
            }
            if (forecasts.Any(x => x.CityId != forecasts.First().CityId))
            {
                throw new DifferentCitiesInListException(WeatherServiceMessages.DifferentCities);
            }
            foreach (var forecast in forecasts)
            {
                Validate(forecast);
            }
        }

        public static void Validate(DailyWeatherForecast forecast)
        {
            ArgumentNullException.ThrowIfNull(forecast);
            if (forecast.Date > DateTime.Now.DateAfterWeekFromNow())
            {
                throw new WeatherForecastDateOutOfRangeException(WeatherServiceMessages.OutOfAllowedRange);
            }
            ValidateHours(forecast);
        }

        private static void ValidateHours(DailyWeatherForecast forecast)
        {
            if (forecast.HourlyWeatherForecasts == null)
            {
                throw new MissingHourlyDataForDayException(WeatherServiceMessages.MissingHourlyData);
            }
            if (forecast.HourlyWeatherForecasts?.Count != 24)
            {
                throw new IncompleteHourlyWeatherForecastException(WeatherServiceMessages.IncompleteHourlyData);
            }
            if (forecast.HourlyWeatherForecasts.Any(x => x.Hour > new TimeOnly(23, 0) || x.Hour < new TimeOnly(0, 0)))
            {
                throw new InvalidHourlyWeatherForecastTimeException(WeatherServiceMessages.InvalidTime);
            }
            if (!HasAllHoursInDay(forecast))
            {
                throw new MissingHourlyDataException(WeatherServiceMessages.AtLeastOneHourlyForecastHasNotBeenAdded);
            }
        }

        private static bool HasAllHoursInDay(DailyWeatherForecast forecast)
        {

            IEnumerable<TimeOnly> allHoursInDay = Enumerable.Range(0, 24).Select(hour => new TimeOnly(hour, 0));

            var forecastHours = forecast.HourlyWeatherForecasts?.Select(forecast => forecast.Hour);

            return allHoursInDay.All(hour => forecastHours.Contains(hour));
        }
    }
}
