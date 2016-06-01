using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gradebook.ViewModel;

namespace Gradebook.Model
{
    public class GradingPeriod
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public List<Course> Courses { get; set; }
        public List<Student> Students { get; set; }
        public bool isCurrent { get; set; }

        public GradingPeriod()
        {
            Id = Guid.NewGuid();
        }

        public GradingPeriod(GradingPeriodViewModel gradingPeriodVM)
        {
            this.Id = gradingPeriodVM.Id;
            this.Name = gradingPeriodVM.Name;
            this.isCurrent = gradingPeriodVM.isCurrent;
            this.Courses = new List<Course>();
            foreach (CourseViewModel courseVM in gradingPeriodVM.Courses)
            {
                this.Courses.Add(new Course(courseVM));
            }

            this.Students = new List<Student>();
            foreach (StudentViewModel studentVM in gradingPeriodVM.Students)
            {
                this.Students.Add(new Student(studentVM));
            }
        }
    }
}
