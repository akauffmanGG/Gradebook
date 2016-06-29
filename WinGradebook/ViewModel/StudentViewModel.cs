using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gradebook.Model;

namespace Gradebook.ViewModel
{
    public class StudentViewModel : ICloneable
    {
        public Guid Id { get; private set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string ClassPeriod { get; set; }
        public string FormattedName
        {
            get
            {
                return LastName + ", " + FirstName;
            }
        }

        public StudentViewModel()
        {
            this.Id = Guid.NewGuid();
        }

        public StudentViewModel(Student student){
            this.Id = student.Id;
            this.LastName = student.LastName;
            this.FirstName = student.FirstName;
            this.ClassPeriod = student.ClassPeriod;
        }


        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
