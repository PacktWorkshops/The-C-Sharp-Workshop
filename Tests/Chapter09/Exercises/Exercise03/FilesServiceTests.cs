using System;
using System.IO;
using System.Threading.Tasks;
using Azure;
using Chapter09.Service.Exercises.Exercise03;
using Chapter09.Service.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Common;

namespace Tests.Chapter09.Exercises.Exercise03
{
    [TestClass]
    public class FilesServiceTests
    {
        private const string ExistingFile = "existingFile.txt";
        private const string NotExistingFile = "this-does-not-exist.tmp";

        private byte[] existingFileContent = new byte[] { 1 };

        private FilesService _filesService;

        [TestInitialize]
        public void SetUp()
        {
            _filesService = new FilesService();
            _filesService
                .UploadFile(ExistingFile, new MemoryStream(existingFileContent))
                .GetAwaiter().GetResult();
        }

        [TestCleanup]
        public void Cleanup()
        {
            _filesService.Delete(ExistingFile);
        }

        [TestMethod]
        public async Task Delete_GivenFileExists_GettingLinkAfterDelete_ThrowsFileNotFoundException()
        {
            await _filesService.Delete(ExistingFile);

            Action getDownloadLinkDeletedFile = () => _filesService.GetDownloadLink(ExistingFile);
            Assert.ThrowsException<FileNotFoundException>(getDownloadLinkDeletedFile);

            // Needed for the cleanup to work.
            await _filesService.UploadFile(ExistingFile, Stream.Null);
        }

        [TestMethod]
        public void Delete_GivenFileDoesNotExist_ThrowsFileNotFoundException()
        {
            async Task DeleteNotExistingFile() => await _filesService.Delete(NotExistingFile);

            Assert.ThrowsExceptionAsync<FileNotFoundException>(DeleteNotExistingFile);
        }

        [TestMethod]
        public async Task UploadFile_GivenFileDoesNotExist_UploadsIt()
        {
            Func<Task> getDownloadLinkOfUploadedFile = () => _filesService.UploadFile(NotExistingFile, Stream.Null);

            await getDownloadLinkOfUploadedFile.DoesNotThrow();

            await _filesService.Delete(NotExistingFile);
        }

        [TestMethod]
        public async Task UploadFile_GivenFileExists_ThrowsRequestFailedException()
        {
            Func<Task> uploadExistingFile = async () => await _filesService.UploadFile(ExistingFile, Stream.Null);

            await Assert.ThrowsExceptionAsync<RequestFailedException>(uploadExistingFile);
        }

        [TestMethod]
        public async Task Download_GivenFileExists_ReturnsContentAsByteArray()
        {
            var downloaded = await _filesService.Download(ExistingFile);

            Assert.AreEqual(existingFileContent.Length, downloaded.Length);
            Assert.AreEqual(existingFileContent[0], downloaded[0]);
        }

        [TestMethod]
        public void Download_GivenFileDoesNotExist_ThrowsFileNotFoundException()
        {
            Func<Task> downloadedNotExistingFile = async () => await _filesService.Download(ExistingFile);

            Assert.ThrowsExceptionAsync<FileNotFoundException>(downloadedNotExistingFile);
        }

        [TestMethod]
        public void GetDownloadLink_GivenFileDoesNotExist_ThrowsFileNotFoundException()
        {
            Action getDownloadLinkToNotExistingFile = () => _filesService.GetDownloadLink(NotExistingFile);

            Assert.ThrowsException<FileNotFoundException>(getDownloadLinkToNotExistingFile);
        }

        [TestMethod]
        public void GetDownloadLink_GivenFileExists_ReturnsLinkToThatFile()
        {
            var linkToFile = _filesService.GetDownloadLink(ExistingFile);

            Assert.IsNotNull(linkToFile);
        }
    }
}
