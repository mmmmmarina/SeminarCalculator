using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    class Numbers
    {
        public List<double> ArrayOfNumbers = new List<double>();
        private double _calculatePrimaryOperations = 1; // Calculate * and /
        private string _createNumber = "";
        private char _operator = '\0';

        public double CreateNumber
        {
            get
            {
                string _sign = _operator == '-' ? "-" : "";
                double doubleValue = Double.Parse($"{_sign}{_createNumber}");
                _createNumber = "";
                return doubleValue;
            }
            set => _createNumber += (char)value;
        }

        public char LastOperator
        {
            get => _operator;
            set => _operator = value;
        }

        public int CalculatePrimaryOperations
        {
            set
            {
                if (value == 42)
                    _calculatePrimaryOperations *= CreateNumber;
                else if (value == 47)
                    _calculatePrimaryOperations /= CreateNumber;
            }
        }
    }
}
