using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gradebook.Model;
using System.ComponentModel;

namespace Gradebook.ViewModel
{
    public class AssignmentViewModel : INotifyPropertyChanged
    {
        public Guid Id { get; private set; }

        private String _name;
        public String Name { 
            get { return _name; } 
            set {
                if(!value.Equals(_name) )
                {
                    _name = value;
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("Name"));
                    }
                }
            }
        }
        public DateTime? AssignmentDate { get; set; }
        public DateTime? DueDate { get; set; }
        private int _points;
        public int Points
        {
            get { return _points; }
            set
            {
                if (!value.Equals(_points))
                {
                    _points = value;
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("Points"));
                    }
                }
            }
        }
        public Dictionary<Guid, GradeViewModel> Grades { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public AssignmentViewModel()
        {
            this.Id = Guid.NewGuid();
            Grades = new Dictionary<Guid, GradeViewModel>();
        }

        public AssignmentViewModel(Assignment assignment)
        {
            this.Id = assignment.Id;
            this.Name = assignment.Name;
            this.AssignmentDate = assignment.AssignmentDate;
            this.DueDate = assignment.DueDate;
            this.Points = assignment.Points;

            Grades = new Dictionary<Guid, GradeViewModel>();
            foreach (Grade grade in assignment.Grades)
            {
                GradeViewModel gradeVM = new GradeViewModel(grade);
                Grades.Add(gradeVM.StudentId, gradeVM);
            }
        }

        public double CalculateGradePercentage(StudentViewModel student)
        {
            if(Grades.ContainsKey(student.Id))
            {
                return Convert.ToDouble(Grades[student.Id].Points) / Convert.ToDouble(Points);
            }

            return 0.0;
        }


    }
}
