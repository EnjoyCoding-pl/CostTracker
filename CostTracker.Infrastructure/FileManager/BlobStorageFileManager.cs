using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using CostTracker.Core.Interfaces;
using Microsoft.Extensions.Options;

namespace CostTracker.Infrastructure.FileManager
{
    public class BlobStorageFileManager : IFileManager
    {
        private readonly IOptions<BlobStorageOptions> _options;

        public BlobStorageFileManager(IOptions<BlobStorageOptions> options)
        {
            _options = options;
        }
        public async Task<string> UploadAsync(Stream file, string fileName)
        {
            var client = new BlobServiceClient(_options.Value.ConnectionString);
            var blobClient = await client.CreateBlobContainerAsync(Guid.NewGuid().ToString().Replace("-", ""),PublicAccessType.Blob);
            var blobInfo = await blobClient.Value.UploadBlobAsync(fileName, file);
            
            return $"{blobClient.Value.Uri.AbsoluteUri}/{fileName}";
        }
    }
}