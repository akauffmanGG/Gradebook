using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gradebook.ViewModel;

namespace Gradebook.Model
{
    public class Course
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public List<Assignment> Assignments { get; set; }

        public Course()
        {
            Id = Guid.NewGuid();
        }

        public Course(CourseViewModel courseVM)
        {
            this.Id = courseVM.Id;
            this.Name = courseVM.Name;
            this.Assignments = new List<Assignment>();
            foreach(AssignmentViewModel assignmentVM in courseVM.Assignments)
            {
                this.Assignments.Add(new Assignment(assignmentVM));
            }
        }

    }
}
