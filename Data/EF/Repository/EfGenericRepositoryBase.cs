using Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Entity;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Core.Extensions.Data;
using Microsoft.EntityFrameworkCore;

namespace Data.EF.Repository
{
    public class EfGenericRepositoryBase<TEntity,TContext> : IRepository<TEntity> where TEntity : class, IEntity
    where TContext:DbContext
    {
        private readonly TContext _context;
        private DbSet<TEntity> _dbSet;


        public EfGenericRepositoryBase(TContext context)
        {
            this._context = context;
            _dbSet = context.Set<TEntity>();
        }

        protected virtual DbSet<TEntity> Entities => _dbSet ?? (_dbSet = _context.Set<TEntity>());
        public virtual IQueryable<TEntity> Table => _dbSet;

        public virtual IQueryable<TEntity> TableNoTracking => _dbSet.AsNoTracking();

        public void Add(TEntity entity)
        {
            Entities.Add(entity);
        }

        public async Task AddAsync(TEntity entity)
        {
            await Entities.AddAsync(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            Entities.AddRange(entities);
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await Entities.AddRangeAsync(entities);
            
        }

        public async Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return await Entities.Where(predicate).ToListAsync();
        }

        public async Task<IList<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public virtual TEntity GetById(int id)
        {
            return Entities.Find(id);
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<TEntity> GetSingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.FirstOrDefaultAsync(predicate);
        }

        public IEnumerable<TEntity> GetSql(string sql)
        {
            return Entities.FromSqlRaw(sql);
        }

        public IQueryable<TEntity> IncludeMany(params Expression<Func<TEntity, object>>[] includes)
        {
            return _dbSet.IncludeMultiple(includes);
        }

        public void Remove(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public TEntity Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
            return entity;
        }

        public List<TEntity> GetAll()
        {
            return Entities.ToList();
        }

        public async Task<TEntity> InsertAsync(TEntity entity)
        {
            var result = await Entities.AddAsync(entity);

            await _context.SaveChangesAsync();

            return result.Entity;

        }

        public TEntity Insert(TEntity entity)
        {
            var result = Entities.Add(entity);
            _context.SaveChanges();

            return result.Entity;
        }

        public async Task<TEntity> RemoveByIdAsync(int id)
        {
            var result = await Entities.FindAsync(id);

            var deletedResult=Entities.Remove(result);

            await _context.SaveChangesAsync();

            return deletedResult.Entity;
        }

        public TEntity RemoveById(int id)
        {
            var result = Entities.Find(id);

            var deletedResult = Entities.Remove(result);

           _context.SaveChanges();

            return deletedResult.Entity;
        }
    


        public TEntity UpdateOptional(TEntity entity)
        {
            var deletedResult = Entities.Update(entity);

            _context.SaveChanges();

            return deletedResult.Entity;
        }
    }
}
