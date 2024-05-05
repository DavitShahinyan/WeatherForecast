namespace WeatherForecast.Service.Exceptions.HourlyForecast
{
    public class MissingHourlyDataForDayException : ForecastValidationException
    {
        public MissingHourlyDataForDayException()
        {
        }
        public MissingHourlyDataForDayException(string message) : base(message) { }

        public MissingHourlyDataForDayException(string message, Exception innerException) : base(message, innerException) { }
    }
}
