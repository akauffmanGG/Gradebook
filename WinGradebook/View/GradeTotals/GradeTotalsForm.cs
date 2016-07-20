using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Gradebook.ViewModel.GradeTotals;
using Gradebook.ViewModel;
using Gradebook.Core;

namespace Gradebook.View.GradeTotals
{
    public partial class GradeTotalsForm : Form
    {
        GradeTotalsViewModel gradeTotalsVM;

        public GradeTotalsForm(SchoolYearViewModel schoolYear)
        {
            InitializeComponent();

            gradeTotalsVM = new GradeTotalsViewModel(schoolYear);

            addCourseTabs();
        }

        private void addCourseTabs()
        {
            SortableBindingList<StudentViewModel> students = new SortableBindingList<StudentViewModel>(gradeTotalsVM.Students);

            foreach (KeyValuePair<Guid, String> entry in gradeTotalsVM.Courses)
            {
                TabPage tab = new TabPage(entry.Value);
                totalGradesTabControl.TabPages.Add(tab);

                tab.Controls.Add(new GradeTotalsGrid(entry.Key, students, gradeTotalsVM.GradingPeriods));
            }
        }
    }
}
