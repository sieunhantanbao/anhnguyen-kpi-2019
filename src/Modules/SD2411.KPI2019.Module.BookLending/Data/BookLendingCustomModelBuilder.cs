using Microsoft.EntityFrameworkCore;
using SD2411.KPI2019.Infrastructure.Data;
using BookLendingEntity = SD2411.KPI2019.Module.BookLending.Model.BookLending;

namespace SD2411.KPI2019.Module.BookLending.Data
{
    public class BookLendingCustomModelBuilder : ICustomModelBuilder
    {
        public void Build(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<BookLendingEntity>();
            entity.ToTable("tbl_book_lending");
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Slug).HasColumnName("SLUG");
            entity.Property(c => c.Id).HasColumnName("ID").ValueGeneratedOnAdd();
            entity.Property(c => c.BorrowDate).HasColumnName("BORROW_DATE");
            entity.Property(c => c.ReturnDate).HasColumnName("RETURN_DATE");

            // entity.HasData(BookLendingSeedData.Data());
        }
    }
}
