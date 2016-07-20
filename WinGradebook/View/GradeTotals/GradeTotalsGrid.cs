using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Gradebook.ViewModel;

namespace Gradebook.View.GradeTotals
{
    public partial class GradeTotalsGrid : StyledGrid
    {
        private Guid courseId;
        private BindingList<StudentViewModel> students;
        private List<GradingPeriodViewModel> gradingPeriods;

        public GradeTotalsGrid(Guid _courseId, BindingList<StudentViewModel> _students, List<GradingPeriodViewModel> _gradingPeriods)
        {
            InitializeComponent();

            this.courseId = _courseId;
            this.students = _students;
            this.gradingPeriods = _gradingPeriods;
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();

            this.DataSource = students;

            addGradingPeriodColumns();

        }

        private void addGradingPeriodColumns()
        {
            foreach(GradingPeriodViewModel gradingPeriod in gradingPeriods) {
                DataGridViewTextBoxColumn gradingPeriodColumn = new DataGridViewTextBoxColumn();
                gradingPeriodColumn.DefaultCellStyle.Format = "P";
                gradingPeriodColumn.Tag = gradingPeriod;
                this.Columns.Add(gradingPeriodColumn);
                gradingPeriodColumn.HeaderText = gradingPeriod.Name;
            }

        }

        private void GradeTotalsGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            StudentViewModel student = (StudentViewModel)this.Rows[e.RowIndex].DataBoundItem;

            if (isGradingPeriodColumn(e.ColumnIndex))
            {    
                GradingPeriodViewModel gradingPeriod = (GradingPeriodViewModel)this.Columns[e.ColumnIndex].Tag;

                CourseViewModel course = findCourse(gradingPeriod);

                double gradePercentage = course.CalculateGradePercentage(student);
                e.Value = gradePercentage;
                e.CellStyle.BackColor = GradeColorCode.getColor(gradePercentage);
            }
            else if (this.Columns["totalGradeColumn"].Index == e.ColumnIndex)
            {
                double gradePercentage = calculateStudentTotalGradePercentage(student);
                e.Value = gradePercentage;
                e.CellStyle.BackColor = GradeColorCode.getColor(gradePercentage);
            }
        }

        private double calculateStudentTotalGradePercentage(StudentViewModel student)
        {
            int totalCoursePoints = 0;
            int totalStudentPoints = 0;
            foreach (GradingPeriodViewModel gradingPeriod in this.gradingPeriods)
            {
                CourseViewModel course = findCourse(gradingPeriod);
                totalCoursePoints += course.getTotalPoints();
                totalStudentPoints += course.getStudentPoints(student);
            }

            if (totalCoursePoints == 0)
            {
                return 1.0;
            }

            return Convert.ToDouble(totalStudentPoints) / Convert.ToDouble(totalCoursePoints);
        }

        private CourseViewModel findCourse(GradingPeriodViewModel gradingPeriod)
        {
            foreach(CourseViewModel course in gradingPeriod.Courses) {
                if(course.Id.Equals(this.courseId)) {
                    return course;
                }
            }

            return null;
        }

        private Boolean isGradingPeriodColumn(int columnIndex)
        {
            return this.Columns["studentNameColumn"].Index != columnIndex
                && this.Columns["classPeriodColumn"].Index != columnIndex
                && this.Columns["totalGradeColumn"].Index != columnIndex;
        }

    }
}
