using Microsoft.EntityFrameworkCore;
using SD2411.KPI2019.Infrastructure.Data;
using SD2411.KPI2019.Module.Books.Model;

namespace SD2411.KPI2019.Module.Books.Data
{
    public class BookCategoryCustomModelBuilder : ICustomModelBuilder
    {
        public void Build(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<BookCategory>();
            entity.ToTable("tbl_book_category");
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Id).HasColumnName("ID").ValueGeneratedOnAdd();
            entity.Property(c => c.Name).HasColumnName("NAME");
            entity.Property(c => c.Description).HasColumnName("DESCRIPTION");
            // Add seed data
            entity.HasData(BookCaterorySeedData.Data());
        }
    }
}
