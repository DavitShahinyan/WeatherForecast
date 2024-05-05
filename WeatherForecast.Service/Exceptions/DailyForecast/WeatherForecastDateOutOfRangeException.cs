namespace WeatherForecast.Service.Exceptions.DailyForecast
{
    public class WeatherForecastDateOutOfRangeException : ForecastValidationException
    {
        public WeatherForecastDateOutOfRangeException(string message) : base(message) { }
        public WeatherForecastDateOutOfRangeException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
