namespace WeatherForecast.Service.Descriptor
{
    public static class DateExtensions
    {
        public static DateOnly DateAfterWeekFromNow(this DateTime date)
        {
            return DateOnly.FromDateTime(DateTime.Now).AddDays(7);
        }
    }
}
