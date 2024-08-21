using PDFViewer.Models;

namespace PDFViewer.IService;

public interface IFileService
{
    List<FileClass> GetAllPdfs();
}
