using StudentsManagementSystem_Kolyo_Kolev_F113002.Interfaces;
using StudentsManagementSystem_Kolyo_Kolev_F113002.Models;

namespace StudentsManagementSystem_Kolyo_Kolev_F113002.Services;

public class SubjectService : ISubjectService
{
    private readonly List<Subject> _subjects = new();

    // Returns an immutable view of all subjects.
    public IReadOnlyCollection<Subject> GetAll() => _subjects
        .AsReadOnly();

    // Creates and adds a new subject.
    public Subject Add(string name, int credits)
    {
        Subject subject = new Subject 
        { 
            Name = name, 
            Credits = credits 
        };

        _subjects
            .Add(subject);

        return subject;
    }

    // Updates an existing subject by id.
    public void Update(Guid id, string name, int credits)
    {
        Subject subject = _subjects
            .First(x => x.Id == id);

        subject.Name = name;
        subject.Credits = credits;
    }

    // Removes a subject by id.
    public void Remove(Guid id)
    {
        Subject subject = _subjects
            .First(x => x.Id == id);

        _subjects
            .Remove(subject);
    }
}
