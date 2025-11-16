using StudentsManagementSystem_Kolyo_Kolev_F113002.Models;
using StudentsManagementSystem_Kolyo_Kolev_F113002.Services;

namespace StudentsManagementSystem_Kolyo_Kolev_F113002
{
    public partial class StudentsSystem : Form
    {
        private readonly SubjectService _subjectService = new();
        private readonly StudentService _studentService = new();
        private readonly GradeService _gradeService = new();
        private bool _isRefreshingStudents;

        // Initializes the main form, seeds sample data, wires events, and populates lists.
        public StudentsSystem()
        {
            InitializeComponent();
            // Ensure the Students list second column shows Credits instead of Type
            if (listViewStudents.Columns.Count >= 2)
            {
                listViewStudents.Columns[1].Text = "Credits";
            }
            Text = "Students System"; // rename window title
            Seed();
            WireEvents();
            RefreshSubjectsList();
            RefreshStudentsList();
            // Removed dynamic column equalizer calls since form is fixed-size now
        }

        // Adds a few default subjects to start with.
        private void Seed()
        {
            _subjectService
                .Add("Mathematics", 6);

            _subjectService
                .Add("Physics", 5);

            _subjectService
                .Add("Literature", 3);
        }

        // Subscribes button and list selection events to their handlers.
        private void WireEvents()
        {
            btnAddSubject.Click += (_, _) => AddSubject();
            btnEditSubject.Click += (_, _) => EditSelectedSubject();
            btnRemoveSubject.Click += (_, _) => RemoveSelectedSubject();
            btnAddStudent.Click += (_, _) => AddStudent();
            btnEditStudent.Click += (_, _) => EditSelectedStudent();
            btnRemoveStudent.Click += (_, _) => RemoveSelectedStudent();
            btnAddStudentSubject.Click += (_, _) => AddGradeToSelectedStudent();
            btnEditStudentSubject.Click += (_, _) => EditSelectedGrade();
            btnRemoveStudentSubject.Click += (_, _) => RemoveSelectedGrade();
            listViewStudents.SelectedIndexChanged += (_, _) =>
            {
                if (_isRefreshingStudents) 
                { 
                    return; 
                }

                RefreshStudentGrades();
            };
            listViewSubjects.SelectedIndexChanged += (_, _) => UpdateSubjectButtonsState();
            listViewStudents.SelectedIndexChanged += (_, _) => UpdateStudentButtonsState();
            listViewGrades.SelectedIndexChanged += (_, _) => UpdateGradeButtonsState();
        }

        // Enables/disables subject buttons based on selection state.
        private void UpdateSubjectButtonsState()
        {
            bool hasSelection = listViewSubjects.SelectedItems.Count > 0;

            btnEditSubject.Enabled = hasSelection;
            btnRemoveSubject.Enabled = hasSelection;
        }

        // Enables/disables student buttons based on selection and availability of subjects to add.
        private void UpdateStudentButtonsState()
        {
            bool hasSelection = listViewStudents.SelectedItems.Count > 0;

            btnEditStudent.Enabled = hasSelection;
            btnRemoveStudent.Enabled = hasSelection;

            if (hasSelection)
            {
                var student = GetSelectedStudent();
                btnAddStudentSubject.Enabled = student != null && GetAvailableSubjectsForStudent(student).Any();
            }
            else
            {
                btnAddStudentSubject.Enabled = false;
            }
        }

        // Enables/disables grade edit/remove buttons based on selection.
        private void UpdateGradeButtonsState()
        {
            bool hasSelection = listViewGrades.SelectedItems.Count > 0;
            btnEditStudentSubject.Enabled = hasSelection;
            btnRemoveStudentSubject.Enabled = hasSelection;
        }

        // Gets the currently selected subject from the UI.
        private Subject? GetSelectedSubject()
        {
            if (listViewSubjects.SelectedItems.Count == 0) 
            {
                return null; 
            }

            return listViewSubjects.SelectedItems[0].Tag as Subject;
        }

        // Gets the currently selected student from the UI.
        private Student? GetSelectedStudent()
        {
            if (listViewStudents.SelectedItems.Count == 0) 
            { 
                return null; 
            }

            return listViewStudents.SelectedItems[0].Tag as Student;
        }

        // Gets the currently selected grade from the UI.
        private Grade? GetSelectedGrade()
        {
            if (listViewGrades.SelectedItems.Count == 0) 
            { 
                return null; 
            }

            return listViewGrades.SelectedItems[0].Tag as Grade;
        }

        // Returns subjects not yet graded by the specified student.
        private IReadOnlyCollection<Subject> GetAvailableSubjectsForStudent(Student student)
        {
            var assigned = student.Grades.Select(g => g.Subject.Id).ToHashSet();
            return _subjectService
                .GetAll()
                .Where(s => !assigned.Contains(s.Id))
                .ToList();
        }

        // Opens a dialog to add a new subject and refreshes the list on success.
        private void AddSubject()
        {
            using SubjectForm form = new SubjectForm();

            if (form.ShowDialog(this) == DialogResult.OK)
            {
                _subjectService
                    .Add(form.Subject.Name, form.Subject.Credits);

                RefreshSubjectsList();
            }
        }

        // Opens a dialog to edit the selected subject and refreshes lists on success.
        private void EditSelectedSubject()
        {
            Subject? subject = GetSelectedSubject();

            if (subject == null) 
            { 
                return;
            }

            using SubjectForm form = new SubjectForm(subject);

            if (form.ShowDialog(this) == DialogResult.OK)
            {
                _subjectService
                    .Update(subject.Id, subject.Name, subject.Credits);

                RefreshSubjectsList();
                RefreshStudentsList();
            }
        }

