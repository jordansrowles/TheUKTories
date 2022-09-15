namespace TheUKTories
{
    public static class Globals
    {
        public static string ConnectionEnvironmentVar = "THEUKTORIES_COSMOS_CONNECTION_STRING";
        public static string ConnectionString = "THEUKTORIES_AZURE_SQL_CONNECTION_STRING";
        public static string ExpressConnectionString = "THEUKTORIES_LOCAL_SQL_CONNECTION_STRING";
        public static string BlobStorageConnectionString = "THEUKTORIES_AZURE_STORAGE_CONNECTIONSTRING";

        public static string TryGetConnectionString(string env) => Environment.GetEnvironmentVariable(env) ?? string.Empty;
    }
}
