using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using Gradebook.View.Theme;

namespace Gradebook.View
{
    public partial class StyledGrid : DataGridView
    {
        public StyledGrid()
        {
            InitializeComponent();
            DoubleBuffered = true;
        }

        protected override void PaintBackground(Graphics graphics, Rectangle clipBounds, Rectangle gridBounds)
        {
            base.PaintBackground(graphics, clipBounds, gridBounds);

            LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle, Color.White, ThemeColors.BACKGROUND_COLOR, LinearGradientMode.Vertical);

            graphics.FillRectangle(brush, clipBounds);
        }
    }
}
