using WeatherForecast.Service.Exceptions;

public class MissingHourlyDataException : ForecastValidationException
{
    public MissingHourlyDataException() { }

    public MissingHourlyDataException(string message) : base(message) { }

    public MissingHourlyDataException(string message, Exception innerException) : base(message, innerException) { }
}