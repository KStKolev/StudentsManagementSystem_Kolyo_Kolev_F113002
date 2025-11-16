using StudentsManagementSystem_Kolyo_Kolev_F113002.Models;

namespace StudentsManagementSystem_Kolyo_Kolev_F113002;

// Dialog for adding or editing a subject.
public sealed class SubjectForm : Form
{
    private readonly TextBox _txtName = new() { Width = 220 };
    private readonly NumericUpDown _numCredits = new() { Minimum = 1, Maximum = 60, Value = 5, Width = 80 };
    private readonly Button _btnOk = new() { Text = "OK", DialogResult = DialogResult.OK, Size = new Size(100, 36) };
    private readonly Button _btnCancel = new() { Text = "Cancel", DialogResult = DialogResult.Cancel, Size = new Size(100, 36) };

    private readonly bool _isEdit;
    private readonly Subject _subjectRef;

    // Gets the subject instance being created or edited.
    public Subject Subject => _subjectRef;

    // Creates a dialog to add a new subject.
    public SubjectForm()
    {
        _isEdit = false;
        _subjectRef = new Subject { Name = string.Empty, Credits = 1 };

        InitializeUi();
    }

    // Creates a dialog to edit an existing subject.
    // subject: The subject to edit.
    public SubjectForm(Subject subject)
    {
        _isEdit = true;
        _subjectRef = subject; // keep same reference so caller sees edits

        InitializeUi();

        _txtName.Text = subject.Name;
        _numCredits.Value = subject.Credits;
    }

    // Builds the dialog UI and validates input when confirming.
    private void InitializeUi()
    {
        Text = _isEdit ? "Edit Subject" : "Add Subject";
        StartPosition = FormStartPosition.CenterParent;
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        ClientSize = new Size(360, 150);

        Label lblName = new() { Text = "Name:", AutoSize = true, Location = new Point(12, 18) };
        _txtName.Location = new Point(100, 15);

        Label lblCredits = new() { Text = "Credits:", AutoSize = true, Location = new Point(12, 58) };
        _numCredits.Location = new Point(100, 55);

        int spacing = 12;
        int totalWidth = _btnOk.Width + spacing + _btnCancel.Width;
        int startX = (ClientSize.Width - totalWidth) / 2;
        int startY = ClientSize.Height - _btnOk.Height - 12;

        _btnOk.Location = new Point(startX, startY);
        _btnCancel.Location = new Point(startX + _btnOk.Width + spacing, startY);

        Controls.AddRange([lblName, _txtName, lblCredits, _numCredits, _btnOk, _btnCancel]);

        AcceptButton = _btnOk;
        CancelButton = _btnCancel;

        _btnOk.Click += (_, _) =>
        {
            try
            {
                string name = _txtName
                    .Text
                    .Trim();

                if (string.IsNullOrWhiteSpace(name))
                {
                    throw new ArgumentException("Subject name required");
                }

                _subjectRef.Name = name;
                _subjectRef.Credits = (int)_numCredits.Value;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DialogResult = DialogResult.None; // keep dialog open
            }
        };
    }
}
