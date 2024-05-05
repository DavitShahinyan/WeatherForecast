using WeatherForecast.Domain.Entities;
using WeatherForecast.Domain.Infrastructure.RepositoryInterfaces;

namespace WeatherForecast.DAL.Repositories
{
    public class CountryRepository : RepositoryBase<Country>, ILocationRepository
    {
        public CountryRepository(WeatherForecastDbContext context) : base(context) { }

        public Country GetCountryByName(string name)
        {
            return _dbSet.First(x => x.Name == name);
        }
    }
}
