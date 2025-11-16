using StudentsManagementSystem_Kolyo_Kolev_F113002.Interfaces;
using StudentsManagementSystem_Kolyo_Kolev_F113002.Models;

namespace StudentsManagementSystem_Kolyo_Kolev_F113002.Services;

public class GradeService : IGradeService
{
    // Adds a new grade to the given student for the specified subject.
    public Grade AddGrade(Student student, Subject subject, double value)
    {
        Grade grade = new Grade(subject, value);

        student
            .Grades
            .Add(grade);

        return grade;
    }

    // Removes a grade from the given student's grade list.
    public void RemoveGrade(Student student, Grade grade)
    {
        student
            .Grades
            .Remove(grade);
    }

    // Updates the subject and value of an existing grade instance.
    public void UpdateGrade(Grade grade, Subject subject, double value)
    {
        grade.Subject = subject;
        grade.Value = value;
    }
}
