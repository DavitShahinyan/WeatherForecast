using AutoMapper;
using Hangfire;
using Microsoft.AspNetCore.Mvc;
using WeatherForecast.Domain.Entities;
using WeatherForecast.Domain.Infrastructure.ServiceInterfaces;
using WeatherForecast.DTO;

namespace WeatherForecast.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ForecastController : ControllerBase
    {
        private readonly IDailyWeatherForecastService _weatherForecastService;
        private readonly IMapper _mapper;
        public ForecastController(IDailyWeatherForecastService dailyWeatherForecastService, IMapper mapper)
        {
            _weatherForecastService = dailyWeatherForecastService;
            _mapper = mapper;
        }

        [HttpGet("WeeklyForecast")]
        public IActionResult GetWeeklyForecast([FromQuery] WeatherForecastSearchModel searchModel)
        {
            return Ok(_mapper.Map<List<DailyWeatherForecast>>(_weatherForecastService.GetWeeklyForecast(searchModel.CountryName, searchModel.CityName)));
        }

        [HttpPost("AddWeeklyForecast")]
        public IActionResult AddUpcomingWeekForecast([FromBody] IEnumerable<DailyWeatherForecast> forecasts)
        {
            _weatherForecastService.AddWeeklyForecast(forecasts);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateForecast([FromBody] DailyWeatherForecast forecast)
        {
            _weatherForecastService.Update(forecast);
            return Ok();
        }

        [HttpPost("AddOneDayForecast")]
        public IActionResult Add([FromBody] DailyWeatherForecast dailyWeatherForecast)
        {
            _weatherForecastService.AddDailyForecast(dailyWeatherForecast);
            return Ok();
        }
        [HttpDelete]
        public IActionResult Add(int id)
        {
            _weatherForecastService.Delete(id);
            return Ok();
        }
        [HttpGet("GetWarmestDayFrom")]
        public IActionResult GetWarmestDayFrom([FromQuery] WarmestDaySearchModel searchModel)
        {
            return Ok(_mapper.Map<DailyWeatherForecast>(_weatherForecastService.GetWarmestDayFrom(searchModel.CountryName, searchModel.CityName, searchModel.Date)));
        }
    }
}
