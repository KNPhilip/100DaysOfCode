namespace PDFGenerator.Data;

internal sealed class Student
{
    internal int StudentId { get; set; } = 0;
    internal string Name { get; set; } = string.Empty;
    internal string Roll { get; set; } = string.Empty;
    internal string Section { get; set; } = string.Empty;
    internal string Group { get; set; } = string.Empty;
    internal List<MarkSheet> MarkSheets { get; set; } = [];
}
