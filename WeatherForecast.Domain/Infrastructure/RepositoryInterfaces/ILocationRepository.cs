using WeatherForecast.Domain.Entities;
using WeatherForecast.Domain.Infrastructure.RepositoryAbstraction;

namespace WeatherForecast.Domain.Infrastructure.RepositoryInterfaces
{
    public interface ILocationRepository : IRepositoryBase<Country>
    {
        Country GetCountryByName(string name);
    }
}
