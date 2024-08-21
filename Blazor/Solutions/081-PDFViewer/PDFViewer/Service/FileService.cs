using PDFViewer.IService;
using PDFViewer.Models;

namespace PDFViewer.Service;

public sealed class FileService(IWebHostEnvironment webHostEnvironment) : IFileService
{
    private IWebHostEnvironment _webHostEnvironment = webHostEnvironment;

    public List<FileClass> GetAllPdfs()
    {
        List<FileClass> files = [];
        string path = $"{_webHostEnvironment.WebRootPath}\\files\\";
        int nFileId = 1;

        foreach (string pdfPath in Directory.EnumerateFiles(path, "*.pdf"))
        {
            files.Add(new FileClass
            {
                FileId = nFileId,
                Name = Path.GetFileName(pdfPath),
                Path = pdfPath
            });
        }
        return files;
    }
}
