using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Storage;
using SD2411.KPI2019.Infrastructure.Data;
using SD2411.KPI2019.Infrastructure.Extensions;
using SD2411.KPI2019.Infrastructure.Model;
using SD2411.KPI2019.Infrastructure.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SD2411.KPI2019.Module.Core.Data
{
    public class RepositoryWithTypeId<T, TId> : IRepositoryWithTypedId<T, TId> where T : class, IEntityWithTypedId<TId>
    {
        public RepositoryWithTypeId(SD2411DBContext context)
        {
            Context = context;
            DbSet = Context.Set<T>();
        }
        protected DbContext Context { get; }

        protected DbSet<T> DbSet { get; }
        /// <summary>
        /// Add Entity Async
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual async Task<T> AddAsync(T entity)
        {
            await DbSet.AddAsync(entity);
            return entity;
        }
        /// <summary>
        /// Add a list of Entity Async
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual async Task AddRangeAsync(IEnumerable<T> entity)
        {
            await DbSet.AddRangeAsync(entity);
        }
        /// <summary>
        /// Any Entity Async
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        public virtual async Task<bool> AnyAsync(Expression<Func<T, bool>> filter, Func<IQueryable<T>, IIncludableQueryable<T, object>> includeProperties = null)
        {
            var query = DbSet.AsNoTracking();
            if (includeProperties != null)
            {
                query = includeProperties(query);
            }
            if (filter != null)
            {
                return await query.AnyAsync(filter);
            }
            return await query.AnyAsync();
        }
        /// <summary>
        /// Begin Transaction
        /// </summary>
        /// <returns></returns>
        public virtual async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return await Context.Database.BeginTransactionAsync();
        }
        /// <summary>
        /// Find Entity Async
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        public virtual async Task<T> FindAsync(Expression<Func<T, bool>> filter, Func<IQueryable<T>, IIncludableQueryable<T, object>> includeProperties = null)
        {
            var query = DbSet.AsNoTracking();
            if (includeProperties != null)
            {
                query = includeProperties(query);
            }
            if (filter != null)
            {
                return await DbSet.FindAsync(query);
            }
            return await DbSet.FindAsync();
        }
        /// <summary>
        /// Find Entity by Id Async
        /// </summary>
        /// <param name="id"></param>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        public virtual async Task<T> FindByIdAsync(TId id, Func<IQueryable<T>, IIncludableQueryable<T, object>> includeProperties = null)
        {
            var query = DbSet.AsNoTracking();
            if (includeProperties != null)
            {
                query = includeProperties(query);
            }
            return await query.FirstOrDefaultAsync(c => c.Id.Equals(id));
        }
        /// <summary>
        /// List Entities async
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="orderBy"></param>
        /// <param name="includesProperties"></param>
        /// <returns></returns>
        public virtual async Task<IEnumerable<T>> ListAsync(Expression<Func<T, bool>> filter, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy, Func<IQueryable<T>, IIncludableQueryable<T, object>> includesProperties = null)
        {
            var query = DbSet.AsNoTracking();
            if (includesProperties != null)
            {
                query = includesProperties(query);
            }
            if (filter != null)
            {
                query = query.Where(filter);   
            }
            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync();
            }
            return await query.ToListAsync();
        }
        /// <summary>
        /// List Entities Async with paging
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="filter"></param>
        /// <param name="orderBy"></param>
        /// <param name="includesProperties"></param>
        /// <returns></returns>
        public virtual async Task<PaginatedItems<T, TId>> ListAsync(int pageIndex, int pageSize, Expression<Func<T, bool>> filter, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy, Func<IQueryable<T>, IIncludableQueryable<T, object>> includesProperties = null)
        {
            List<T> result;
            var query = DbSet.AsNoTracking();
            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includesProperties != null)
            {
                query = includesProperties(query);
            }

            var entityCount = query.Count();

            if (orderBy != null)
            {
                result = await orderBy(query).Paginate(pageIndex, pageSize).ToListAsync();
            }
            else
            {
                result = await query.Paginate(pageIndex, pageSize).ToListAsync();
            }
            return new PaginatedItems<T, TId>(pageIndex, pageSize, entityCount, result);
        }
        /// <summary>
        /// Query
        /// </summary>
        /// <returns></returns>
        public virtual IQueryable<T> Query()
        {
            return DbSet;
        }
        /// <summary>
        /// Remove entity
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Remove(T entity)
        {
            DbSet.Remove(entity);
        }
        /// <summary>
        /// Save change
        /// </summary>
        /// <returns></returns>
        public virtual async Task SaveChangesAsync()
        {
            await Context.SaveChangesAsync();
        }
        /// <summary>
        /// Set Entity State
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="state"></param>
        public virtual void SetState(T entity, EntityState state)
        {
            Context.Entry(entity).State = state;
        }
    }
}
