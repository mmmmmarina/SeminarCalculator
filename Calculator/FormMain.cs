using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void entry_TextChanged(object sender, EventArgs e)
        {
            var enteredValue = entry.Text;
        }

        private void calculate_Click(object sender, EventArgs e)
        {
            result.Text = entry.Text;
        }
        
    }
}
