using Microsoft.AspNetCore.Components.Forms;

namespace PDFViewer.IService;

public interface IFileUpload
{
    Task UploadAsync(IBrowserFile file);
}
