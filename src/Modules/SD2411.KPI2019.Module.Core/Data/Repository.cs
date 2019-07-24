using SD2411.KPI2019.Infrastructure.Data;
using SD2411.KPI2019.Infrastructure.Model.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SD2411.KPI2019.Module.Core.Data
{
    public class Repository<T> : RepositoryWithTypeId<T, int>, IRepository<T>
        where T : class, IEntityWithTypedId<int>
    {
        public Repository(SD2411DBContext context) : base(context)
        {

        }
    }
}
