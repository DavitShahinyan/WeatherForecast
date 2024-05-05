using System.Linq.Expressions;
using WeatherForecast.Domain.Infrastructure.EntityAbstractions;

namespace WeatherForecast.Domain.Infrastructure.RepositoryAbstraction
{
    public interface IRepositoryBase<TEntity> where TEntity : EntityBase
    {
        TEntity GetById(int id);
        TEntity GetByIdWithInclude(int id, params Expression<Func<TEntity, object>>[] includeProperties);
        IEnumerable<TEntity> GetWithWhere(Expression<Func<TEntity, bool>> whereProperties);
        IEnumerable<TEntity> GetWithInclude(params Expression<Func<TEntity, object>>[] includeProperties);
        IEnumerable<TEntity> GetWithIncludeWhere(Expression<Func<TEntity, bool>> whereProperties, params Expression<Func<TEntity, object>>[] includeProperties);
        IEnumerable<TEntity> GetAll();
        TEntity Add(TEntity entity);
        IEnumerable<TEntity> AddRange(IEnumerable<TEntity> entities);
        TEntity Update(TEntity entity);
        void Delete(TEntity entity);
        void DeleteWhere(Expression<Func<TEntity, bool>> whereProperties);
    }
}
