using Domain.Modelse;

namespace Infrastructure.Interface;

public interface IStudentService
{
    Task CreateStudentAsync(Student student);
    Task<List<Student>> GetStudentsAsync();
    Task<Student> GetStudentAsync(int studentId);
    Task UpdateStudentAsync(Student student);
    Task DeleteStudentAsync(int studentId);
}

