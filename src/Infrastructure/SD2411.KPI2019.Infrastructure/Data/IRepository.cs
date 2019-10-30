using SD2411.KPI2019.Infrastructure.Model.Entity;
using System.Threading.Tasks;

namespace SD2411.KPI2019.Infrastructure.Data
{
    public interface IRepository <T>: IRepositoryWithTypedId <T, int> where T: IEntityWithTypedId<int>
    {
        Task<string> SafeToSlug(string slug, int entityId);
    }
}
