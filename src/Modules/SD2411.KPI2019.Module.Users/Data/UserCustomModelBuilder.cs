using Microsoft.EntityFrameworkCore;
using SD2411.KPI2019.Infrastructure.Data;
using SD2411.KPI2019.Module.Users.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SD2411.KPI2019.Module.Users.Data
{
    public class UserCustomModelBuilder : ICustomModelBuilder
    {
        public void Build(ModelBuilder modelBuilder)
        {
            var entityTypeBuilder = modelBuilder.Entity<UserAccount>();
            entityTypeBuilder.ToTable("tlb_user");
            entityTypeBuilder.HasKey(c => c.Id);
            entityTypeBuilder.Property(c => c.Id).ValueGeneratedOnAdd();
            entityTypeBuilder.Property(c => c.UserName).HasColumnName("user_name");
        }
    }
}
