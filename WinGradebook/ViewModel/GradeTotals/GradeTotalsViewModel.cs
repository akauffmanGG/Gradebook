using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gradebook.ViewModel.GradeTotals
{
    public class GradeTotalsViewModel
    {
        private SchoolYearViewModel schoolYear;
        public Dictionary<Guid, String> Courses { get; private set; }
        public List<StudentViewModel> Students { get; private set; }
        public List<GradingPeriodViewModel> GradingPeriods { get; private set; }

        public GradeTotalsViewModel(SchoolYearViewModel _schoolYear)
        {
            schoolYear = _schoolYear;
            Courses = new Dictionary<Guid, string>();
            Students = new List<StudentViewModel>();
            Dictionary<Guid, StudentViewModel> studentMap = new Dictionary<Guid, StudentViewModel>();
            GradingPeriods = new List<GradingPeriodViewModel>();

            foreach (GradingPeriodViewModel gradingPeriod in schoolYear.GradingPeriods)
            {
                GradingPeriods.Add(gradingPeriod);

                foreach (CourseViewModel course in gradingPeriod.Courses)
                {
                    if (!Courses.ContainsKey(course.Id))
                    {
                        Courses.Add(course.Id, course.Name);
                    }
                }

                foreach (StudentViewModel student in gradingPeriod.Students)
                {
                    if (!studentMap.ContainsKey(student.Id))
                    {
                        studentMap.Add(student.Id, student);
                    }
                }
                
            }

            Students = studentMap.Values.ToList();
        }
    }
}
