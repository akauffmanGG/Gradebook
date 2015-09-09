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
        private Color darkPurpleColor = Color.FromArgb(103, 16, 150);
        private Color lightPurpleColor = Color.FromArgb(230, 178, 255);
        private Color purpleColor = Color.FromArgb(178, 137, 196);
        private Color mintColor = Color.FromArgb(210, 239, 221);
        private Color yellowColor = Color.FromArgb(255, 253, 190);

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
            this.DefaultCellStyle.BackColor = lightPurpleColor;
            this.DefaultCellStyle.SelectionBackColor = yellowColor;
            this.DefaultCellStyle.SelectionForeColor = ThemeColors.FORE_COLOR;
            //this.DefaultCellStyle.Font = new Font(this.DefaultCellStyle.Font, FontStyle.Bold);
            this.DefaultCellStyle.Font = new Font("Calibri", 9.5f, FontStyle.Bold);
            this.ForeColor = ThemeColors.FORE_COLOR;
            
            this.BackgroundColor = mintColor;
            
        }

        #endregion
    }
}
