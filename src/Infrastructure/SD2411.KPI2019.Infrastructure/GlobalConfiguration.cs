using SD2411.KPI2019.Infrastructure.Modules;
using System;
using System.Collections.Generic;
using System.Text;

namespace SD2411.KPI2019.Infrastructure
{
    public static class GlobalConfiguration
    {
        public static IList<ModuleInfo> Modules { get; set; } = new List<ModuleInfo>();
        public static string WebRootPath { get; set; }
        public static string ContentRootPath { get; set; }
    }
}
