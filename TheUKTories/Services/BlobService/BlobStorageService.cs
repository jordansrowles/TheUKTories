namespace TheUKTories.Services.BlobService
{
    using Azure;
    using Azure.Storage.Blobs;
    using Azure.Storage.Blobs.Models;

    public static class BlobStorageService
    {
        public static string GetCxnStr = Globals.TryGetConnectionString(Globals.BlobStorageConnectionString);

        public static async Task<BlobContainerClient> GetPeopleContainer()
        {
            var client = new BlobContainerClient(GetCxnStr, "people");
            await client.SetAccessPolicyAsync(PublicAccessType.Blob);
            return client;
        }
    }
}
