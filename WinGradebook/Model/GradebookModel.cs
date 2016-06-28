using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gradebook.ViewModel;

namespace Gradebook.Model
{
    public class GradebookModel
    {
        public List<SchoolYear> SchoolYears { get; set; }

        public GradebookModel()
        {
            this.SchoolYears = new List<SchoolYear>();
        }

        public GradebookModel(GradebookViewModel gradebookVM)
        {
            this.SchoolYears = new List<SchoolYear>();
            foreach (SchoolYearViewModel schoolYearVM in gradebookVM.SchoolYears)
            {
                this.SchoolYears.Add(new SchoolYear(schoolYearVM));
            }
        }
    }
}
