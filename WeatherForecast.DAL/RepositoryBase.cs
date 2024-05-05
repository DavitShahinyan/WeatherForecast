using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;
using WeatherForecast.Domain.Infrastructure.EntityAbstractions;
using WeatherForecast.Domain.Infrastructure.RepositoryAbstraction;

namespace WeatherForecast.DAL
{
    public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : EntityBaseWithId, new()
    {
        protected readonly WeatherForecastDbContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        public RepositoryBase(WeatherForecastDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }
        public virtual TEntity GetById(int id)
        {
            return _dbSet.Find(id);
        }
        public virtual IEnumerable<TEntity> GetAll()
        {
            return _dbSet;
        }
        public virtual IEnumerable<TEntity> GetWithWhere(Expression<Func<TEntity, bool>> whereProperties)
        {
            return ApplyWhere(_dbSet, whereProperties).ToList();
        }
        public virtual IEnumerable<TEntity> GetWithInclude(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return ApplyInclude(_dbSet, includeProperties).ToList();
        }
        public virtual TEntity GetByIdWithInclude(int id, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return ApplyInclude(_dbSet, includeProperties).SingleOrDefault(x => x.Id == id);
        }
        public virtual TEntity Add(TEntity entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
            return entity;
        }
        public virtual IEnumerable<TEntity> AddRange(IEnumerable<TEntity> entities)
        {
            _dbSet.AddRange(entities);
            _context.SaveChanges();
            return entities;
        }
        public virtual TEntity Update(TEntity entity)
        {
            _context.Set<TEntity>().Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
            return entity;
        }
        public virtual void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
            _context.SaveChanges();
        }
        public virtual void DeleteWhere(Expression<Func<TEntity, bool>> whereProperties)
        {
            if(whereProperties != null)
            {
                var entities = _dbSet.Where(whereProperties);

                foreach (var entity in entities)
                {
                    _dbSet.Entry(entity).State = EntityState.Deleted;
                }
                _context.SaveChanges();
            }
        }
        public virtual IEnumerable<TEntity> GetWithIncludeWhere(Expression<Func<TEntity, bool>> whereProperties, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var result = ApplyInclude(_dbSet, includeProperties);
            result = ApplyWhere(result, whereProperties);
            return result.ToList();
        }
        private IQueryable<TEntity> ApplyInclude(IQueryable<TEntity> query, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }
        private IQueryable<TEntity> ApplyWhere(IQueryable<TEntity> query, Expression<Func<TEntity, bool>> whereProperties)
        {
            if (whereProperties != null)
            {
                query = query.Where(whereProperties);
            }
            return query;
        }

    }
}
