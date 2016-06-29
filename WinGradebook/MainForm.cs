using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Gradebook.Model;
using Gradebook.Data;
using Gradebook.View;
using Gradebook.ViewModel;

namespace Gradebook
{
    public partial class MainForm : Form
    {
        private GradebookViewModel gradebookVM;
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

            gradebookVM = GradebookViewModel.Instance;

            dgCourses.AutoGenerateColumns = false;
            dgCourses.DataSource = gradebookVM.Courses;

            dgStudents.AutoGenerateColumns = false;

            tbGrades.Controls.Add(new GradeTabControl());
            tbAssignments.Controls.Add(new AssignmentTabControl());

            //applyTheme();
        }

        private void setupComponent()
        {
            dgCourses.DataSource = gradebookVM.Courses;
            dgStudents.DataSource = gradebookVM.Students;

            tbGrades.Controls.Add(new GradeTabControl());
            tbAssignments.Controls.Add(new AssignmentTabControl());
        }

        private void resetupComponent()
        {
            tbGrades.Controls.Clear();
            tbAssignments.Controls.Clear();

            setupComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            gradebookVM.Save();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gradebookVM.Save();
        }

        private void applyTheme()
        {
            

            //Color purpleColor = Color.FromArgb(99, 66, 113);
            
            //Color mintColor = Color.FromArgb(144, 197, 169);
            //Color mintColor = Color.FromArgb(195, 224, 208);
            
            Color peachColor = Color.FromArgb(250, 139, 96);
            Color orangeColor = Color.FromArgb(239, 109, 59);
            Color yellowColor = Color.FromArgb(255, 212, 82);

            Color purpleColor = Color.FromArgb(176, 170, 194);
            Color lightPurpleColor = Color.FromArgb(178, 137, 196);
            Color mintColor = Color.FromArgb(219, 233, 216);
            Color creamColor = Color.FromArgb(242, 239, 232);
            Color blueColor = Color.FromArgb(194, 212, 216);

            dgStudents.EnableHeadersVisualStyles = false;
            dgStudents.ColumnHeadersDefaultCellStyle.BackColor = lightPurpleColor;
            dgStudents.DefaultCellStyle.BackColor = purpleColor;
            dgStudents.DefaultCellStyle.SelectionBackColor = blueColor;
            dgStudents.BackgroundColor = mintColor;
            dgStudents.ForeColor = creamColor;
        }

        private void dgCourses_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (!e.Row.IsNewRow)
            {
                if ((MessageBox.Show("All assignments and associated grades for this course will be lost.",  "Are you sure you want to delete this course?", MessageBoxButtons.OKCancel) == DialogResult.Cancel))
                {
                    e.Cancel = true;
                }
            }
        }

        private void gradingPeriodToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GradingPeriodPrompt gradingPeriodPrompt = new GradingPeriodPrompt();
            DialogResult dr = gradingPeriodPrompt.ShowDialog(this);

            if (dr == DialogResult.Cancel)
            {
                gradingPeriodPrompt.Close();
            }
            else if (dr == DialogResult.OK)
            {
                gradebookVM.SchoolYear.CurrentGradingPeriod.Name = gradingPeriodPrompt.getName();
                gradebookVM.SchoolYear.CreateGradingPeriodFromCurrent();
                gradingPeriodPrompt.Close();

                resetupComponent();
            }
            
        }

        private void priorGradingPeriodToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenPriorGradingPeriod openGradingPeriod = new OpenPriorGradingPeriod(gradebookVM.SchoolYear.GradingPeriods);
            DialogResult dr = openGradingPeriod.ShowDialog(this);

            if (dr == DialogResult.Cancel)
            {
                openGradingPeriod.Close();
            }
            else if (dr == DialogResult.OK)
            {
                gradebookVM.GradingPeriod = openGradingPeriod.getGradingPeriod();
                openGradingPeriod.Close();

                resetupComponent();
            }
        }

        private void schoolYearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SchoolYearPrompt schoolYearPrompt = new SchoolYearPrompt();
            DialogResult dr = schoolYearPrompt.ShowDialog(this);

            if (dr == DialogResult.Cancel)
            {
                schoolYearPrompt.Close();
            }
            else if (dr == DialogResult.OK)
            {
                gradebookVM.SchoolYear.Name = schoolYearPrompt.getName();
                gradebookVM.CreateSchoolYearFromCurrent();
                schoolYearPrompt.Close();

                resetupComponent();
            }

        }
    }
}
