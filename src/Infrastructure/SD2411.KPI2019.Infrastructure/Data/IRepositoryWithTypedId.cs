using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Storage;
using SD2411.KPI2019.Infrastructure.Model;
using SD2411.KPI2019.Infrastructure.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SD2411.KPI2019.Infrastructure.Data
{
    public interface IRepositoryWithTypedId <T, TId> where T: IEntityWithTypedId<TId>
    {
        IQueryable<T> Query();

        Task<T> AddAsync(T entity);

        Task AddRangeAsync(IEnumerable<T> entities);

        void Remove(T entity);

        Task<bool> AnyAsync(Expression<Func<T, bool>> filter, Func<IQueryable<T>, IIncludableQueryable<T, object>> includeProperties = null);

        Task<T> FindAsync(Expression<Func<T, bool>> filter, Func<IQueryable<T>, IIncludableQueryable<T, object>> includeProperties = null);

        Task<T> FindByIdAsync(TId id, Func<IQueryable<T>, IIncludableQueryable<T, object>> includeProperties = null);

        Task<IEnumerable<T>> ListAsync(Expression<Func<T, bool>> filter, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy, Func<IQueryable<T>, IIncludableQueryable<T, object>> includesProperties = null);

        Task<PaginatedItems<T, TId>> ListAsync(int pageIndex, int pageSize ,Expression<Func<T, bool>> filter, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy, Func<IQueryable<T>, IIncludableQueryable<T, object>> includesProperties = null);

        void SetState(T entity, EntityState state);

        Task<IDbContextTransaction> BeginTransactionAsync();

        Task SaveChangesAsync();
    }
}
