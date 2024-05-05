using WeatherForecast.Domain.Entities;
using WeatherForecast.Domain.Infrastructure.ServiceAbstraction;

namespace WeatherForecast.Domain.Infrastructure.ServiceInterfaces
{
    public interface ILocationService : IServiceBase<Country>
    {

    }
}
