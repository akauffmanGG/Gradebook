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
        private String _name;
        public String Name { 
            get {
                if(_name == null) {
                    return "<current>";
                }

                return _name;
            }
            set { _name = value; }
        } 
        public SortableBindingList<StudentViewModel> Students { get; set; }
        public SortableBindingList<CourseViewModel> Courses { get; set; }
        public bool isComplete { get; set; }

        public GradingPeriodViewModel()
        {
            Id = Guid.NewGuid();
            Students = new SortableBindingList<StudentViewModel>();
            Courses = new SortableBindingList<CourseViewModel>();
        }

        public GradingPeriodViewModel(GradingPeriod gradingPeriod)
        {
            this.Id = gradingPeriod.Id;
            this.Name = gradingPeriod.Name;
            this.isComplete = gradingPeriod.isComplete;
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
