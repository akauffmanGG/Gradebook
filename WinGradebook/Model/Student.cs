using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gradebook.ViewModel;

namespace Gradebook.Model
{
    public class Student
    {
        public Guid Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }

        public Student()
        {
            this.Id = Guid.NewGuid();
        }

        public Student(StudentViewModel studentVM)
        {
            this.Id = studentVM.Id;
            this.LastName = studentVM.LastName;
            this.FirstName = studentVM.FirstName;
        }

    }
}
