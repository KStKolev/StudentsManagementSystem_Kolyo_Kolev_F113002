using StudentsManagementSystem_Kolyo_Kolev_F113002.Models;

namespace StudentsManagementSystem_Kolyo_Kolev_F113002;

public sealed class GradeForm : Form
{
    private readonly ComboBox _cmbSubject = new() { DropDownStyle = ComboBoxStyle.DropDownList, Width = 250 };
    private readonly NumericUpDown _numValue = new() { Minimum = 2, Maximum = 6, DecimalPlaces = 2, Increment = 0.25M, Value = 3, Width = 100 };
    private readonly Button _btnOk = new() { Text = "OK", DialogResult = DialogResult.OK, Size = new Size(110, 38) };
    private readonly Button _btnCancel = new() { Text = "Cancel", DialogResult = DialogResult.Cancel, Size = new Size(110, 38) };

    private readonly bool _isEdit;
    private readonly Grade _gradeRef;

    // Gets the grade being created or edited.
    public Grade Grade => _gradeRef;

    // Creates a dialog to add a new grade for one of the provided subjects.
    // subjects: Subjects that can be selected for the new grade.
    public GradeForm(IReadOnlyCollection<Subject> subjects)
    {
        _isEdit = false;
        _gradeRef = new Grade(subjects.First(), 2);
        InitializeUi(subjects);
    }

    // Creates a dialog to edit an existing grade.
    // subjects: All subjects (used to populate UI if needed).
    // existing: The grade to edit.
    public GradeForm(IReadOnlyCollection<Subject> subjects, Grade existing)
    {
        _isEdit = true;
        _gradeRef = existing;
        InitializeUi(subjects);

        _numValue.Value = (decimal)existing.Value;
    }

    // Builds the dialog UI and wires validation for the OK button.
    // subjects: Subjects to display when adding a grade.
    private void InitializeUi(IReadOnlyCollection<Subject> subjects)
    {
        Text = _isEdit ? "Edit Grade" : "Add Grade";
        StartPosition = FormStartPosition.CenterParent;
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        ClientSize = new Size(420, 170);

        Label lblSubject = new() { Text = "Subject:", AutoSize = true, Location = new Point(12, 18) };
        _cmbSubject.Location = new Point(100, 15);

        if (!_isEdit)
        {
            _cmbSubject.DataSource = subjects
                .ToList();

            _cmbSubject.DisplayMember = nameof(Subject.Name);
        }

        Label lblValue = new() { Text = "Value:", AutoSize = true, Location = new Point(12, _isEdit ? 18 : 58) };
        _numValue.Location = new Point(100, _isEdit ? 15 : 55);

        int spacing = 12;
        int totalWidth = _btnOk.Width + spacing + _btnCancel.Width;

        int startX = (ClientSize.Width - totalWidth) / 2;
        int startY = ClientSize.Height - _btnOk.Height - 12;
        _btnOk.Location = new Point(startX, startY);
        _btnCancel.Location = new Point(startX + _btnOk.Width + spacing, startY);

        if (_isEdit)
        {
            Controls.AddRange([lblValue, _numValue, _btnOk, _btnCancel]);
        }
        else
        {
            Controls.AddRange([lblSubject, _cmbSubject, lblValue, _numValue, _btnOk, _btnCancel]);
        }

        AcceptButton = _btnOk;
        CancelButton = _btnCancel;

        _btnOk.Click += (_, _) =>
        {
            var subject = _isEdit ? _gradeRef.Subject : _cmbSubject.SelectedItem as Subject;

            if (subject == null)
            {
                MessageBox.Show(this, "Select a subject", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DialogResult = DialogResult.None;
                return;
            }

            if (!_isEdit)
            {
                _gradeRef.Subject = subject; // only set subject when adding
            }

            _gradeRef.Value = (double)_numValue.Value; // always allow changing value
        };
    }
}
