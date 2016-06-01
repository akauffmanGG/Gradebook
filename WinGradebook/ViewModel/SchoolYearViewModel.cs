using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gradebook.Model;

namespace Gradebook.ViewModel
{
    public class SchoolYearViewModel
    {
        public Guid Id { get; private set; }
        public String Name { get; set; }
        public List<GradingPeriodViewModel> GradingPeriods { get; set; }
        public GradingPeriodViewModel CurrentGradingPeriod { get; private set; }

        public SchoolYearViewModel()
        {
            GradingPeriods = new List<GradingPeriodViewModel>();
        }

        public SchoolYearViewModel(SchoolYear schoolYear)
        {
            this.Id = schoolYear.Id;
            this.Name = schoolYear.Name;
            this.GradingPeriods = new List<GradingPeriodViewModel>();

            if (schoolYear.GradingPeriods != null)
            {
                foreach (GradingPeriod gradingPeriod in schoolYear.GradingPeriods)
                {
                    GradingPeriodViewModel gradingPeriodVM = new GradingPeriodViewModel(gradingPeriod);
                    this.GradingPeriods.Add(gradingPeriodVM);

                    if (gradingPeriodVM.isCurrent)
                    {
                        this.CurrentGradingPeriod = gradingPeriodVM;
                    }
                }
            }
        }

        /**
         * Creates a new grading period as the current grading period.
         **/
        public void CreateGradingPeriod()
        {
            GradingPeriodViewModel gradingPeriodVm = new GradingPeriodViewModel(true);
            this.GradingPeriods.Add(gradingPeriodVm);
            this.CurrentGradingPeriod = gradingPeriodVm;
        }
    }
}
