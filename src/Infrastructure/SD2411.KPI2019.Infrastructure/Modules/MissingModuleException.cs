using System;
using System.Collections.Generic;
using System.Text;

namespace SD2411.KPI2019.Infrastructure.Modules
{
    public class MissingModuleException : Exception
    {
        public string ModuleName { get; set; }

        public MissingModuleException()
        {

        }

        public MissingModuleException(string message): base(message)
        {

        }

        public MissingModuleException(string message, string moduleName):this(message)
        {
            ModuleName = moduleName;
        }
    }
}
