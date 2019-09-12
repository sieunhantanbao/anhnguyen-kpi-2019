using SD2411.KPI2019.Infrastructure.Data;
using SD2411.KPI2019.Infrastructure.Model.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SD2411.KPI2019.Module.Core.Data
{
    public class Repository<T> : RepositoryWithTypeId<T, int>, IRepository<T>
        where T : class, IEntityWithTypedId<int>
    {
        public Repository(SD2411DBContext context) : base(context)
        {

        }

        public async Task<string> SafeToSlug(string slug, int entityId)
        {
            var i = 2;
            while (true)
            {
                var entity = await FindAsync(x => x.Slug == slug);
                if (entity != null && !(entity.Id == entityId))
                {
                    slug = string.Format("{0}-{1}", slug, i);
                    i++;
                }
                else
                {
                    break;
                }
            }

            return slug;
        }
    }
}
