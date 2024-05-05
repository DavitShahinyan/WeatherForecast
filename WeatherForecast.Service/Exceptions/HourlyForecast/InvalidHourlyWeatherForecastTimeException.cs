using WeatherForecast.Service.Exceptions;

public class InvalidHourlyWeatherForecastTimeException : ForecastValidationException
{
    public InvalidHourlyWeatherForecastTimeException() { }

    public InvalidHourlyWeatherForecastTimeException(string message) : base(message) { }

    public InvalidHourlyWeatherForecastTimeException(string message, Exception innerException) : base(message, innerException) { }
}