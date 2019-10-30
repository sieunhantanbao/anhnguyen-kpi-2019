using System;
using System.Collections.Generic;
using System.Text;

namespace SD2411.KPI2019.Infrastructure.Modules
{
    public interface IModuleConfigurationManager
    {
        IEnumerable<ModuleInfo> GetModules();
    }
}
