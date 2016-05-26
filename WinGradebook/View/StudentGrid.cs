using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Gradebook.ViewModel;

namespace Gradebook.View
{
    public partial class StudentGrid : StyledGrid
    {
        [Description("Grid of all students."), Category("Data"), Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
        private GradebookViewModel gradebookVm;
        public StudentGrid()
        {
            InitializeComponent();
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();

            gradebookVm = GradebookViewModel.Instance;
            this.DataSource = gradebookVm.Students;
        }


        private void StudentGrid_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (!e.Row.IsNewRow)
            {
                if ((MessageBox.Show("All grades for this student will be lost.", "Are you sure you want to delete this student?", MessageBoxButtons.OKCancel) == DialogResult.Cancel))
                {
                    e.Cancel = true;
                }
            }
        }

    }
}
