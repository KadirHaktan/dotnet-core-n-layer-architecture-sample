using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.Entity;

namespace Core.Repository
{
    public interface IRepository<TEntity> where TEntity:class,IEntity
    {
        IQueryable<TEntity> Table { get; }

        IQueryable<TEntity> TableNoTracking { get; }

        TEntity GetById(int id);

        List<TEntity> GetAll();
        Task<TEntity> GetByIdAsync(int id);

        Task<IList<TEntity>> GetAllAsync();

        Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate);

        Task<TEntity> GetSingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);

        Task AddAsync(TEntity entity);

        Task AddRangeAsync(IEnumerable<TEntity> entities);

        void Add(TEntity entity);

        void AddRange(IEnumerable<TEntity> entities);

        void Remove(TEntity entity);

        void RemoveRange(IEnumerable<TEntity> entities);

        TEntity Update(TEntity entity);

        IQueryable<TEntity> IncludeMany(params Expression<Func<TEntity, object>>[] includes);

        IEnumerable<TEntity> GetSql(string sql);

        Task<TEntity> InsertAsync(TEntity entity);
        TEntity Insert(TEntity entity);

        Task<TEntity> RemoveByIdAsync(int id);
        TEntity RemoveById(int id);

        TEntity UpdateOptional(TEntity entity);
    }
}
