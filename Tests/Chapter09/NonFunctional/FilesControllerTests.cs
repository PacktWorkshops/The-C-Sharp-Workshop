using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Tests.Chapter09.NonFunctional.Common;

namespace Tests.Chapter09.NonFunctional
{
    [TestClass]
    public class FilesControllerTests
    {
        private static HttpClient _client;

        private const string ExistingFile = "existingFile.txt";
        private const string NotExistingFile = "this-does-not-exist.txt";

        [TestInitialize]
        public void SetUp()
        {
            _client = Chapter09ApiFixture.ClientActivity;
            UploadTestFile().GetAwaiter().GetResult();
        }

        [TestCleanup]
        public void Cleanup()
        {
            Delete(ExistingFile).GetAwaiter().GetResult();
        }

        [TestMethod]
        public async Task Delete_GivenFileExists_ReturnsOk()
        {
            var response = await Delete(ExistingFile);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            // Cleanup
            await UploadTestFile();
        }

        [TestMethod]
        public async Task Delete_GivenFileDoesNotExist_ThrowsFileNotFoundException()
        {
            var response = await Delete(NotExistingFile);

            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
        }

        [TestMethod]
        public async Task UploadFile_GivenFileDoesNotExist_UploadsIt()
        {
            var uri = new Uri("upload/", UriKind.Relative);
            var file = new FormFile(Stream.Null, 0, 0, NotExistingFile, NotExistingFile);
            
            var response = await Upload(file);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            // Cleanup
            await Delete(NotExistingFile);
        }

        [TestMethod]
        public async Task UploadFile_GivenFileExists_ReturnsInternalServerError()
        {
            var uri = new Uri("upload/", UriKind.Relative);
            var file = new FormFile(Stream.Null, 0, 0, ExistingFile, ExistingFile);

            var response = await Upload(file);

            Assert.AreEqual(HttpStatusCode.InternalServerError, response.StatusCode);
        }

        [TestMethod]
        public async Task Download_GivenFileExists_ReturnsContentAsByteArray()
        {
            var uri = new Uri($"Download/{ExistingFile}", UriKind.Relative);

            var response = await _client.GetAsync(uri);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [TestMethod]
        public async Task Download_GivenFileDoesNotExist_ThrowsFileNotFoundException()
        {
            var uri = new Uri($"Download/{NotExistingFile}", UriKind.Relative);

            var response = await _client.GetAsync(uri);

            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
        }
        
        [TestMethod]
        public async Task GetDownloadLink_GivenFileDoesNotExist_ThrowsFileNotFoundException()
        {
            var uri = new Uri($"Link/{NotExistingFile}/", UriKind.Relative);

            var response = await _client.GetAsync(uri);

            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
        }

        [TestMethod]
        public async Task GetDownloadLink_GivenFileExists_ReturnsLinkToThatFile()
        {
            var uri = new Uri($"Link/{ExistingFile}/", UriKind.Relative);

            var response = await _client.GetAsync(uri);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        private Task<HttpResponseMessage> Upload(IFormFile file)
        {
            using var br = new BinaryReader(file.OpenReadStream());
            var data = br.ReadBytes((int)file.OpenReadStream().Length);
            ByteArrayContent bytes = new ByteArrayContent(data);
            MultipartFormDataContent multiContent = new MultipartFormDataContent();
            multiContent.Add(bytes, "file", file.FileName);

            return _client.PostAsync(new Uri("upload/", UriKind.Relative), multiContent);
        }

        private Task<HttpResponseMessage> Delete(string file)
        {
            var uri = new Uri($"{file}/", UriKind.Relative);
            return _client.DeleteAsync(uri);
        }

        private async Task UploadTestFile()
        {
            var uri = new Uri("upload/", UriKind.Relative);
            var file = new FormFile(Stream.Null, 0, 0, ExistingFile, ExistingFile);
            var response = await Upload(file);
        }
    }
}