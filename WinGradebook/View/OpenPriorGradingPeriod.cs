using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Gradebook.ViewModel;

namespace Gradebook.View
{
    public partial class OpenPriorGradingPeriod : Form
    {
        List<GradingPeriodViewModel> _gradingPeriods;

        public OpenPriorGradingPeriod(List<GradingPeriodViewModel> gradingPeriods)
        {
            _gradingPeriods = gradingPeriods;
            InitializeComponent();
            initializeComboBox();
        }

        public GradingPeriodViewModel getGradingPeriod() {
            return (GradingPeriodViewModel)gradingPeriodComboBox.SelectedItem;
        }

        private void initializeComboBox()
        {
            gradingPeriodComboBox.Items.Add("--Select a grading period--");

            foreach (GradingPeriodViewModel gpvm in _gradingPeriods)
            {
                gradingPeriodComboBox.Items.Add(gpvm);
            }


            gradingPeriodComboBox.DisplayMember = "Name";
            gradingPeriodComboBox.ValueMember = "Id";

            gradingPeriodComboBox.SelectedIndex = 0;
        }

        private void openBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
