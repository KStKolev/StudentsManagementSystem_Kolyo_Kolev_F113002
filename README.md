# StudentsManagementSystem_Kolyo_Kolev_F113002
````````

Students Management System

A simple Windows Forms app for managing students, subjects, and grades. Built with .NET 9.

Features
- Subjects
  - Add, edit, remove subjects (name, credits)
  - Confirmation when deleting a subject used by students (cascades grade removals)
- Students
  - Add, edit, remove students
- Grades
  - Assign a subject and numeric grade (2.00–6.00) to a student
  - Edit and remove grades
- Calculations
  - Per-student total earned credits (only grades >= 3.00 count toward credits)
  - Per-student average grade
- In-memory storage (no persistence). Data resets on app restart.

UI Overview
- Two tabs: Students and Subjects
- Students tab
  - Top list: Students with Name, Credits (earned), Average
  - Bottom list: Grades for the selected student with Subject, Grade, Credits (0 if grade < 3.00)
  - Actions: Add/Edit/Remove Student; Add/Edit/Remove Grade
- Subjects tab
  - List: Subjects with Name and Credits
  - Actions: Add/Edit/Remove Subject

Seed Data
- Mathematics (6 credits)
- Physics (5 credits)
- Literature (3 credits)

Project Structure
- Models: Student, Subject, Grade
- Interfaces: IStudentService, ISubjectService, IGradeService
- Services (in-memory): StudentService, SubjectService, GradeService
- Forms: StudentsSystem (main), StudentForm, SubjectForm, GradeForm
- Utils: MessageDialog
