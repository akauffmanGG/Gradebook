using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gradebook.ViewModel;

namespace Gradebook.Model
{
    public class Grade
    {
        public Guid StudentId { get; set; }
        public int? Points { get; set; }

        public Grade() { }

        public Grade(GradeViewModel gradeVM)
        {
            this.StudentId = gradeVM.StudentId;
            this.Points = gradeVM.Points;
        }
    }
}
