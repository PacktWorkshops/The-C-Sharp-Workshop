using Azure.Storage;
using Azure.Storage.Blobs;
using System;
using System.IO;

namespace Chapter08.Exercises.Exercise04
{
    public class FilesClient
    {
        private readonly BlobServiceClient _blobServiceClient;
        private readonly BlobContainerClient _defaultContainerClient;

        public FilesClient(string defaultContainer)
        {
            var endpoint = "https://packtstorage2.blob.core.windows.net/";
            var account = "packtstorage2";
            var key = Environment.GetEnvironmentVariable("BlobStorageKey", EnvironmentVariableTarget.User);
            var storageEndpoint = new Uri(endpoint);
            var storageCredentials = new StorageSharedKeyCredential(account, key);
            _blobServiceClient = new BlobServiceClient(storageEndpoint, storageCredentials);
            _defaultContainerClient = CreateContainerIfNotExists(defaultContainer);
        }

        public void UploadFile(string file, string container)
        {
            var containerClient = CreateContainerIfNotExists(container);
            UploadFileInternal(file, containerClient);
        }

        private BlobContainerClient CreateContainerIfNotExists(string container)
        {
            var lowerCaseContainer = container.ToLower();
            var containerClient = _blobServiceClient.GetBlobContainerClient(lowerCaseContainer);
            if (!containerClient.Exists())
            {
                containerClient = _blobServiceClient.CreateBlobContainer(lowerCaseContainer);
            }

            return containerClient;
        }

        public void UploadFile(string file)
        {
            UploadFileInternal(file, _defaultContainerClient);
        }

        private void UploadFileInternal(string file, BlobContainerClient client)
        {
            var data = new BinaryData(File.ReadAllBytes(file));
            client.UploadBlob(Path.GetFileName(file), data);
        }

        public void DownloadFile(string filename, string container, string downloadDirectory)
        {
            var containerClient = CreateContainerIfNotExists(container);
            DownloadFileInternal(filename, downloadDirectory, containerClient);
        }

        public void DownloadFile(string filename, string downloadDirectory)
        {
            DownloadFileInternal(filename, downloadDirectory, _defaultContainerClient);
        }

        private void DownloadFileInternal(string filename, string downloadDirectory, BlobContainerClient client)
        {
            var blobClient = client.GetBlobClient(filename);
            var downloadedFile = Path.Combine(downloadDirectory, filename);
            
            if (!Directory.Exists(downloadDirectory))
            {
                Directory.CreateDirectory(downloadDirectory);
            }
            
            if (!File.Exists(downloadedFile))
            {
                var stream = File.Create(downloadedFile);
                stream.Dispose();
            }
            blobClient.DownloadTo(downloadedFile);
        }
    }
}
