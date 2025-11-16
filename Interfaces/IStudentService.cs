using StudentsManagementSystem_Kolyo_Kolev_F113002.Models;

namespace StudentsManagementSystem_Kolyo_Kolev_F113002.Interfaces;

public interface IStudentService
{
    // Returns all students.
    IReadOnlyCollection<Student> GetAll();

    // Adds a student with the provided name.
    Student Add(string name);

    // Updates the name of a student by id.
    void Update(Guid id, string name);

    // Removes a student by id.
    void Remove(Guid id);
}
