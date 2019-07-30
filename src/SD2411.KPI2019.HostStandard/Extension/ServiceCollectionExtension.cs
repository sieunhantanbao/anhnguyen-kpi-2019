using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using Newtonsoft.Json;
using SD2411.KPI2019.Infrastructure;
using SD2411.KPI2019.Infrastructure.Modules;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace SD2411.KPI2019.HostStandard.Extension
{
    public static class ServiceCollectionExtension
    {
        private static readonly IModuleConfigurationManager _moduleConfig = new ModuleConfigurationManager();
        public static IServiceCollection AddModules(this IServiceCollection services, string contentRootPath)
        {
            const string moduleInfoFileName = "modules-info.json";
            var modulesFolder = Path.Combine(contentRootPath, "Modules");
            foreach (var module in _moduleConfig.GetModules())
            {
                var moduleFolder = new DirectoryInfo(Path.Combine(modulesFolder, module.Id));
                var moduleFileNamePath = Path.Combine(moduleFolder.FullName, moduleInfoFileName);
                if (!File.Exists(moduleFileNamePath))
                {
                    throw new MissingModuleException($"The configuration file module {moduleFolder.Name} is not found.", moduleFolder.Name);
                }
                using (var reader = new StreamReader(moduleFileNamePath))
                {
                    var content = reader.ReadToEnd();
                    dynamic moduleMetadata = JsonConvert.DeserializeObject(content);
                    module.Name = moduleMetadata.name;
                }
                module.Assembly = Assembly.Load(new AssemblyName(moduleFolder.Name));
                GlobalConfiguration.Modules.Add(module);
                RegisterModuleServices(module, ref services);
            }
            return services;
        }

        public static IServiceCollection AddCustomizedMvc(this IServiceCollection services, IList<ModuleInfo> modules)
        {
            var mvcBuilder = services
                .AddMvc(o =>
                {
                    o.EnableEndpointRouting = false;
                });
            foreach (var module in modules)
            {
                AddApplicationPart(mvcBuilder, module.Assembly);
            }
            return services;
        }

        #region Private methods
        private static void RegisterModuleServices(ModuleInfo module, ref IServiceCollection services)
        {
            var moduleInitializerType = module.Assembly.GetTypes()
                    .FirstOrDefault(t => typeof(IModuleInitializer).IsAssignableFrom(t));
            if ((moduleInitializerType != null) && (moduleInitializerType != typeof(IModuleInitializer)))
            {
                services.AddSingleton(typeof(IModuleInitializer), moduleInitializerType);
            }
        }

        private static void AddApplicationPart(IMvcBuilder mvcBuilder, Assembly assembly)
        {
            AddApplicationPart(ref mvcBuilder, assembly);
            var relatedAssemblies = RelatedAssemblyAttribute.GetRelatedAssemblies(assembly, throwOnError: false);
            foreach (var relatedAssembly in relatedAssemblies)
            {
                AddApplicationPart(ref mvcBuilder, assembly);
            }
        }

        private static void AddApplicationPart(ref IMvcBuilder mvcBuilder, Assembly assembly)
        {
            var partFactory = ApplicationPartFactory.GetApplicationPartFactory(assembly);
            foreach (var part in partFactory.GetApplicationParts(assembly))
            {
                mvcBuilder.PartManager.ApplicationParts.Add(part);
            }
        }
        #endregion
    }
}
