namespace TheUKTories.Services.BlobService
{
    using Azure;
    using Azure.Storage.Blobs;
    using Azure.Storage.Blobs.Models;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;
    using TheUKTories.Services.Data.EFCore.Models.People;

    public class BlobStorageService
    {
        public string GetCxnStr = Globals.TryGetConnectionString(Globals.BlobStorageConnectionString);
        private readonly ILogger<BlobStorageService> _logger;
        BlobServiceClient _client;

        public IConfiguration Config { get; }

        public BlobStorageService(IConfiguration config, ILogger<BlobStorageService> logger)
        {
            Config = config;
            _logger = logger;
            _client = new BlobServiceClient(GetCxnStr);
        }

        public async Task<string> UploadFileBlobAsync(Stream content, string contenttype, string container_name, string filename)
        {
            var container = _client.GetBlobContainerClient(container_name);
            content.Position = 0;
            var blob = container.GetBlobClient(filename);
            await blob.UploadAsync(content, new BlobHttpHeaders { ContentType = contenttype });
            return blob.Uri.AbsoluteUri;
        }

        public async Task<(string, bool)> CheckIfFileExists(string container_name, string filename)
        {
            var container = _client.GetBlobContainerClient(container_name);
            var blob = container.GetBlobClient(filename);
            var exist = await blob.ExistsAsync();
            if (exist) return (blob.Uri.AbsoluteUri, exist.Value);
            return ("", exist.Value);
        }

        public async Task<Dictionary<string, Uri>> Iterate(string container_name)
        {
            var container = _client.GetBlobContainerClient(container_name);
            var items = new Dictionary<string, Uri>();
            await foreach (var blob in container.GetBlobsAsync())
            {
                var b = container.GetBlobClient(blob.Name);
                items.Add(b.Name, b.Uri);
            }
            return items;
        }

        // Person profile images
        public async Task<string> UploadPersonProfileImage(Stream data, Person person) {
            return await UploadFileBlobAsync(data, "", "profiles", person.GetProfileImageName());

        }

        public async Task<Dictionary<string, Uri>> AllPeopleProfileImages() => await Iterate("profiles");
    }
}
