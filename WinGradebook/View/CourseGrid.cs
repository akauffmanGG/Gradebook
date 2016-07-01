using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Gradebook.ViewModel;
using Gradebook.ViewModel.Service;

namespace Gradebook.View
{
    public partial class CourseGrid : StyledGrid
    {
        [Description("Grid of all students."), Category("Data"), Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
        private GradebookViewModel gradebookVm;

        public CourseGrid()
        {
            InitializeComponent();
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();

            gradebookVm = GradebookViewModel.Instance;
            this.AutoGenerateColumns = false;
            this.DataSource = gradebookVm.Courses;
        }


        private void CourseGrid_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (!e.Row.IsNewRow)
            {
                if ((MessageBox.Show("All grades for this course will be lost.", "Are you sure you want to delete this course?", MessageBoxButtons.OKCancel) == DialogResult.Cancel))
                {
                    e.Cancel = true;
                }
            }
        }

        private void CourseGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            StateManager.MarkDirty();
        }

        private void CourseGrid_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            StateManager.MarkDirty();
        }
    }
}
