namespace WeatherForecast.Service.Exceptions.DailyForecast
{
    public class DifferentCitiesInListException : ForecastValidationException
    {
        public DifferentCitiesInListException(string message) : base(message)
        {
        }

        public DifferentCitiesInListException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
