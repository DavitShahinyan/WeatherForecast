using WeatherForecast.Domain.Infrastructure.EntityAbstractions;
using WeatherForecast.Domain.Infrastructure.RepositoryAbstraction;
using WeatherForecast.Domain.Infrastructure.ServiceAbstraction;
using WeatherForecast.Service.Descriptor;
using WeatherForecast.Service.Exceptions.CommonExceptions;

namespace WeatherForecast.Service
{
    public abstract class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : EntityBase, new()
    {
        protected readonly IRepositoryBase<TEntity> _repository;

        public ServiceBase(IRepositoryBase<TEntity> repository)
        {
            _repository = repository;
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public virtual TEntity GetById(int id)
        {
            return _repository.GetById(id);
        }

        public virtual TEntity AddDailyForecast(TEntity entity)
        {
            return _repository.Add(entity);
        }

        public virtual IEnumerable<TEntity> AddWeeklyForecast(IEnumerable<TEntity> entities)
        {
            return _repository.AddRange(entities);
        }

        public virtual TEntity Update(TEntity entity)
        {
            return _repository.Update(entity);
        }

        public virtual void Delete(int id)
        {
            if (_repository.GetById(id) is TEntity entity)
            {
                _repository.Delete(entity);
            }
            else
            {
                throw new NotFoundException(CommonMessages.CannotFind);
            }
        }
    }
}
