using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gradebook.ViewModel;

namespace Gradebook.Model
{
    public class SchoolYear
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public List<GradingPeriod> GradingPeriods { get; set; }
        public bool isComplete { get; set; }

        public SchoolYear()
        {
            Id = Guid.NewGuid();
        }

        public SchoolYear(SchoolYearViewModel schoolYearVM)
        {
            this.Id = schoolYearVM.Id;
            this.Name = schoolYearVM.Name;
            this.isComplete = schoolYearVM.isComplete;
            this.GradingPeriods = new List<GradingPeriod>();
            foreach (GradingPeriodViewModel gradingPeriodVM in schoolYearVM.GradingPeriods)
            {
                this.GradingPeriods.Add(new GradingPeriod(gradingPeriodVM));
            }
        }
    }
}
