using Domain.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstracts.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity, new()
    {
        Task<int> AddAsync(TEntity entity);
        Task<int> AddAsync(IEnumerable<TEntity> entities);
        int Add(TEntity entity);
        int Add(IEnumerable<TEntity> entities);

        Task<int> UpdateAsync(TEntity entity);
        int Update(TEntity entity);

        Task<int> DeleteAsync(Guid id);
        Task<int> DeleteAsync(TEntity identity);
        int Delete(Guid id);
        int Delete(TEntity identity);
        bool DeleteRange(Expression<Func<TEntity, bool>> predicate);
        Task<bool> DeleteRangeAsync(Expression<Func<TEntity, bool>> predicate);

        Task<int> SoftDeleteAsync(Guid id);
        Task<int> SoftDeleteAsync(TEntity identity);
        int SoftDelete(Guid id);
        int SoftDelete(TEntity identity);
        bool SoftDeleteRange(Expression<Func<TEntity, bool>> predicate);
        Task<bool> SoftDeleteRangeAsync(Expression<Func<TEntity, bool>> predicate);

        Task<int> AddOrUpdateAsync(TEntity entity);
        int AddOrUpdate(TEntity entity);

        Task<TEntity> FindAsync(Guid id);
        Task<List<TEntity>> GetAll(bool noTracking = false);
        Task<List<TEntity>> GetList(Expression<Func<TEntity, bool>> predicate, bool noTracking = false, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, params Expression<Func<TEntity, object>>[] includes);
        Task<TEntity> GetByIdAsync(Guid id, bool noTracking = true, params Expression<Func<TEntity, object>>[] include);
        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate, bool noTracking = true, params Expression<Func<TEntity, object>>[] includes);
        Task<IQueryable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate, bool noTracking = true, params Expression<Func<TEntity, object>>[] includes);
        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, bool noTracking = true, params Expression<Func<TEntity, object>>[] includes);
        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, bool noTracking = true, params Expression<Func<TEntity, object>>[] includes);
        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate, bool noTracking = true, params Expression<Func<TEntity, object>>[] includes);
        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate, bool noTracking = true, params Expression<Func<TEntity, object>>[] includes);

        int SaveChange();
        Task<int> SaveChangeAsync();

        IQueryable<TEntity> AsQueryable();
    }
}
