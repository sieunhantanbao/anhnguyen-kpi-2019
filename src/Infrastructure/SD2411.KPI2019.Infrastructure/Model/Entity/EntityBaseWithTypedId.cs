using System;
using System.Collections.Generic;
using System.Text;

namespace SD2411.KPI2019.Infrastructure.Model.Entity
{
    public abstract class EntityBaseWithTypedId<TId> : ValidableObject, IEntityWithTypedId<TId>
    {
        public virtual TId Id { get; set; }
    }
}
