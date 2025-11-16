using StudentsManagementSystem_Kolyo_Kolev_F113002.Interfaces;
using StudentsManagementSystem_Kolyo_Kolev_F113002.Models;

namespace StudentsManagementSystem_Kolyo_Kolev_F113002.Services;

public class StudentService : IStudentService
{
    private readonly List<Student> _students = new();

    // Returns an immutable view of all students.
    public IReadOnlyCollection<Student> GetAll() => _students
        .AsReadOnly();

    // Creates and adds a new student with the given name.
    public Student Add(string name)
    {
        var student = new Student { Name = name };

        _students
            .Add(student);

        return student;
    }

    // Updates an existing student's name by id.
    public void Update(Guid id, string name)
    {
        Student student = _students
            .First(x => x.Id == id);

        student.Name = name;
    }

    // Removes a student by id.
    public void Remove(Guid id)
    {
        Student student = _students
            .First(x => x.Id == id);

        _students
            .Remove(student);
    }
}
