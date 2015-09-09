namespace Gradebook
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dgStudents = new Gradebook.View.StyledGrid();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tbGrades = new System.Windows.Forms.TabPage();
            this.tbAssignments = new System.Windows.Forms.TabPage();
            this.tbStudents = new System.Windows.Forms.TabPage();
            this.tbCourses = new System.Windows.Forms.TabPage();
            this.dgCourses = new Gradebook.View.StyledGrid();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.lastNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.firstNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.studentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.courseViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgStudents)).BeginInit();
            this.tabControl.SuspendLayout();
            this.tbStudents.SuspendLayout();
            this.tbCourses.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgCourses)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.studentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.courseViewModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dgStudents
            // 
            this.dgStudents.AllowUserToOrderColumns = true;
            this.dgStudents.AutoGenerateColumns = false;
            this.dgStudents.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgStudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgStudents.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.lastNameDataGridViewTextBoxColumn,
            this.firstNameDataGridViewTextBoxColumn});
            this.dgStudents.DataSource = this.studentBindingSource;
            this.dgStudents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgStudents.Location = new System.Drawing.Point(3, 3);
            this.dgStudents.Name = "dgStudents";
            this.dgStudents.Size = new System.Drawing.Size(670, 389);
            this.dgStudents.TabIndex = 0;
            this.dgStudents.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgStudents_UserDeletingRow);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tbGrades);
            this.tabControl.Controls.Add(this.tbAssignments);
            this.tabControl.Controls.Add(this.tbStudents);
            this.tabControl.Controls.Add(this.tbCourses);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(684, 421);
            this.tabControl.TabIndex = 1;
            // 
            // tbGrades
            // 
            this.tbGrades.Location = new System.Drawing.Point(4, 22);
            this.tbGrades.Name = "tbGrades";
            this.tbGrades.Padding = new System.Windows.Forms.Padding(3);
            this.tbGrades.Size = new System.Drawing.Size(676, 395);
            this.tbGrades.TabIndex = 2;
            this.tbGrades.Text = "Grades";
            this.tbGrades.UseVisualStyleBackColor = true;
            // 
            // tbAssignments
            // 
            this.tbAssignments.Location = new System.Drawing.Point(4, 22);
            this.tbAssignments.Name = "tbAssignments";
            this.tbAssignments.Padding = new System.Windows.Forms.Padding(3);
            this.tbAssignments.Size = new System.Drawing.Size(676, 395);
            this.tbAssignments.TabIndex = 1;
            this.tbAssignments.Text = "Assignments";
            this.tbAssignments.UseVisualStyleBackColor = true;
            // 
            // tbStudents
            // 
            this.tbStudents.Controls.Add(this.dgStudents);
            this.tbStudents.Location = new System.Drawing.Point(4, 22);
            this.tbStudents.Name = "tbStudents";
            this.tbStudents.Padding = new System.Windows.Forms.Padding(3);
            this.tbStudents.Size = new System.Drawing.Size(676, 395);
            this.tbStudents.TabIndex = 0;
            this.tbStudents.Text = "Students";
            this.tbStudents.UseVisualStyleBackColor = true;
            // 
            // tbCourses
            // 
            this.tbCourses.Controls.Add(this.dgCourses);
            this.tbCourses.Location = new System.Drawing.Point(4, 22);
            this.tbCourses.Name = "tbCourses";
            this.tbCourses.Padding = new System.Windows.Forms.Padding(3);
            this.tbCourses.Size = new System.Drawing.Size(676, 395);
            this.tbCourses.TabIndex = 3;
            this.tbCourses.Text = "Courses";
            this.tbCourses.UseVisualStyleBackColor = true;
            // 
            // dgCourses
            // 
            this.dgCourses.AutoGenerateColumns = false;
            this.dgCourses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgCourses.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn});
            this.dgCourses.DataSource = this.courseViewModelBindingSource;
            this.dgCourses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgCourses.Location = new System.Drawing.Point(3, 3);
            this.dgCourses.Name = "dgCourses";
            this.dgCourses.Size = new System.Drawing.Size(670, 389);
            this.dgCourses.TabIndex = 0;
            this.dgCourses.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgCourses_UserDeletingRow);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 421);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(684, 41);
            this.panel1.TabIndex = 4;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(4, 8);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lastNameDataGridViewTextBoxColumn
            // 
            this.lastNameDataGridViewTextBoxColumn.DataPropertyName = "LastName";
            this.lastNameDataGridViewTextBoxColumn.HeaderText = "Last Name";
            this.lastNameDataGridViewTextBoxColumn.Name = "lastNameDataGridViewTextBoxColumn";
            this.lastNameDataGridViewTextBoxColumn.Width = 83;
            // 
            // firstNameDataGridViewTextBoxColumn
            // 
            this.firstNameDataGridViewTextBoxColumn.DataPropertyName = "FirstName";
            this.firstNameDataGridViewTextBoxColumn.HeaderText = "First Name";
            this.firstNameDataGridViewTextBoxColumn.Name = "firstNameDataGridViewTextBoxColumn";
            this.firstNameDataGridViewTextBoxColumn.Width = 82;
            // 
            // studentBindingSource
            // 
            this.studentBindingSource.DataSource = typeof(Gradebook.Model.Student);
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            // 
            // courseViewModelBindingSource
            // 
            this.courseViewModelBindingSource.DataSource = typeof(Gradebook.ViewModel.CourseViewModel);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 462);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.panel1);
            this.Name = "MainForm";
            this.Text = "Gradebook";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgStudents)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.tbStudents.ResumeLayout(false);
            this.tbCourses.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgCourses)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.studentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.courseViewModelBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Gradebook.View.StyledGrid dgStudents;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn firstNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource studentBindingSource;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tbStudents;
        private System.Windows.Forms.TabPage tbAssignments;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TabPage tbGrades;
        private System.Windows.Forms.TabPage tbCourses;
        private Gradebook.View.StyledGrid dgCourses;
        private System.Windows.Forms.BindingSource courseViewModelBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;

    }
}

