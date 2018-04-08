using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WithAccessDatabase
{
    class Configuration
    {
        public static string ConfigurationMethod()
        {
            return ConfigurationManager.ConnectionStrings["accessdb"].ConnectionString;
        }
    }
}
