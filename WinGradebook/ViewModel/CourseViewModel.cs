using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gradebook.Model;
using System.ComponentModel;
using Gradebook.Core;

namespace Gradebook.ViewModel
{
    public class CourseViewModel : ICloneable
    {
        public Guid Id { get; private set; }
        public String Name { get; set; }
        public SortableBindingList<AssignmentViewModel> Assignments { get; set; }

        public CourseViewModel()
        {
            this.Id = Guid.NewGuid();
            Assignments = new SortableBindingList<AssignmentViewModel>();
        }

        public CourseViewModel(Course course)
        {
            this.Id = course.Id;
            this.Name = course.Name;

            Assignments = new SortableBindingList<AssignmentViewModel>();

            if (course.Assignments != null)
            {
                foreach (Assignment assignment in course.Assignments)
                {
                    Assignments.Add(new AssignmentViewModel(assignment));
                }
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

        public int getTotalPoints()
        {
            int totalPoints = 0;

            foreach (AssignmentViewModel assignment in Assignments)
            {
                totalPoints += assignment.Points;
            }

            return totalPoints;
        }

        public int getStudentPoints(StudentViewModel student)
        {
            int studentPoints = 0;

            foreach (AssignmentViewModel assignment in Assignments)
            {
                if (assignment.Grades.ContainsKey(student.Id))
                {
                    studentPoints += assignment.Grades[student.Id].Points.GetValueOrDefault();
                }
            }

            return studentPoints;
        }

        /** 
         * Returns a shallow clone of this instance. The clone will have a new 
         * Id and no assignments.
         **/
        public object Clone()
        {

            CourseViewModel clone = (CourseViewModel)this.MemberwiseClone();
            clone.Assignments = new SortableBindingList<AssignmentViewModel>();

            return clone;
        }

    }
}
