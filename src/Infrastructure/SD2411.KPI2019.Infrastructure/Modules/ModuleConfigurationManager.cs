using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SD2411.KPI2019.Infrastructure.Modules
{
    public class ModuleConfigurationManager : IModuleConfigurationManager
    {
        private static readonly string ModuleInfoFileName = "modules-info.json";
        public IEnumerable<ModuleInfo> GetModules()
        {
            var modulePath = Path.Combine(Directory.GetCurrentDirectory(), ModuleInfoFileName);
            using var reader = new StreamReader(modulePath);
            string content = reader.ReadToEnd();
            dynamic modulesData = JsonConvert.DeserializeObject(content);
            foreach (dynamic module in modulesData)
            {
                yield return new ModuleInfo
                {
                    Id = module.id,
                    Name = module.name,
                    Version = Version.Parse(module.version.ToString())
                };
            }
        }
    }
}
