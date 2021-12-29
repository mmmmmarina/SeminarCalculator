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
            //if ((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == 44 || e.KeyChar == 46)
            //{
            //    // For chars: numbers and decimal points
            //    // Save chars to number property until some of the operands are clicked
            //    //arrayOfNumbers.CreateNumber = e.KeyChar;
            //    //textBoxDisplay.Text += (char)e.KeyChar;
            //}
            //else if (e.KeyChar == 43 || e.KeyChar == 45)
            //{
            //    // For chars: + and -
            //    // Some of the operands are clicked so:
            //    // => update LastOperator
            //    // => clear numbers and append current number to list with its sign
            //    //arrayOfNumbers.ArrayOfNumbers.Add(arrayOfNumbers.CreateNumber);
            //    //arrayOfNumbers.LastOperator = e.KeyChar;
            //    //textBoxDisplay.Text += (char)e.KeyChar;
            //}
            //else if (e.KeyChar == 42 || e.KeyChar == 47)
            //{
            //    // For chars: * and /
            //    //arrayOfNumbers.CalculatePrimaryOperations = e.KeyChar;
            //}
            //else if (e.KeyChar == 40)
            //{
            //    keepTrack.Push(Numbers.InitializeComputing());
            //}
            //else if (e.KeyChar == 41)
            //{
            //    Numbers.UpdateArrayOfNumbers(keepTrack.Pop());
            //    //value = stog.pop();
            //    //arrayofnumbers.createnumbers = value;
            //}
        }

        private void buttonCalculate_Click(object sender, EventArgs e)
        {
            // We are at the end of the calulation
            // We need to append last number to list if there is any 
            // And calculate sum of all list members
            //if (arrayOfNumbers.LastOperator != ')')
            //    arrayOfNumbers.ArrayOfNumbers.Add(arrayOfNumbers.CreateNumber);
            //textBoxResult.Text= arrayOfNumbers.ArrayOfNumbers.Sum().ToString();
            textBoxResult.Text = ProcessInput.Calculate(textBoxDisplay.Text).ToString();
            ProcessInput.position = 0;
            textBoxDisplay.Text = "";
        }
    }
}
