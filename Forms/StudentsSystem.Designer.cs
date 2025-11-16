namespace StudentsManagementSystem_Kolyo_Kolev_F113002
{
    partial class StudentsSystem
    {
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabStudents;
        private System.Windows.Forms.TabPage tabSubjects;
        private System.Windows.Forms.ListView listViewStudents;
        private System.Windows.Forms.ColumnHeader colStudentName;
        private System.Windows.Forms.ColumnHeader colStudentCredits;
        private System.Windows.Forms.ColumnHeader colStudentAverage;
        private System.Windows.Forms.ListView listViewGrades;
        private System.Windows.Forms.ColumnHeader colGradeSubject;
        private System.Windows.Forms.ColumnHeader colGradeGrade;
        private System.Windows.Forms.ColumnHeader colGradeCredits;
        private System.Windows.Forms.Button btnAddStudent;
        private System.Windows.Forms.Button btnEditStudent;
        private System.Windows.Forms.Button btnRemoveStudent; // restored remove student button
        private System.Windows.Forms.Button btnAddStudentSubject;
        private System.Windows.Forms.Button btnEditStudentSubject; // new: edit grade
        private System.Windows.Forms.ListView listViewSubjects;
        private System.Windows.Forms.ColumnHeader colSubjectName;
        private System.Windows.Forms.ColumnHeader colSubjectCredits;
        private System.Windows.Forms.Button btnAddSubject;
        private System.Windows.Forms.Button btnEditSubject;
        private System.Windows.Forms.Button btnRemoveSubject; // remove subject
        private System.Windows.Forms.Button btnRemoveStudentSubject;   // remove grade

        // Required designer variable.
        private System.ComponentModel.IContainer components = null;

        // Clean up any resources being used.
        // disposing: true if managed resources should be disposed; otherwise, false.
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        // Required method for Designer support - do not modify
        // the contents of this method with the code editor.
        private void InitializeComponent()
        {
            tabControl = new TabControl();
            tabStudents = new TabPage();
            btnRemoveStudentSubject = new Button();
            btnEditStudentSubject = new Button();
            btnAddStudentSubject = new Button();
            btnRemoveStudent = new Button();
            btnEditStudent = new Button();
            btnAddStudent = new Button();
            listViewGrades = new ListView();
            colGradeSubject = new ColumnHeader();
            colGradeGrade = new ColumnHeader();
            colGradeCredits = new ColumnHeader();
            listViewStudents = new ListView();
            colStudentName = new ColumnHeader();
            colStudentCredits = new ColumnHeader();
            colStudentAverage = new ColumnHeader();
            tabSubjects = new TabPage();
            btnRemoveSubject = new Button();
            btnEditSubject = new Button();
            btnAddSubject = new Button();
            listViewSubjects = new ListView();
            colSubjectName = new ColumnHeader();
            colSubjectCredits = new ColumnHeader();
            tabControl.SuspendLayout();
            tabStudents.SuspendLayout();
            tabSubjects.SuspendLayout();
            SuspendLayout();

            // tabControl
            tabControl.Controls.Add(tabStudents);
            tabControl.Controls.Add(tabSubjects);
            tabControl.Dock = DockStyle.Fill;
            tabControl.Location = new Point(0, 0);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(1100, 700);
            tabControl.TabIndex = 0;

            // tabStudents
            tabStudents.Controls.Add(btnRemoveStudentSubject);
            tabStudents.Controls.Add(btnEditStudentSubject);
            tabStudents.Controls.Add(btnAddStudentSubject);
            tabStudents.Controls.Add(btnRemoveStudent);
            tabStudents.Controls.Add(btnEditStudent);
            tabStudents.Controls.Add(btnAddStudent);
            tabStudents.Controls.Add(listViewGrades);
            tabStudents.Controls.Add(listViewStudents);
            tabStudents.Location = new Point(4, 34);
            tabStudents.Name = "tabStudents";
            tabStudents.Padding = new Padding(3);
            tabStudents.Size = new Size(1092, 662);
            tabStudents.TabIndex = 0;
            tabStudents.Text = "Students";
            tabStudents.UseVisualStyleBackColor = true;

            // btnRemoveStudentSubject
            btnRemoveStudentSubject.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRemoveStudentSubject.Location = new Point(894, 578);
            btnRemoveStudentSubject.Name = "btnRemoveStudentSubject";
            btnRemoveStudentSubject.Size = new Size(190, 37);
            btnRemoveStudentSubject.TabIndex = 7;
            btnRemoveStudentSubject.Text = "Remove Subject";
            btnRemoveStudentSubject.UseVisualStyleBackColor = true;

            // btnEditStudentSubject
            btnEditStudentSubject.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnEditStudentSubject.Location = new Point(896, 497);
            btnEditStudentSubject.Name = "btnEditStudentSubject";
            btnEditStudentSubject.Size = new Size(190, 37);
            btnEditStudentSubject.TabIndex = 6;
            btnEditStudentSubject.Text = "Edit Subject";
            btnEditStudentSubject.UseVisualStyleBackColor = true;

            // btnAddStudentSubject
            btnAddStudentSubject.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAddStudentSubject.Location = new Point(896, 416);
            btnAddStudentSubject.Name = "btnAddStudentSubject";
            btnAddStudentSubject.Size = new Size(190, 37);
            btnAddStudentSubject.TabIndex = 5;
            btnAddStudentSubject.Text = "Add Subject";
            btnAddStudentSubject.UseVisualStyleBackColor = true;

            // btnRemoveStudent
            btnRemoveStudent.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRemoveStudent.Location = new Point(894, 204);
            btnRemoveStudent.Name = "btnRemoveStudent";
            btnRemoveStudent.Size = new Size(190, 37);
            btnRemoveStudent.TabIndex = 4;
            btnRemoveStudent.Text = "Remove Student";
            btnRemoveStudent.UseVisualStyleBackColor = true;

            // btnEditStudent
            btnEditStudent.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnEditStudent.Location = new Point(896, 121);
            btnEditStudent.Name = "btnEditStudent";
            btnEditStudent.Size = new Size(190, 37);
            btnEditStudent.TabIndex = 3;
            btnEditStudent.Text = "Edit Student";
            btnEditStudent.UseVisualStyleBackColor = true;

            // btnAddStudent
            btnAddStudent.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAddStudent.Location = new Point(896, 40);
            btnAddStudent.Name = "btnAddStudent";
            btnAddStudent.Size = new Size(190, 37);
            btnAddStudent.TabIndex = 2;
            btnAddStudent.Text = "Add Student";
            btnAddStudent.UseVisualStyleBackColor = true;

            // listViewGrades
            listViewGrades.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listViewGrades.Columns.AddRange(new ColumnHeader[] { colGradeSubject, colGradeGrade, colGradeCredits });
            listViewGrades.FullRowSelect = true;
            listViewGrades.Location = new Point(6, 373);
            listViewGrades.MultiSelect = false;
            listViewGrades.Name = "listViewGrades";
            listViewGrades.Size = new Size(884, 281);
            listViewGrades.TabIndex = 1;
            listViewGrades.UseCompatibleStateImageBehavior = false;
            listViewGrades.View = View.Details;

            // colGradeSubject
            colGradeSubject.Text = "Subject";
            colGradeSubject.Width = 350;

            // colGradeGrade
            colGradeGrade.Text = "Grade";
            colGradeGrade.Width = 250;

            // colGradeCredits
            colGradeCredits.Text = "Credits";
            colGradeCredits.Width = 280;

            // listViewStudents
            listViewStudents.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            listViewStudents.Columns.AddRange(new ColumnHeader[] { colStudentName, colStudentCredits, colStudentAverage });
            listViewStudents.FullRowSelect = true;
            listViewStudents.Location = new Point(6, 6);
            listViewStudents.MultiSelect = false;
            listViewStudents.Name = "listViewStudents";
            listViewStudents.Size = new Size(884, 281);
            listViewStudents.TabIndex = 0;
            listViewStudents.UseCompatibleStateImageBehavior = false;
            listViewStudents.View = View.Details;

            // colStudentName
            colStudentName.Text = "Name";
            colStudentName.Width = 350;

            // colStudentCredits
            colStudentCredits.Text = "Credits";
            colStudentCredits.Width = 250;

            // colStudentAverage
            colStudentAverage.Text = "Average";
            colStudentAverage.Width = 280;

            // tabSubjects
            tabSubjects.Controls.Add(btnRemoveSubject);
            tabSubjects.Controls.Add(btnEditSubject);
            tabSubjects.Controls.Add(btnAddSubject);
            tabSubjects.Controls.Add(listViewSubjects);
            tabSubjects.Location = new Point(4, 34);
            tabSubjects.Name = "tabSubjects";
            tabSubjects.Padding = new Padding(3);
            tabSubjects.Size = new Size(1092, 662);
            tabSubjects.TabIndex = 1;
            tabSubjects.Text = "Subjects";
            tabSubjects.UseVisualStyleBackColor = true;

            // btnRemoveSubject
            btnRemoveSubject.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRemoveSubject.Location = new Point(914, 459);
            btnRemoveSubject.Name = "btnRemoveSubject";
            btnRemoveSubject.Size = new Size(170, 62);
            btnRemoveSubject.TabIndex = 3;
            btnRemoveSubject.Text = "Remove Subject";
            btnRemoveSubject.UseVisualStyleBackColor = true;

            // btnEditSubject
            btnEditSubject.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnEditSubject.Location = new Point(914, 275);
            btnEditSubject.Name = "btnEditSubject";
            btnEditSubject.Size = new Size(170, 62);
            btnEditSubject.TabIndex = 2;
            btnEditSubject.Text = "Edit Subject";
            btnEditSubject.UseVisualStyleBackColor = true;

            // btnAddSubject
            btnAddSubject.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAddSubject.Location = new Point(914, 109);
            btnAddSubject.Name = "btnAddSubject";
            btnAddSubject.Size = new Size(170, 62);
            btnAddSubject.TabIndex = 1;
            btnAddSubject.Text = "Add Subject";
            btnAddSubject.UseVisualStyleBackColor = true;

            // listViewSubjects
            listViewSubjects.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listViewSubjects.Columns.AddRange(new ColumnHeader[] { colSubjectName, colSubjectCredits });
            listViewSubjects.FullRowSelect = true;
            listViewSubjects.Location = new Point(6, 6);
            listViewSubjects.MultiSelect = false;
            listViewSubjects.Name = "listViewSubjects";
            listViewSubjects.Size = new Size(902, 618);
            listViewSubjects.TabIndex = 0;
            listViewSubjects.UseCompatibleStateImageBehavior = false;
            listViewSubjects.View = View.Details;

            // colSubjectName
            colSubjectName.Text = "Name";
            colSubjectName.Width = 450;

            // colSubjectCredits
            colSubjectCredits.Text = "Credits";
            colSubjectCredits.Width = 448;

            // StudentsSystem
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1100, 700);
            Controls.Add(tabControl);
            Font = new Font("Segoe UI", 11F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "StudentsSystem";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Students System";
            tabControl.ResumeLayout(false);
            tabStudents.ResumeLayout(false);
            tabSubjects.ResumeLayout(false);
            ResumeLayout(false);

        }

        #endregion
    }
}
