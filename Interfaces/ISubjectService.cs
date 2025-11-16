using StudentsManagementSystem_Kolyo_Kolev_F113002.Models;

namespace StudentsManagementSystem_Kolyo_Kolev_F113002.Interfaces;

public interface ISubjectService
{
    // Returns all subjects.
    IReadOnlyCollection<Subject> GetAll();

    // Adds a new subject with name and credits.
    Subject Add(string name, int credits);

    // Updates a subject by id.
    void Update(Guid id, string name, int credits);

    // Removes a subject by id.
    void Remove(Guid id);
}
