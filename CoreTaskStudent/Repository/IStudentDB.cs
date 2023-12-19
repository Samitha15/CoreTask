using CoreTaskStudent.Models;

namespace CoreTaskStudent.Repository
{
    public interface IStudentDB
    {
        Task<IEnumerable<Student>> GetStudentDetails();
        string InsertStudent(Student student);
        string UpdateStudentResult(Student student);
        string DeleteStudentResult(int id);
    }
}
