using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class FormMain : Form
    {
        //private Numbers arrayOfNumbers = new Numbers();
        //private Stack<Computing> keepTrack = new Stack<Computing>();
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            // Automatically resize main table layout pain
            tableLayoutPanelMain.Width = this.Width;
            tableLayoutPanelMain.Height = this.Height;
        }

        public void button_0_MouseClick(object sender, MouseEventArgs e)
        {
            //Numbers.PressZero();
        }

        private void FormMain_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 40 || e.KeyChar <= 58)
                textBoxDisplay.Text += (char) e.KeyChar;
            else if (e.KeyChar == Keys.Enter.GetHashCode())
            {
                processCalculate();
            }
        }

        private void buttonCalculate_Click(object sender, EventArgs e)
        {
            // We are at the end of the calulation
            // We need to append last number to list if there is any 
            // And calculate sum of all list members
            //if (arrayOfNumbers.LastOperator != ')')
            //    arrayOfNumbers.ArrayOfNumbers.Add(arrayOfNumbers.CreateNumber);
            //textBoxResult.Text= arrayOfNumbers.ArrayOfNumbers.Sum().ToString();
            processCalculate();
        }

        private void processCalculate()
        {
            textBoxResult.Text = ProcessInput.Calculate(textBoxDisplay.Text).ToString();
            ProcessInput.Position = 0;
            textBoxDisplay.Text = "";
        }

        private void button_number_Click(object sender, EventArgs e)
        {
            textBoxDisplay.Text += (sender as Button).Text;
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            ProcessInput.Position = 0;
            textBoxDisplay.Text = "";
        }

        private void textBoxDisplay_CausesValidationChanged(object sender, EventArgs e)
        {
            var text = textBoxDisplay.Text;
        }

        private void buttonDot_Click(object sender, EventArgs e)
        {
            textBoxDisplay.Text += CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
        }
    }
}
