using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Gradebook.ViewModel.Service;

namespace Gradebook.View
{
    public partial class AssignmentGrid : StyledGrid
    {
        public AssignmentGrid()
        {
            InitializeComponent();
        }

        private void AssignmentGrid_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (!e.Row.IsNewRow)
            {
                if ((MessageBox.Show("All student grades for this assignment will be lost.", "Are you sure you want to delete this assignment?", MessageBoxButtons.OKCancel) == DialogResult.Cancel))
                {
                    e.Cancel = true;
                }
            }
        }

        private void AssignmentGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            StateManager.MarkDirty();
        }

        private void AssignmentGrid_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            StateManager.MarkDirty();
        }
    }
}
