using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Gradebook.View.Theme
{
    class ThemeColors
    {
        //FORM COLORS
        public static Color FORE_COLOR = Color.FromArgb(103, 16, 150); //Dark Purple
        public static Color CELL_BACK_COLOR = Color.FromArgb(230, 178, 255); //Light purple
        public static Color HEADER_BACK_COLOR = Color.FromArgb(178, 137, 196); //Purple
        public static Color BACKGROUND_COLOR = Color.FromArgb(210, 239, 221); // Mint
        public static Color SELECTION_BACK_COLOR = Color.FromArgb(255, 253, 190); //Yellow

        //GRADE COLORS
        public static Color LOW_GRADE = Color.FromArgb(255, 170, 170); //Light Red
        public static Color MID_GRADE = Color.FromArgb(255, 233, 127); //Yellow
    }
}
