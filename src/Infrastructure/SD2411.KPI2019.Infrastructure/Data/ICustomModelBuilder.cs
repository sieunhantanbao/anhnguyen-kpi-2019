using Microsoft.EntityFrameworkCore;

namespace SD2411.KPI2019.Infrastructure.Data
{
    public interface ICustomModelBuilder
    {
        void Build(ModelBuilder modelBuilder);
    }
}
