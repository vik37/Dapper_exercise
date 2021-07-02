using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace Dapper_Exercise_Wf.app
{
    public static class Helper
    {
        public static string CnnVal(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
    }
}
