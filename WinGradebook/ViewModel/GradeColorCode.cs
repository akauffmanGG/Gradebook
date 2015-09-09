using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Gradebook.View.Theme;

namespace Gradebook.ViewModel
{
    class GradeColorCode
    {
        private static double LOW_THRESHOLD = .5;
        private static double MID_THRESHOLD = .75;

        public static Color getColor(double gradePercentage)
        {
            if (gradePercentage <= LOW_THRESHOLD)
            {
                return ThemeColors.LOW_GRADE;
            }
            else if (gradePercentage <= MID_THRESHOLD)
            {

                return ThemeColors.MID_GRADE;
            }
            else
            {
                return ThemeColors.CELL_BACK_COLOR;
            }
        }
    }
}
