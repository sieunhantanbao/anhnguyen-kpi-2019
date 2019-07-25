using SD2411.KPI2019.Infrastructure.Model.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SD2411.KPI2019.Infrastructure.Model
{
    public class PaginatedItems<T, TId> where T : IEntityWithTypedId<TId>
    {
        public PaginatedItems(int pageIndex, int pageSize, long count, IEnumerable<T> data)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            Count = count;
            Data = data;
        }
        public int PageIndex { get; }
        public int PageSize { get; }
        public long Count { get; }
        public IEnumerable<T> Data { get; }
    }
}
