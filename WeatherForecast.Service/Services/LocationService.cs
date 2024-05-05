using WeatherForecast.Domain.Entities;
using WeatherForecast.Domain.Infrastructure.RepositoryInterfaces;
using WeatherForecast.Domain.Infrastructure.ServiceInterfaces;

namespace WeatherForecast.Service.Services
{
    public class LocationService : ServiceBase<Country>, ILocationService
    {
        public LocationService(ILocationRepository repository) : base(repository) { }
        public override Country Update(Country country)
        {
            Country countryToUpdate = null;
            if (country != null)
            {
                countryToUpdate = _repository.GetByIdWithInclude(country.Id, x => x.Cities);
            }

            if (countryToUpdate != null)
            {
                countryToUpdate.Name = country.Name;

                var citiesToRemove = countryToUpdate.Cities
                    .Where(city => country.Cities == null || !country.Cities.Select(x => x.Id).Contains(city.Id))
                    .ToList();

                foreach (var cityToRemove in citiesToRemove)
                {
                    countryToUpdate.Cities.Remove(cityToRemove);
                }

                if (country.Cities != null)
                {
                    foreach (var newCity in country.Cities)
                    {
                        var existingCity = countryToUpdate.Cities.FirstOrDefault(c => c.Id == newCity.Id);
                        if (existingCity == null)
                        {
                            countryToUpdate.Cities.Add(newCity);
                        }
                        else
                        {
                            existingCity.Name = newCity.Name;
                        }
                    }
                }
            }

            return base.Update(countryToUpdate);
        }

        public override IEnumerable<Country> GetAll()
        {
            return _repository.GetWithInclude(x => x.Cities);
        }
    }
}
