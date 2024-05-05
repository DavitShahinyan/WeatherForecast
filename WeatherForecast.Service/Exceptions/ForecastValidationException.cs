namespace WeatherForecast.Service.Exceptions
{
    public class ForecastValidationException : Exception
    {
        public ForecastValidationException() { }
        public ForecastValidationException(string message) : base(message)
        {
        }

        public ForecastValidationException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
