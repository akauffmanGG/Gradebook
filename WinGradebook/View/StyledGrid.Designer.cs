using System.Drawing;
using Gradebook.View.Theme;
namespace Gradebook.View
{
    partial class StyledGrid
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            // Header Styles //
            this.EnableHeadersVisualStyles = false;
            this.ColumnHeadersDefaultCellStyle.BackColor = ThemeColors.HEADER_BACK_COLOR;
            this.ColumnHeadersDefaultCellStyle.Font = new Font("Calibri", 9.5f, FontStyle.Bold);
            this.ColumnHeadersDefaultCellStyle.ForeColor = ThemeColors.FORE_COLOR;

            this.RowHeadersDefaultCellStyle.BackColor = ThemeColors.HEADER_BACK_COLOR;

            // Cell Styles //
            this.DefaultCellStyle.BackColor = ThemeColors.CELL_BACK_COLOR;
            this.DefaultCellStyle.SelectionBackColor = ThemeColors.SELECTION_BACK_COLOR;
            this.DefaultCellStyle.SelectionForeColor = ThemeColors.FORE_COLOR;
            this.DefaultCellStyle.Font = new Font("Calibri", 9.5f, FontStyle.Bold);
            this.ForeColor = ThemeColors.FORE_COLOR;

            this.BackgroundColor = ThemeColors.BACKGROUND_COLOR;
            
        }

        #endregion
    }
}
