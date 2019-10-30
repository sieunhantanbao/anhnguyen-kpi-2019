using System;
using System.Collections.Generic;
using System.Text;

namespace SD2411.KPI2019.Infrastructure.Model.Entity
{
    public interface IEntityWithTypedId<TId>
    {
        TId Id { get; set; }
        string Slug { get; set; }
    }
}
