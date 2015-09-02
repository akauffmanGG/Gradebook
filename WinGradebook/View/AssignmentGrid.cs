using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Gradebook.View
{
    public partial class AssignmentGrid : DataGridView
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
    }
}
