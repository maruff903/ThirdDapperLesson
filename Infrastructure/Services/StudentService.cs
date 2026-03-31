using Dapper;
using Domain.Modelse;
using Infrastructure.Data;
using Infrastructure.Interface;
using Npgsql;

namespace Infrastructure.Services;

public class StudentService : IStudentService
{

    private readonly ApplicationDbContext _context = new();
    public async Task CreateStudentAsync(Student student)
    {
        var sql = "INSERT INTO students (fullname, email,phone) VALUES (@FullName, @Email,@Phone)";

        await using var connection = _context.Connection();
        await connection.ExecuteAsync(sql, student);
    }


    public async Task DeleteStudentAsync(int studentId)
    {
        var query = "DELETE FROM students WHERE studentid = @studentId";

        await using var connection = _context.Connection();
        await connection.ExecuteAsync(query, new { Id = studentId });
    }

    public async Task<Student> GetStudentAsync(int studentId)
    {
        var query = "SELECT id, fullname AS FullName, age FROM students WHERE studentid = @studentId";

        await using var connection = _context.Connection();
        return await connection.QueryFirstAsync<Student>(
            query,
            new { Id = studentId }
        );
    }

    public async Task<List<Student>> GetStudentsAsync()
    {
        var query = "SELECT * FROM students";

        await using var connection = _context.Connection();
        var result = await connection.QueryAsync<Student>(query);

        return result.ToList();
    }


    public async Task UpdateStudentAsync(Student student)
    {
        var query = @"UPDATE students 
                      SET fullname = @FullName, age = @Age 
                      WHERE id = @Id";

        await using var connection = _context.Connection();
        await connection.ExecuteAsync(query, student);
    }
}

