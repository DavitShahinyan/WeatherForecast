using AutoMapper;
using WeatherForecast.Domain.Entities;
using WeatherForecast.DTO;

namespace WeatherForecast.Mapper
{
    public class EntityToDTOMappingProfile : Profile
    {
        public EntityToDTOMappingProfile()
        {
            CreateMap<Country, CountryDTO>().ReverseMap();
            CreateMap<DailyWeatherForecast, DailyWeatherForecastDTO>().ReverseMap();
        }
    }
}
