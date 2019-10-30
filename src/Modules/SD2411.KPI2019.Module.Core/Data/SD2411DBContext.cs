using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SD2411.KPI2019.Infrastructure;
using SD2411.KPI2019.Infrastructure.Data;
using SD2411.KPI2019.Infrastructure.Model;
using SD2411.KPI2019.Infrastructure.Model.Entity;
using SD2411.KPI2019.Infrastructure.Modules;
using SD2411.KPI2019.Infrastructure.Validation;
using SD2411.KPI2019.Module.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SD2411.KPI2019.Module.Core.Data
{
    public class SD2411DBContext: IdentityDbContext<ApplicationUser>
    {
        public SD2411DBContext(DbContextOptions<SD2411DBContext> options): base(options)
        {

        }
        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            ValidateEntities();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            ValidateEntities();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            List<Type> typesToRegister = new List<Type>();
            foreach (ModuleInfo module in GlobalConfiguration.Modules)
            {
                typesToRegister.AddRange(module.Assembly.DefinedTypes.Select(c => c.AsType()));
            }

            RegisterEntities(modelBuilder, typesToRegister);

            RegisterConvention(modelBuilder);

            base.OnModelCreating(modelBuilder);

            RegisterCustomMapping(modelBuilder, typesToRegister);
        }

        private void ValidateEntities()
        {
            var entitiesToValidate = ChangeTracker.Entries().Where(e => (e.State == EntityState.Added || e.State == EntityState.Modified));
            foreach (var entity in entitiesToValidate)
            {
                if(entity.Entity is ValidableObject validableObject)
                {
                    var validateResults = validableObject.Validate();
                    if (validateResults.Any())
                    {
                        throw new ValidationException(entity.Entity.GetType(), validateResults);
                    }
                }
            }
        }

        private void RegisterEntities(ModelBuilder modelBuilder, IEnumerable<Type> types)
        {
            var entityTypes = types.Where(c => (c.GetTypeInfo().IsSubclassOf(typeof(EntityBase)) && !c.GetTypeInfo().IsAbstract));
            foreach (var type in entityTypes)
            {
                modelBuilder.Entity(type);
            }
        }

        private void RegisterConvention(ModelBuilder modelBuilder)
        {
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                if (entity.ClrType.Namespace != null)
                {
                    var nameParts = entity.ClrType.Namespace.Split('.');
                    var tableName = string.Concat(nameParts[2], "_", entity.ClrType.Name);
                    modelBuilder.Entity(entity.Name).ToTable(tableName);
                }
            }

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }

        private void RegisterCustomMapping(ModelBuilder modelBuilder, IEnumerable<Type> types)
        {
            var customModelBuilderTypes = types.Where(x => typeof(ICustomModelBuilder).IsAssignableFrom(x));
            foreach (var builderType in customModelBuilderTypes)
            {
                if (builderType != null && builderType != typeof(ICustomModelBuilder))
                {
                    var builder = (ICustomModelBuilder)Activator.CreateInstance(builderType);
                    builder.Build(modelBuilder);
                }
            }
        }
    }
}
