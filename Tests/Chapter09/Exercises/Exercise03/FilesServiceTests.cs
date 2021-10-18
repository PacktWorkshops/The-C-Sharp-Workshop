namespace Tests.Chapter09.Exercises.Exercise03
{
    public class FilesServiceTests
    {
    //    private readonly BlobServiceClient _blobServiceClient;
    //    private readonly BlobContainerClient _defaultContainerClient;

    //    public FilesServiceTests()
    //    {
    //        var endpoint = "https://packtstorage2.blob.core.windows.net/";
    //        var account = "packtstorage2";
    //        var key = Environment.GetEnvironmentVariable("BlobStorageKey", EnvironmentVariableTarget.User);
    //        var storageEndpoint = new Uri(endpoint);
    //        var storageCredentials = new StorageSharedKeyCredential(account, key);
    //        _blobServiceClient = new BlobServiceClient(storageEndpoint, storageCredentials);
    //        _defaultContainerClient = CreateContainerIfNotExists("Exercise04").Result;
    //    }

    //    private async Task<BlobContainerClient> CreateContainerIfNotExists(string container)
    //    {
    //        var lowerCaseContainer = container.ToLower();
    //        var containerClient = _blobServiceClient.GetBlobContainerClient(lowerCaseContainer);
    //        if (!await containerClient.ExistsAsync())
    //        {
    //            containerClient = await _blobServiceClient.CreateBlobContainerAsync(lowerCaseContainer);
    //        }

    //        return containerClient;
    //    }

    //    public Task Delete(string name)
    //    {
    //        var blobClient = _defaultContainerClient.GetBlobClient(name);
    //        if (!blobClient.Exists())
    //        {
    //            throw new FileNotFoundException($"File {name} in default blob storage not found.");
    //        }

    //        return blobClient.DeleteAsync();
    //    }

    //    public Task UploadFile(string name, Stream content)
    //    {
    //        var blobClient = _defaultContainerClient.GetBlobClient(name);
    //        return blobClient.UploadAsync(content);
    //    }

    //    public async Task<byte[]> Download(string filename)
    //    {
    //        var blobClient = _defaultContainerClient.GetBlobClient(filename);
    //        var stream = new MemoryStream();
    //        await blobClient.DownloadToAsync(stream);

    //        return stream.ToArray();
    //    }

    //    public Uri GetDownloadLink(string filename)
    //    {
    //        var blobClient = _defaultContainerClient.GetBlobClient(filename);
    //        var url = GetUri(blobClient);

    //        return url;
    //    }

    //    private Uri GetUri(BlobClient blobClient)
    //    {
    //        var sasBuilder = new BlobSasBuilder
    //        {
    //            BlobContainerName = _defaultContainerClient.Name,
    //            BlobName = blobClient.Name,
    //            Resource = "b",
    //            ExpiresOn = DateTimeOffset.UtcNow.AddHours(1)
    //        };
    //        sasBuilder.SetPermissions(BlobSasPermissions.Read);

    //        var sasUri = blobClient.GenerateSasUri(sasBuilder);
    //        return sasUri;
    //    }
    }
}
