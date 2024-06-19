using Microsoft.AspNetCore.Components.Forms;
using PDFViewer.IService;

namespace PDFViewer.Service;

public sealed class FileUpload(IWebHostEnvironment webHostEnvironment) : IFileUpload
{
    private readonly IWebHostEnvironment _webHostEnvironment = webHostEnvironment;

    public async Task UploadAsync(IBrowserFile file)
    {
        string path = Path.Combine(_webHostEnvironment.WebRootPath, "files", file.Name);

        string? directoryPath = Path.GetDirectoryName(path);
        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath!);
        }

        using Stream stream = file.OpenReadStream();

        using FileStream fileStream = new(path, FileMode.Create, FileAccess.Write);
        await stream.CopyToAsync(fileStream);
    }
}
