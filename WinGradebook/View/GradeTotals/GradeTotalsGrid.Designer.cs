namespace Gradebook.View.GradeTotals
{
    partial class GradeTotalsGrid
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridViewTextBoxColumn studentNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn classPeriodColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalGradeColumn;

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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.studentNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.classPeriodColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalGradeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // studentNameColumn
            // 
            this.studentNameColumn.DataPropertyName = "FormattedName";
            this.studentNameColumn.HeaderText = "Student";
            this.studentNameColumn.Name = "studentNameColumn";
            this.studentNameColumn.ReadOnly = true;
            // 
            // classPeriodColumn
            // 
            this.classPeriodColumn.DataPropertyName = "ClassPeriod";
            this.classPeriodColumn.HeaderText = "Class";
            this.classPeriodColumn.Name = "classPeriodColumn";
            this.classPeriodColumn.ReadOnly = true;
            // 
            // totalGradeColumn
            // 
            dataGridViewCellStyle1.Format = "P";
            this.totalGradeColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.totalGradeColumn.HeaderText = "Total Grade";
            this.totalGradeColumn.Name = "totalGradeColumn";
            this.totalGradeColumn.ReadOnly = true;
            this.totalGradeColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // GradeTotalsGrid
            // 
            this.AllowUserToAddRows = false;
            this.AllowUserToDeleteRows = false;
            this.AllowUserToOrderColumns = true;
            this.AutoGenerateColumns = false;
            this.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.studentNameColumn,
            this.classPeriodColumn,
            this.totalGradeColumn});
            this.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.GradeTotalsGrid_CellFormatting);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
    }
}
