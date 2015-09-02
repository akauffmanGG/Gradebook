using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gradebook.ViewModel;

namespace Gradebook.Model
{
    public class Assignment
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public DateTime? AssignmentDate { get; set; }
        public DateTime? DueDate { get; set; }
        public int Points { get; set; }
        public List<Grade> Grades { get; set; }

        public Assignment()
        {
            Id = Guid.NewGuid();
        }

        public Assignment(AssignmentViewModel assignmentVM)
        {
            this.Id = assignmentVM.Id;
            this.Name = assignmentVM.Name;
            this.AssignmentDate = assignmentVM.AssignmentDate;
            this.DueDate = assignmentVM.DueDate;
            this.Points = assignmentVM.Points;

            Grades = new List<Grade>(assignmentVM.Grades.Count);
            foreach (GradeViewModel _grade in assignmentVM.Grades.Values)
            {
                Grades.Add(new Grade(_grade));
            }

        }
    }
}
