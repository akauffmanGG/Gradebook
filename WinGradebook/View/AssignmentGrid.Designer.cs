using System.Windows.Forms;
using Gradebook.View.Calendar;
namespace Gradebook.View
{
    partial class AssignmentGrid
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.DataGridViewTextBoxColumn nameColumn;
        private CalendarColumn assignmentDateColumn;
        private CalendarColumn dueDateColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pointsColumn;

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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.nameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.assignmentDateColumn = new Gradebook.View.Calendar.CalendarColumn();
            this.dueDateColumn = new Gradebook.View.Calendar.CalendarColumn();
            this.pointsColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // nameColumn
            // 
            this.nameColumn.DataPropertyName = "Name";
            this.nameColumn.HeaderText = "Name";
            this.nameColumn.Name = "nameColumn";
            this.nameColumn.Width = 60;
            // 
            // assignmentDateColumn
            // 
            this.assignmentDateColumn.DataPropertyName = "AssignmentDate";
            dataGridViewCellStyle3.Format = "mm/dd/yy";
            this.assignmentDateColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.assignmentDateColumn.HeaderText = "Assignment Date";
            this.assignmentDateColumn.Name = "assignmentDateColumn";
            this.assignmentDateColumn.Width = 103;
            // 
            // dueDateColumn
            // 
            this.dueDateColumn.DataPropertyName = "DueDate";
            dataGridViewCellStyle4.Format = "mm/dd/yy";
            this.dueDateColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.dueDateColumn.HeaderText = "Due Date";
            this.dueDateColumn.Name = "dueDateColumn";
            this.dueDateColumn.Width = 72;
            // 
            // pointsColumn
            // 
            this.pointsColumn.DataPropertyName = "Points";
            this.pointsColumn.HeaderText = "Points";
            this.pointsColumn.Name = "pointsColumn";
            this.pointsColumn.Width = 61;
            // 
            // AssignmentGrid
            // 
            this.AllowUserToOrderColumns = true;
            this.AutoGenerateColumns = false;
            this.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameColumn,
            this.assignmentDateColumn,
            this.dueDateColumn,
            this.pointsColumn});
            this.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.AssignmentGrid_CellEndEdit);
            this.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.AssignmentGrid_UserDeletedRow);
            this.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.AssignmentGrid_UserDeletingRow);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
    }
}
