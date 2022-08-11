using System;
using System.IO;
using System.Threading.Tasks;
using Chapter09.Service.Controllers;
using Chapter09.Service.Exercises.Exercise03;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Tests.Chapter09.Exercises.Exercise03
{
    [TestClass]
    public class FileControllerTests
    {
        private FileController _controller;

        private Mock<IFilesService> _fileService;

        [TestInitialize]
        public void SetUp()
        {
            _fileService = new Mock<IFilesService>();
            _controller = new FileController(_fileService.Object);
        }

        [TestMethod]
        public async Task Delete_CallsFileService_And_ReturnsOk()
        {
            const string anyFile = "anyFile";

            var response = await _controller.Delete(anyFile);

            _fileService.Verify(fs => fs.Delete(anyFile), Times.Once);
            Assert.IsInstanceOfType(response, typeof(OkResult));
        }

        [TestMethod]
        public async Task Download_CallsFileService_And_ReturnsDownloaddedContented_OfOctetStream()
        {
            const string anyFile = "anyFile";
            byte[] expectedContent = new byte[0];
            _fileService
                .Setup(fs => fs.Download(anyFile))
                .ReturnsAsync(expectedContent);

            var response = await _controller.Download(anyFile);

            _fileService.Verify(fs => fs.Download(anyFile), Times.Once);
            Assert.IsInstanceOfType(response, typeof(FileContentResult));
            var fileContentResponse = (FileContentResult)response;
            Assert.AreEqual("application/octet-stream", fileContentResponse.ContentType);
            Assert.AreEqual(expectedContent, fileContentResponse.FileContents);
        }

        [TestMethod]
        public void GetDownloadLink_CallsFileService_And_ReturnsFileContentResult_OfOctetStream()
        {
            const string anyFile = "anyFile";
            var expectedLink = new Uri("https://test.com");
            _fileService
                .Setup(fs => fs.GetDownloadLink(anyFile))
                .Returns(expectedLink);
            var response = _controller.GetDownloadLink(anyFile);

            _fileService.Verify(fs => fs.GetDownloadLink(anyFile), Times.Once);
            Assert.IsInstanceOfType(response, typeof(OkObjectResult));
            var fileContentResponse = (OkObjectResult)response;
            Assert.AreEqual(expectedLink, fileContentResponse.Value);
        }

        [TestMethod]
        public async Task Upload_CallsFileService_And_ReturnsOk()
        {
            var file = new Mock<IFormFile>();
            const string expectedFilename = "anyFile";
            var expectedStream = new MemoryStream(new byte[0]);
            file
                .SetupGet(f => f.FileName)
                .Returns(expectedFilename);
            file
                .Setup(f => f.OpenReadStream())
                .Returns(expectedStream);

            var response = await _controller.Upload(file.Object);

            _fileService.Verify(fs => fs.Upload(expectedFilename, expectedStream), Times.Once);
            Assert.IsInstanceOfType(response, typeof(OkResult));
        }
    }
}
