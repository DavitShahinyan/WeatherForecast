using WeatherForecast.Service.Exceptions;
using WeatherForecast.Service.Exceptions.HourlyForecast;

public class IncompleteHourlyWeatherForecastException : ForecastValidationException
{
    public IncompleteHourlyWeatherForecastException() { }

    public IncompleteHourlyWeatherForecastException(string message) : base(message) { }

    public IncompleteHourlyWeatherForecastException(string message, Exception innerException) : base(message, innerException) { }
}