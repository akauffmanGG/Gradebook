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
    public partial class GradeTabControl : TabControl
    {
        private GradebookViewModel gradebookVM;
        private BindingList<CourseViewModel> courses;
        private TabPage gettingStartedTab;

        public GradeTabControl()
        {
            InitializeComponent();
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();

            gradebookVM = GradebookViewModel.Instance;
            courses = gradebookVM.Courses;
            courses.ListChanged += new ListChangedEventHandler(blCourses_ListChanged);
            createCourseTabs();
        }

        private void createCourseTabs()
        {
            foreach (CourseViewModel course in gradebookVM.Courses)
            {
                addCourseTab(course);
            }

            if (gradebookVM.Courses.Count == 0)
            {
                addGettingStartedTab();
            }
        }

        private void addCourseTab(CourseViewModel course)
        {
            TabPage tab = new TabPage(course.Name);

            GradeGrid dgGrades = new GradeGrid();
            dgGrades.Course = course;
            dgGrades.Dock = DockStyle.Fill;

            tab.Controls.Add(dgGrades);
            tab.DataBindings.Add(new Binding("Text", course, "Name"));
            this.Controls.Add(tab);
        }

        private void addGettingStartedTab()
        {
            gettingStartedTab = new TabPage("Getting Started");
            Label noGradesLabel = new Label();
            noGradesLabel.AutoSize = true;
            noGradesLabel.Location = new System.Drawing.Point(0, 10);
            noGradesLabel.Name = "noGradesLabel";
            noGradesLabel.Size = new System.Drawing.Size(100, 23);
            noGradesLabel.TabIndex = 0;
            noGradesLabel.Text = "No grades to display. Add students, courses, and assignments to begin.";
            gettingStartedTab.Controls.Add(noGradesLabel);
            noGradesLabel.Visible = true;

            this.Controls.Add(gettingStartedTab);
        }

        void blCourses_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType.Equals(ListChangedType.ItemAdded))
            {
                this.Controls.Remove(gettingStartedTab);

                CourseViewModel newCourse = courses[e.NewIndex];
                newCourse.Name = "";
                addCourseTab(newCourse);
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
