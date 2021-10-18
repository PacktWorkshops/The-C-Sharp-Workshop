namespace Tests.Chapter09.Activities.Activity01.Controllers
{
    public class FileControllerTests
    {
        //private readonly IFilesService _filesService;

        //public FileController(IFilesService filesService)
        //{
        //    _filesService = filesService;
        //}

        //[HttpDelete("{file}")]
        //public async Task<IActionResult> Delete(string file)
        //{
        //    await _filesService.Delete(file);

        //    return Ok();
        //}

        //[HttpGet("Download/{file}")]
        //public async Task<IActionResult> Download(string file)
        //{
        //    var content = await _filesService.Download(file);
        //    return new FileContentResult(content, "application/octet-stream ");
        //}

        //[HttpGet("Link")]
        //public IActionResult GetDownloadLink(string file)
        //{
        //    var link = _filesService.GetDownloadLink(file);
        //    return Ok(link);
        //}

        //[HttpPost("upload")]
        //public async Task<IActionResult> Upload(IFormFile file)
        //{
        //    await _filesService.UploadFile(file.FileName, file.OpenReadStream());

        //    return Ok();
        //}
    }
}
