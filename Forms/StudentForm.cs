using StudentsManagementSystem_Kolyo_Kolev_F113002.Models;

namespace StudentsManagementSystem_Kolyo_Kolev_F113002;

// Dialog for adding or editing a student.
public sealed class StudentForm : Form
{
    private readonly TextBox _txtName = new() { Width = 220 };
    private readonly Button _btnOk = new() { Text = "OK", DialogResult = DialogResult.OK, Size = new Size(110, 38) };
    private readonly Button _btnCancel = new() { Text = "Cancel", DialogResult = DialogResult.Cancel, Size = new Size(110, 38) };

    private readonly bool _isEdit;
    private Student _student;

    // Gets the student being created or edited.
    public Student Student => _student;

    // Creates a dialog to add a new student.
    public StudentForm()
    {
        _isEdit = false;
        _student = new Student { Name = string.Empty };
        InitializeUi();
    }

    // Creates a dialog to edit an existing student.
    // existing: The student to edit.
    public StudentForm(Student existing)
    {
        _isEdit = true;
        _student = existing; // keep reference
        InitializeUi();

        _txtName.Text = existing.Name;
    }

    // Builds the dialog UI and validates name on confirm.
    private void InitializeUi()
    {
        Text = _isEdit ? "Edit Student" : "Add Student";
        StartPosition = FormStartPosition.CenterParent;
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        ClientSize = new Size(380, 160);

        Label lblName = new() { Text = "Name:", AutoSize = true };

        lblName.Location = new Point(12, 48);
        _txtName.Location = new Point(100, 45);

        int spacing = 12;
        int totalWidth = _btnOk.Width + spacing + _btnCancel.Width;
        int startX = (ClientSize.Width - totalWidth) / 2;
        int startY = ClientSize.Height - _btnOk.Height - 12;
        _btnOk.Location = new Point(startX, startY);
        _btnCancel.Location = new Point(startX + _btnOk.Width + spacing, startY);

        Controls.AddRange([lblName, _txtName, _btnOk, _btnCancel]);

        AcceptButton = _btnOk;
        CancelButton = _btnCancel;

        _btnOk.Click += (_, _) =>
        {
            string name = _txtName.Text.Trim();

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show(this, "Student name required", "Validation Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                DialogResult = DialogResult.None; // keep dialog open
                return;
            }

            _student.Name = name;
        };
    }
}
