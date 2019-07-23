using System;
using System.Collections.Generic;
using System.Text;

namespace SD2411.KPI2019.Infrastructure.Model.Entity
{
    public interface IEntityWithTypeId<TId>
    {
        TId Id { get;}
    }
}
