namespace WeatherForecast.Service.Exceptions.DailyForecast
{
    public class InvalidForecastCountException : ForecastValidationException
    {
        public InvalidForecastCountException(string message) : base(message)
        {
        }

        public InvalidForecastCountException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
