using PDFGenerator.Data;

namespace PDFGenerator.DB;

internal sealed class DatabaseClass
{
    internal List<Student> _students = [];
    internal List<MarkSheet> _markSheets = [];

    internal DatabaseClass()
    {
        for (int i = 1; i <= 9; i++)
        {
            _students.Add(new Student
            {
                StudentId = i,
                Name = $"Stu{i}",
                Roll = $"100{i}",
                Section = $"S{i}",
                Group = $"G{i}",
                MarkSheets = GetMarkSheets(i)
            });
        }
    }

    private List<MarkSheet> GetMarkSheets(int studentId)
    {
        Random rnd = new();
        for (int m = 1; m <= 5; m++) 
        {
            _markSheets.Add(new MarkSheet
            {
                MarkSheetId = m,
                StudentId = studentId,
                Subject = $"Sub{rnd.Next(1, 100)}",
                Mark = rnd.Next(1, 100)
            });
        }
        return _markSheets;
    }

    internal List<Student> GetStudents() => _students;
}
