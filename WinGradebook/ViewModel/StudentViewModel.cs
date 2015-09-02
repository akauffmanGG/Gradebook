using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gradebook.Model;

namespace Gradebook.ViewModel
{
    public class StudentViewModel
    {
        public Guid Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string FormattedName
        {
            get
            {
                return LastName + ", " + FirstName;
            }
        }

        public StudentViewModel()
        {
        }

        public StudentViewModel(Student student){
            this.Id = student.Id;
            this.LastName = student.LastName;
            this.FirstName = student.FirstName;
        }

    }
}
