using PDFGenerator.Data;

namespace PDFGenerator.Services;

internal interface IStudentService
{
    public List<Student> GetStudents();
    public Student GetStudent(int studentId);
}
