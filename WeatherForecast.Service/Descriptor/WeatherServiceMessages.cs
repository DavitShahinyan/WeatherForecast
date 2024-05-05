namespace WeatherForecast.Service.Descriptor
{
    public static class WeatherServiceMessages
    {
        #region Daily Forecast Validation Messages
        public const string OutOfAllowedRange = "Exceeding the maximum allowed forecast date range.";
        public const string OnlySevenElements = "The list must contain exactly 7 elements.";
        public const string DifferentCities = "One or more elements in the list have a different city.";
        #endregion

        #region Hourly Forecast Validation Messages
        public const string AtLeastOneHourlyForecastHasNotBeenAdded = "Hourly weather forecast data is missing for a specific hour.";
        public const string IncompleteHourlyData = "Hourly weather forecast data is incomplete for 24 hours.";
        public const string InvalidTime = "The time in the weather forecast is outside the allowed range (0:00 - 23:00).";
        public const string MissingHourlyData = "Weather forecast data is missing for all hours of the day.";
        #endregion
    }
}
