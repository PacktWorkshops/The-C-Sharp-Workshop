using System.Threading.Tasks;
using Chapter09.Activity01.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Chapter09.Activity01.Controllers
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

        [HttpGet("Link/{file}")]
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