        // Removes the selected subject. If used by students, optionally cascades grade removals.
        private void RemoveSelectedSubject()
        {
            Subject? subject = GetSelectedSubject();

            if (subject == null) 
            {
                return; 
            }

            bool used = _studentService
                .GetAll()
                .Any(s => s.Grades.Any(g => g.Subject.Id == subject.Id));

            if (used)
            {
                var res = MessageDialog
                    .Show(this, "Subject has grades. Remove and cascade?", "Confirm",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (res != DialogResult.Yes)
                {
                    return;
                }

                foreach (Student student in _studentService.GetAll())
                {
                    student
                        .Grades
                        .RemoveAll(g => g.Subject.Id == subject.Id);
                }
            }

            _subjectService
                .Remove(subject.Id);

            RefreshSubjectsList();
            RefreshStudentsList();
        }

        // Opens a dialog to add a new student and refreshes the list on success.
        private void AddStudent()
        {
            using StudentForm form = new();

            if (form.ShowDialog(this) == DialogResult.OK)
            {
                _studentService
                    .Add(form.Student.Name);

                RefreshStudentsList();
            }
        }

        // Opens a dialog to edit the selected student and refreshes the list on success.
        private void EditSelectedStudent()
        {
            Student? student = GetSelectedStudent();

            if (student == null) 
            {
                return; 
            }

            using StudentForm form = new(student);

            if (form.ShowDialog(this) == DialogResult.OK)
            {
                _studentService
                    .Update(student.Id, form.Student.Name);

                RefreshStudentsList();
            }
        }

        // Removes the selected student after confirmation, then refreshes the list.
        private void RemoveSelectedStudent()
        {
            Student? student = GetSelectedStudent();

            if (student == null) 
            { 
                return; 
            }

            if (MessageDialog.Show(this, $"Remove {student.Name}?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            _studentService
                .Remove(student.Id);

            RefreshStudentsList();
        }

        // Opens a dialog to add a grade to the selected student and refreshes UI on success.
        private void AddGradeToSelectedStudent()
        {
            Student? student = GetSelectedStudent();

            if (student == null) 
            {
                return; 
            }

            var availableSubjects = GetAvailableSubjectsForStudent(student);
            if (!availableSubjects.Any())
            {
                MessageDialog.Show(this, $"{student.Name} already has grades for all subjects.", "No available subjects", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using GradeForm form = new(availableSubjects);

            if (form.ShowDialog(this) == DialogResult.OK)
            {
                _gradeService
                    .AddGrade(student, form.Grade.Subject, form.Grade.Value);

                RefreshStudentsList();
                RefreshStudentGrades();
            }
        }

        // Opens a dialog to edit the selected grade and refreshes UI on success.
        private void EditSelectedGrade()
        {
            Student? student = GetSelectedStudent();
            if (student == null)
            {
                return;
            }

            Grade? grade = GetSelectedGrade();
            if (grade == null)
            {
                return;
            }

            using GradeForm form = new(_subjectService.GetAll(), grade);
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                // Update the existing grade via service
                _gradeService.UpdateGrade(grade, form.Grade.Subject, form.Grade.Value);

                RefreshStudentsList();
                RefreshStudentGrades();
            }
        }

        // Removes the selected grade after confirmation and refreshes UI.
        private void RemoveSelectedGrade()
        {
            Student? student = GetSelectedStudent();

            if (student == null) 
            { 
                return; 
            }

            Grade? grade = GetSelectedGrade();

            if (grade == null) 
            { 
                return; 
            }

            if (MessageDialog.Show(this, $"Remove grade {grade.Value:F2} for {grade.Subject.Name}?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            _gradeService
                .RemoveGrade(student, grade);

            RefreshStudentsList();
            RefreshStudentGrades();
        }

        // Reloads the subjects list from the service and updates buttons.
        private void RefreshSubjectsList()
        {
            listViewSubjects.Items
                .Clear();

            foreach (Subject subject in _subjectService.GetAll())
            {
                ListViewItem item = new([subject.Name, subject.Credits.ToString()])
                {
                    Tag = subject
                };

                listViewSubjects
                    .Items
                    .Add(item);
            }
            UpdateSubjectButtonsState();
        }

        // Reloads the students list, calculates credits and average, and selects the first row.
        private void RefreshStudentsList()
        {
            _isRefreshingStudents = true;

            listViewStudents
                .Items
                .Clear();

            foreach (Student student in _studentService.GetAll())
            {
                int totalCredits = student.Grades
                    .Where(g => g.Value >= 3.0)
                    .Sum(g => g.Subject.Credits);
                ListViewItem item = new([student.Name, totalCredits.ToString(),
                    student.GetAverageGrade().ToString("F2")])
                {
                    Tag = student
                };

                listViewStudents
                    .Items
                    .Add(item);
            }

            if (listViewStudents.Items.Count > 0)
            {
                listViewStudents.Items[0].Selected = true;
            }

            _isRefreshingStudents = false;

            RefreshStudentGrades();
            UpdateStudentButtonsState();
        }

        // Reloads grades for the selected student and updates buttons.
        private void RefreshStudentGrades()
        {
            listViewGrades
                .Items
                .Clear();

            Student? student = GetSelectedStudent();
            if (student == null)
            {
                UpdateGradeButtonsState();
                return;
            }

            foreach (Grade grade in student.Grades)
            {
                int creditDisplay = grade.Value >= 3.0 ? grade.Subject.Credits : 0;
                ListViewItem item = new([grade.Subject.Name, grade.Value.ToString("F2"),
                    creditDisplay.ToString()])
                {
                    Tag = grade
                };

                listViewGrades
                    .Items
                    .Add(item);
            }

            UpdateGradeButtonsState();
        }
    }
}
