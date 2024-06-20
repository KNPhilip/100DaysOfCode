namespace PDFGenerator.Data;

internal sealed class MarkSheet
{
    internal int MarkSheetId { get; set; } = 0;
    internal string Subject { get; set; } = string.Empty;
    internal int Mark { get; set; } = 0;
    internal string Grade => CalculateGrade(Mark);
    internal int StudentId { get; set; } = 0;

    private static string CalculateGrade(int mark)
    {
        string grade = "";
        if (mark < 40) return "F";
        else if (mark >= 40 && mark < 50) return "D";
        else if (mark >= 50 && mark < 60) return "C";
        else if (mark >= 60 && mark < 70) return "B";
        else if (mark >= 70 && mark < 80) return "A";
        else if (mark >= 80 && mark <= 100) return "A+";
        return grade;
    }
}
