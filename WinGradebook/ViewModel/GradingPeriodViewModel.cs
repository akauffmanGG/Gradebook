using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gradebook.Core;
using Gradebook.Model;

namespace Gradebook.ViewModel
{
    public class GradingPeriodViewModel
    {
        public Guid Id { get; private set; }
        public String Name { get; set; }
        public SortableBindingList<StudentViewModel> Students { get; set; }
        public SortableBindingList<CourseViewModel> Courses { get; set; }
        public bool isCurrent { get; private set; }

        public GradingPeriodViewModel()
        {
            Id = Guid.NewGuid();
            Students = new SortableBindingList<StudentViewModel>();
            Courses = new SortableBindingList<CourseViewModel>();
        }

        public GradingPeriodViewModel(bool _isCurrent) : this()
        {
            this.isCurrent = _isCurrent;
        }

        public GradingPeriodViewModel(GradingPeriod gradingPeriod)
        {
            this.Id = gradingPeriod.Id;
            this.Name = gradingPeriod.Name;
            this.isCurrent = gradingPeriod.isCurrent;
            this.Students = new SortableBindingList<StudentViewModel>();

            if (gradingPeriod.Students != null)
            {
                foreach (Student student in gradingPeriod.Students)
                {
                    this.Students.Add(new StudentViewModel(student));
                }
            }

            this.Courses = new SortableBindingList<CourseViewModel>();
            if (gradingPeriod.Courses != null)
            {
                foreach (Course course in gradingPeriod.Courses)
                {
                    this.Courses.Add(new CourseViewModel(course));
                }
            }
        }

    }
}
