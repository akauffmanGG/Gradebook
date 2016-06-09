using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Gradebook.View
{
    public partial class GradingPeriodPrompt : Form
    {
        public GradingPeriodPrompt()
        {
            InitializeComponent();
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            if (nameTxt.Text == "")
            {
                ErrorProvider errorProvider = new ErrorProvider();
                errorProvider.SetError(nameTxt, "You must enter a label for the grading period.");

                this.DialogResult = DialogResult.None;
            }
        }

        public String getName()
        {
            return nameTxt.Text;
        }
    }
}
