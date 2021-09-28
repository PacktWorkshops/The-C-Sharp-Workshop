using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Chapter09.Service.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Identity.Web.Resource;

namespace Chapter09.Service.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IFilesService _filesService;

        public FileController(IFilesService filesService)
        {
            _filesService = filesService;
        }

        [HttpDelete("{file}")]
        public async Task<IActionResult> Delete(string file)
        {
            await _filesService.Delete(file);

            return Ok();
        }

        [HttpGet("Download/{file}")]
        public async Task<IActionResult> Download(string file)
        {
            var content = await _filesService.Download(file);
            return new FileContentResult(content, "application/octet-stream ");
        }

        [HttpGet("Link")]
        public IActionResult GetDownloadLink(string file)
        {
            var link = _filesService.GetDownloadLink(file);
            return Ok(link);
        }

        [HttpPost("upload")]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            await _filesService.UploadFile(file.FileName, file.OpenReadStream());

            return Ok();
        }
    }
}
