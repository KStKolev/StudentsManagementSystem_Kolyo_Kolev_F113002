namespace StudentsManagementSystem_Kolyo_Kolev_F113002.Models;

public class Grade
{
    // Creates a grade with a default subject and value.
    public Grade() 
    { 
        Subject = new Subject { Name = string.Empty, Credits = 1 }; 
    }

    // Creates a grade for the specified subject and value.
    public Grade(Subject subject, double value)
    {
        Subject = subject;
        Value = value;
    }

    // The subject this grade belongs to.
    public Subject Subject { get; set; }

    // The numeric grade value.
    public double Value { get; set; }
}
