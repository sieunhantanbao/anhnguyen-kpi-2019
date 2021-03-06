﻿using System;
using System.Reflection;

namespace SD2411.KPI2019.Infrastructure.Modules
{
    public class ModuleInfo
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public Version Version { get; set; }

        public Assembly Assembly { get; set; }
    }
}
