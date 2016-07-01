using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Gradebook.ViewModel;
using Gradebook.View.Theme;
using Gradebook.ViewModel.Service;

namespace Gradebook.View
{
    public partial class GradeGrid : StyledGrid
    {
        [Description("The course of which grades will be displayed."), Category("Data"), Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
        public CourseViewModel Course { get; set; }

        private GradebookViewModel gradebookVm;
        private BindingList<AssignmentViewModel> assignments;
        private Dictionary<AssignmentViewModel, DataGridViewTextBoxColumn> columnDictionary;

        public GradeGrid()
        {
            InitializeComponent();
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();

            gradebookVm = GradebookViewModel.Instance;
            this.DataSource = gradebookVm.Students;

            columnDictionary = new Dictionary<AssignmentViewModel, DataGridViewTextBoxColumn>();

            if (Course != null)
            {
                assignments = Course.Assignments;
                assignments.ListChanged += new ListChangedEventHandler(assignments_ListChanged);

                createColumns();
            }

        }

        private void createColumns()
        {
            foreach (AssignmentViewModel assignment in Course.Assignments)
            {
                addColumn(assignment);
            }
        }

        private void addColumn(AssignmentViewModel assignment)
        {
            DataGridViewTextBoxColumn assignmentColumn;
            if (columnDictionary.ContainsKey(assignment))
            {
                assignmentColumn = columnDictionary[assignment];
            }
            else
            {
                assignmentColumn = new DataGridViewTextBoxColumn();
                assignmentColumn.DefaultCellStyle.Format = "P";
                assignmentColumn.Tag = assignment;
                this.Columns.Add(assignmentColumn);
                this.columnDictionary.Add(assignment, assignmentColumn);
            }

            assignmentColumn.HeaderText = assignmentHeaderFormat(assignment);
        }

        private void GradeGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (isAssignmentColumn(e.ColumnIndex))
            {
                StudentViewModel student = (StudentViewModel)this.Rows[e.RowIndex].DataBoundItem;
                AssignmentViewModel assignment = (AssignmentViewModel)this.Columns[e.ColumnIndex].Tag;

                if (assignment.Grades.ContainsKey(student.Id))
                {
                    if(this[e.ColumnIndex, e.RowIndex].IsInEditMode){
                        this.Columns[e.ColumnIndex].DefaultCellStyle.Format = "";
                        e.Value = assignment.Grades[student.Id].Points;
                    } else {
                        this.Columns[e.ColumnIndex].DefaultCellStyle.Format = "P";
                        double gradePercentage = assignment.CalculateGradePercentage(student);
                        e.Value = gradePercentage;
                        e.CellStyle.BackColor = GradeColorCode.getColor(gradePercentage);
                    }
                }
            }
            else if (this.Columns["totalGradeColumn"].Index == e.ColumnIndex)
            {
                StudentViewModel student = (StudentViewModel)this.Rows[e.RowIndex].DataBoundItem;
                double gradePercentage = Course.CalculateGradePercentage(student);
                e.Value = gradePercentage;
                e.CellStyle.BackColor = GradeColorCode.getColor(gradePercentage);
            }
        }

        void assignments_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType.Equals(ListChangedType.ItemAdded))
            {
                addColumn(assignments[e.NewIndex]);
            }
            else if (e.ListChangedType.Equals(ListChangedType.ItemDeleted))
            {
                List<AssignmentViewModel> assignmentCols = new List<AssignmentViewModel>(columnDictionary.Keys);
                foreach (AssignmentViewModel assignment in assignmentCols)
                {
                    if (!assignments.Contains(assignment))
                    {
                        this.Columns.Remove(columnDictionary[assignment]);
                        columnDictionary.Remove(assignment);
                    }
                }
            }
            else if (e.ListChangedType.Equals(ListChangedType.ItemChanged))
            {
                if(e.PropertyDescriptor.Name.Equals("Name")){
                    AssignmentViewModel assignment = assignments[e.NewIndex];
                    columnDictionary[assignment].HeaderText = assignmentHeaderFormat(assignment);
                }
                else if (e.PropertyDescriptor.Name.Equals("Points"))
                {
                    AssignmentViewModel assignment = assignments[e.NewIndex];
                    columnDictionary[assignment].HeaderText = assignmentHeaderFormat(assignment);
                    int colIndex = columnDictionary[assignment].Index;

                    for (int i = 0; i < Rows.Count; i++)
                    {
                        this.GradeGrid_CellFormatting(null, new DataGridViewCellFormattingEventArgs(colIndex, i, null, null, null));
                    }

                }
            }
            
        }

        private string assignmentHeaderFormat(AssignmentViewModel assignment)
        {
            return assignment.Name + " / " + assignment.Points.ToString();
        }

        private Boolean isAssignmentColumn(int columnIndex)
        {
            return this.Columns["studentNameColumn"].Index != columnIndex
                && this.Columns["classPeriodColumn"].Index != columnIndex
                && this.Columns["totalGradeColumn"].Index != columnIndex;
        }

        private void GradeGrid_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (isAssignmentColumn(e.ColumnIndex))
            {
                object rawValue = e.FormattedValue;

                int newValue = 0;

                if (rawValue == null // Null value means the value was deleted in which case zero will be entered for the grade.
                    || (rawValue.GetType() == typeof(String) //Otherwise the value should be a string
                        && (String.IsNullOrWhiteSpace((String) rawValue) //An empty string should have zero entered for the grade.
                            || int.TryParse((String)rawValue, out newValue)))) //Otherwise convert the string to an int and use that as the grade
                {
                    StudentViewModel student = (StudentViewModel)this.Rows[e.RowIndex].DataBoundItem;
                    AssignmentViewModel assignment = (AssignmentViewModel)this.Columns[e.ColumnIndex].Tag;

                    if (assignment.Grades.ContainsKey(student.Id))
                    {
                        assignment.Grades[student.Id].Points = newValue;
                    }
                    else
                    {
                        GradeViewModel grade = new GradeViewModel() { StudentId = student.Id, Points = newValue };
                        assignment.Grades.Add(student.Id, grade);
                    }

                }

            }
        }

        private void GradeGrid_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            DataGridViewColumn col = e.Column;
        }

        private void GradeGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            StateManager.MarkDirty();
        }

    }
}
