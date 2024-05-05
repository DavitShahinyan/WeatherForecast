using WeatherForecast.Domain.Infrastructure.EntityAbstractions;

namespace WeatherForecast.Domain.Infrastructure.ServiceAbstraction
{
    public interface IServiceBase<TEntity> where TEntity : EntityBase, new()
    {
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
        TEntity AddDailyForecast(TEntity entity);
        IEnumerable<TEntity> AddWeeklyForecast(IEnumerable<TEntity> entities);
        TEntity Update(TEntity entity);
        void Delete(int id);
    }
}
