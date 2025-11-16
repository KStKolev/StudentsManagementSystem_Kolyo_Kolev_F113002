namespace StudentsManagementSystem_Kolyo_Kolev_F113002.Models;

public class Student
{
    // Unique identifier of the student.
    public Guid Id { get; set; } = Guid.NewGuid();

    // Student display name.
    public string Name { get; set; } = string.Empty;

    // Collection of grades for this student.
    public List<Grade> Grades { get; } = new();

    // Calculates the average grade value. Returns 0 when no grades exist.
    public double GetAverageGrade()
    {
        if (Grades.Count == 0) 
        { 
            return 0.0; 
        }

        return Grades
            .Average(g => g.Value);
    }
}
