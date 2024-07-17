using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Azure.Storage.Blobs;

namespace ProductAPI.Services
{
    public class AzureStorageService
    {
        private readonly BlobServiceClient _blobServiceClient;
        private readonly string _containerName;

        public AzureStorageService(IConfiguration configuration)
        {
            _blobServiceClient = new BlobServiceClient(configuration["Azure:StorageAccountString"]);
            _containerName = configuration["Azure:StorageContainerName"];
        }

        public string GetBlobUrl(string blobName)
        {
            var containerClient = _blobServiceClient.GetBlobContainerClient(_containerName);
            var blobClient = containerClient.GetBlobClient(blobName);
            return blobClient.Uri.AbsoluteUri;
        }
    }
}
