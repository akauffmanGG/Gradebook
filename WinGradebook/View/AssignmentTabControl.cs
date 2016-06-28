using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Gradebook.ViewModel;

namespace Gradebook.View
{
    public partial class AssignmentTabControl : TabControl
    {
        private GradebookViewModel gradebookVM;
        private BindingList<CourseViewModel> courses;

        public AssignmentTabControl()
        {
            InitializeComponent();
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();

            gradebookVM = GradebookViewModel.Instance;
            courses = gradebookVM.Courses;
            courses.ListChanged += new ListChangedEventHandler(blCourses_ListChanged);
            createAssignmentTabs();
        }

        private void createAssignmentTabs()
        {
            foreach (CourseViewModel course in gradebookVM.Courses)
            {
                addAssignmentTab(course);
            }
        }

        private void addAssignmentTab(CourseViewModel course)
        {
            TabPage tab = new TabPage(course.Name);

            DataGridView dgAssignments = new AssignmentGrid();
            dgAssignments.Dock = DockStyle.Fill;
            dgAssignments.DataSource = course.Assignments;

            tab.Controls.Add(dgAssignments);
            tab.DataBindings.Add(new Binding("Text", course, "Name"));
            this.Controls.Add(tab);
        }

        void blCourses_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType.Equals(ListChangedType.ItemAdded))
            {
                CourseViewModel newCourse = courses[e.NewIndex];
                newCourse.Name = "";
                addAssignmentTab(newCourse);
            }
            else if (e.ListChangedType.Equals(ListChangedType.ItemDeleted))
            {
                //CourseViewModel removedCourse = blCourses[e.NewIndex];
                foreach (TabPage tab in this.TabPages)
                {
                    if (!courses.Contains(tab.DataBindings["Text"].DataSource))
                    {
                        this.Controls.Remove(tab);
                    }
                }
            }
        }

    }
}
