using SD2411.KPI2019.Infrastructure.Model.Entity;

namespace SD2411.KPI2019.Infrastructure.Data
{
    public interface IRepository <T>: IRepositoryWithTypedId <T, int> where T: IEntityWithTypedId<int>
    {
    }
}
