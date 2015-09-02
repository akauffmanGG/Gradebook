using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gradebook.Model;
using System.ComponentModel;

namespace Gradebook.ViewModel
{
    public class CourseViewModel
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public BindingList<AssignmentViewModel> Assignments { get; set; }

        public CourseViewModel()
        {
            Assignments = new BindingList<AssignmentViewModel>();
        }

        public CourseViewModel(Course course)
        {
            this.Id = course.Id;
            this.Name = course.Name;

            Assignments = new BindingList<AssignmentViewModel>();
            foreach(Assignment assignment in course.Assignments)
            {
                Assignments.Add(new AssignmentViewModel(assignment));
            }
        }

        public double CalculateGradePercentage(StudentViewModel student){
            int totalPoints = 0;
            int studentPoints = 0;

            foreach (AssignmentViewModel assignment in Assignments)
            {
                totalPoints += assignment.Points;
                if(assignment.Grades.ContainsKey(student.Id)){
                    studentPoints += assignment.Grades[student.Id].Points.GetValueOrDefault();
                }
            }

            if (totalPoints == 0)
            {
                return 1.0;
            }
            else
            {
                return Convert.ToDouble(studentPoints) / Convert.ToDouble(totalPoints);
            }
        }

    }
}
