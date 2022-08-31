using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheUKTories
{
    public static class Globals
    {
        public static string ConnectionEnvironmentVar = "THEUKTORIES_COSMOS_CONNECTION_STRING";

        public static string TryGetConnectionString() => Environment.GetEnvironmentVariable(ConnectionEnvironmentVar) ?? string.Empty;
    }
}
