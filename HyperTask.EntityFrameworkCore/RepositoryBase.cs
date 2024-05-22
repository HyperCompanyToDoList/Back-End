using Emr.Common;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HyperTask.EntityFrameworkCore
{
    public abstract class RepositoryBase<TEntity, TKey> : IRepositoryBase<TEntity, TKey>
    where TKey : struct
    where TEntity : class, IEntity<TKey>
    {
        HyperTaskDbContext _context;
        protected RepositoryBase(HyperTaskDbContext context)
        {
            _context = context;
        }
        public async Task<TEntity> AddAsync(TEntity entity, bool autoSave = false)
        {
            _context.Add(entity);

            if (autoSave)
            {
                await _context.SaveChangesAsync();
            }

            return entity;
        }

        public async Task AddManyAsync(IEnumerable<TEntity> entities, bool autoSave = false)
        {
            _context.AddRange(entities);

            if (autoSave) { await _context.SaveChangesAsync(); }

        }

        public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Set<TEntity>().Where(predicate);
        }

        public async Task<IQueryable<TEntity>> GetAll()
        {
            return _context.Set<TEntity>().AsQueryable();
        }

        public async Task<TEntity> GetAsync(TKey id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public async Task Remove(TEntity entity, bool autoSave = false)
        {
            _context.Remove(entity);
            if (autoSave) await _context.SaveChangesAsync();
        }

        public async Task RemoveMany(IEnumerable<TEntity> entities, bool autoSave = false)
        {
            _context.RemoveRange(entities);
            if (autoSave) await _context.SaveChangesAsync();
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _context.Set<TEntity>().FirstOrDefaultAsync(predicate);
        }

        public async Task<TEntity> UpdateAsync(TEntity entity, bool autoSave = false)
        {
            _context.Update(entity);
            if (autoSave) await _context.SaveChangesAsync();

            return entity;
        }

        public async Task UpdateManyAsync(IEnumerable<TEntity> entities, bool autoSave = false)
        {
            _context.UpdateRange(entities);
            if (autoSave) await _context.SaveChangesAsync();
        }
    }
}
