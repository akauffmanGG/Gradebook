using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gradebook.Model;

namespace Gradebook.ViewModel
{
    public class GradeViewModel
    {
        public Guid StudentId { get; set; }
        public int? Points { get; set; }

        public GradeViewModel() { }

        public GradeViewModel(Grade grade) 
        {
            this.StudentId = grade.StudentId;
            this.Points = grade.Points;
        }
    }
}
