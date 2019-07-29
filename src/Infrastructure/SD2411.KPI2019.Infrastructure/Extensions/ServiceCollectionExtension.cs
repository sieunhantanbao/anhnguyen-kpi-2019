using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using SD2411.KPI2019.Infrastructure.Modules;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SD2411.KPI2019.Infrastructure.Extensions
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

        private static void RegisterModuleServices(ModuleInfo module, ref IServiceCollection services)
        {
            var moduleInitializerType = module.Assembly.GetTypes()
                    .FirstOrDefault(t => typeof(IModuleInitializer).IsAssignableFrom(t));
            if ((moduleInitializerType != null) && (moduleInitializerType != typeof(IModuleInitializer)))
            {
                services.AddSingleton(typeof(IModuleInitializer), moduleInitializerType);
            }
        }
    }
}
