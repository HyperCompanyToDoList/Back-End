using System.Linq.Expressions;

namespace Emr.Common
{
    public interface IRepositoryBase<TEntity, TKey>
        where TEntity : IEntity<TKey>
        where TKey : struct
    {
        Task<TEntity> GetAsync(TKey id);
        Task<IQueryable<TEntity>> GetAll();
        Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> AddAsync(TEntity entity, bool autoSave = false);
        Task AddManyAsync(IEnumerable<TEntity> entities, bool autoSave = false);
        Task Remove(TEntity entity, bool autoSave = false);
        Task RemoveMany(IEnumerable<TEntity> entities, bool autoSave = false);
        Task<TEntity> UpdateAsync(TEntity entity, bool autoSave = false);
        Task UpdateManyAsync(IEnumerable<TEntity> entities, bool autoSave = false);
        Task Save();
    }
}
