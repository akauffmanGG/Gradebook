using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gradebook.Model;
using Gradebook.Core;

namespace Gradebook.ViewModel
{
    public class SchoolYearViewModel
    {
        public Guid Id { get; private set; }
        public String Name { get; set; }
        public List<GradingPeriodViewModel> GradingPeriods { get; set; }
        public GradingPeriodViewModel CurrentGradingPeriod { get; set; }

        public SchoolYearViewModel()
        {
            GradingPeriods = new List<GradingPeriodViewModel>();
        }

        public SchoolYearViewModel(SchoolYear schoolYear)
        {
            this.Id = schoolYear.Id;
            this.Name = schoolYear.Name;
            this.GradingPeriods = new List<GradingPeriodViewModel>();

            if (schoolYear.GradingPeriods != null)
            {
                foreach (GradingPeriod gradingPeriod in schoolYear.GradingPeriods)
                {
                    GradingPeriodViewModel gradingPeriodVM = new GradingPeriodViewModel(gradingPeriod);
                    this.GradingPeriods.Add(gradingPeriodVM);

                    if (!gradingPeriodVM.isComplete)
                    {
                        this.CurrentGradingPeriod = gradingPeriodVM;
                    }
                }
            }
        }

        /**
         * Creates a new grading period as the current grading period.
         **/
        public void CreateGradingPeriod()
        {
            GradingPeriodViewModel gradingPeriodVm = new GradingPeriodViewModel();
            this.GradingPeriods.Add(gradingPeriodVm);
            this.CurrentGradingPeriod.isComplete = true;
            this.CurrentGradingPeriod = gradingPeriodVm;
        }

        public void CreateGradingPeriodFromCurrent()
        {
            GradingPeriodViewModel gradingPeriodVm = new GradingPeriodViewModel();
            this.GradingPeriods.Add(gradingPeriodVm);

            gradingPeriodVm.Students = cloneStudents(this.CurrentGradingPeriod.Students);
            gradingPeriodVm.Courses = cloneCourses(this.CurrentGradingPeriod.Courses);

            this.CurrentGradingPeriod.isComplete = true;
            this.CurrentGradingPeriod = gradingPeriodVm;
        }

        private SortableBindingList<StudentViewModel> cloneStudents(SortableBindingList<StudentViewModel> students)
        {
            SortableBindingList<StudentViewModel> clonedStudents = new SortableBindingList<StudentViewModel>();
            foreach (StudentViewModel student in students)
            {
                clonedStudents.Add((StudentViewModel)student.Clone());
            }

            return clonedStudents;
        }

        private SortableBindingList<CourseViewModel> cloneCourses(SortableBindingList<CourseViewModel> courses)
        {
            SortableBindingList<CourseViewModel> clonedCourses = new SortableBindingList<CourseViewModel>();
            foreach (CourseViewModel course in courses)
            {
                clonedCourses.Add((CourseViewModel)course.Clone());
            }

            return clonedCourses;
        }
    }
}
