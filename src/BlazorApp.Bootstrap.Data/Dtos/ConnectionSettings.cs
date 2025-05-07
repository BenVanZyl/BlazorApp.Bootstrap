using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Bootstrap.Data.Dtos
{
    public class ConnectionSettings
    {
        public string Database { get; set; } = string.Empty;
        public string AppInsights { get; set; } = string.Empty;
    }
}
