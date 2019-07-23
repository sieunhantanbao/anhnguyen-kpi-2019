using Microsoft.EntityFrameworkCore.Storage;
using SD2411.KPI2019.Infrastructure.Model.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SD2411.KPI2019.Infrastructure.Data
{
    public interface IRepositoryWithTypedId <T, TId> where T: IEntityWithTypeId<TId>
    {
        IQueryable<T> Query();

        void Add(T entity);

        void AddRange(IEnumerable<T> entity);

        IDbContextTransaction BeginTransaction();

        void SaveChanges();

        Task SaveChangesAsync();

        void Remove(T entity);
    }
}
