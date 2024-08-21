using PDFGenerator.Data;
using PDFGenerator.DB;

namespace PDFGenerator.Services;

internal sealed class StudentService : IStudentService
{
    private readonly DatabaseClass _databaseClass = new();

    public Student GetStudent(int studentId)
    {
        return _databaseClass.GetStudents().FirstOrDefault(s => s.StudentId == studentId)!;
    }

    public List<Student> GetStudents()
    {
        return _databaseClass.GetStudents();
    }
}
