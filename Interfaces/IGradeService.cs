using StudentsManagementSystem_Kolyo_Kolev_F113002.Models;

namespace StudentsManagementSystem_Kolyo_Kolev_F113002.Interfaces;

public interface IGradeService
{
    // Adds a new grade to a student for a subject.
    Grade AddGrade(Student student, Subject subject, double value);

    // Removes an existing grade from a student.
    void RemoveGrade(Student student, Grade grade);

    // Updates an existing grade instance.
    void UpdateGrade(Grade grade, Subject subject, double value);
}
