using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api")]
public class APIController(IWebHostEnvironment _webHostEnvironment) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<List<UploadResult>>> UploadFile(List<IFormFile> files)
    {
        List<UploadResult> uploadResults = [];

        foreach (IFormFile file in files)
        {
            UploadResult uploadResult = new();
            string trustedFileNameForFileStorage;
            string untrustedFileName = file.FileName;
            uploadResult.FileName = untrustedFileName;

            trustedFileNameForFileStorage = Path.GetRandomFileName();
            string filePath = Path.Combine(_webHostEnvironment.ContentRootPath, "uploads", trustedFileNameForFileStorage);

            await using FileStream fileStream = new(filePath, FileMode.Create);
            await file.CopyToAsync(fileStream);

            uploadResult.StoredFileName = trustedFileNameForFileStorage;
            uploadResults.Add(uploadResult);
        }
        return Ok(uploadResults);
    }
}

public class UploadResult
{
    public string? FileName { get; set; }
    public string? StoredFileName { get; set; }
}
