using Microsoft.EntityFrameworkCore;
using SD2411.KPI2019.Infrastructure.Data;
using SD2411.KPI2019.Module.Books.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SD2411.KPI2019.Module.Books.Data
{
    public class BookCustomModelBuilder : ICustomModelBuilder
    {
        public void Build(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<Book>();

            entity.ToTable("tbl_book");
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Id).HasColumnName("ID").ValueGeneratedOnAdd();
            entity.Property(c => c.Name).HasColumnName("NAME");
            entity.Property(c => c.Description).HasColumnName("DESCRIPTION");
            entity.Property(c => c.PublishedDate).HasColumnName("PUBLISHED_DATE");
            entity.Property(c => c.Available2Lend).HasColumnName("IS_AVAILABLE_TO_LEND");
            entity.Property(c => c.Available2Lend).HasColumnName("IS_AVAILABLE_TO_LEND");
            entity.Property(c => c.Author).HasColumnName("AUTHOR");
            entity.Property(c => c.ISBN).HasColumnName("ISBN");
            entity.Property(c => c.ISBN13).HasColumnName("ISBN13");
            entity.Property(c => c.Language).HasColumnName("LANGUAGE");
            entity.Property(c => c.Length).HasColumnName("LENGTH");
            entity.Property(c => c.Weight).HasColumnName("WEIGHT");
            entity.Property(c => c.Dimensions).HasColumnName("DIMENSIONS");
            entity.Property(c => c.ImageUrl).HasColumnName("IMAGE_URL");

            entity.HasOne(c => c.BookCategory)
                  .WithMany(c => c.Books).HasConstraintName("FK_BOOK_CATEGORY");

            // Initial simple data
            entity.HasData(BookSeedData.Data());
        }
    }
}
