using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WeatherForecast.Domain.Entities;
using WeatherForecast.Domain.Infrastructure.ServiceInterfaces;

namespace WeatherForecast.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILocationService _locationService;
        private readonly IMapper _mapper;

        public LocationController(ILocationService countryService, IMapper mapper)
        {
            _locationService = countryService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_mapper.Map<List<Country>>(_locationService.GetAll()));
        }

        [HttpPost]
        public IActionResult Add([FromBody] Country country)
        {
            _locationService.AddDailyForecast(country);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update([FromBody] Country country)
        {
            _locationService.Update(country);
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _locationService.Delete(id);
            return Ok();
        }
    }
}
