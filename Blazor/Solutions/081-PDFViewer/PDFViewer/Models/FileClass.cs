namespace PDFViewer.Models;

public sealed class FileClass
{
    public int FileId { get; set; } = 0;
    public string Name { get; set; } = string.Empty;
    public string Path { get; set; } = string.Empty;
    public List<FileClass> Files { get; set; } = [];
}
