using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Calculation
    {
        private double _primaryOperations;
        private List<double> _nonPrimaryOperations;
        private char _operand;

        public Calculation()
        {
            _primaryOperations = 0;
            _nonPrimaryOperations = new List<double>();
            _operand = '\0';
        }

        public double NonPrimaryOperations
        {
            get => _nonPrimaryOperations.Sum();
            set => _nonPrimaryOperations.Add(value);
        }

        public double PrimaryOperations
        {
            get => _primaryOperations;
            set
            {
                if (_operand == '*')
                    _primaryOperations *= value;
                else if (_operand == '/')
                    _primaryOperations /= value;
                else
                    _primaryOperations = value;
            }
        }

        public char Operand
        {
            get => _operand;
            set => _operand = value;
        }
    }
    class ProcessInput
    {
        public static int position = 0;
        public static double Calculate(string textInput)
        {
            string number = "";
            Calculation tempCalculation = new Calculation();

            //keepTrack.Push(tempCalculation);
            //for (int i=start_position; i<textInput.Length; i++)
            while (position < textInput.Length)
            {
                char letter = textInput[position];
                if (letter == '+')
                {
                    if (tempCalculation.PrimaryOperations != 0)
                    {
                        tempCalculation.NonPrimaryOperations = tempCalculation.PrimaryOperations;
                        tempCalculation.PrimaryOperations = 0;
                    }
                    string sign = tempCalculation.Operand == '-' ? "-" : "";
                    tempCalculation.NonPrimaryOperations = Double.Parse($"{sign}{number}");
                    tempCalculation.Operand = '+';
                    number = "";
                }

                else if (letter == '-')
                {
                    if (tempCalculation.PrimaryOperations != 0 &&
                        (tempCalculation.Operand == '*' || tempCalculation.Operand == '/'))
                    {
                        tempCalculation.NonPrimaryOperations = tempCalculation.PrimaryOperations;
                        tempCalculation.PrimaryOperations = 0;
                    }
                    string sign = tempCalculation.Operand == '-' ? "-" : "";
                    if (number == "")
                        number = "0";
                    tempCalculation.NonPrimaryOperations = Double.Parse($"{sign}{number}");
                    tempCalculation.Operand = '-';
                    number = "";
                }
                else if (letter == '*' || letter == '/')
                {
                    string sign = tempCalculation.Operand == '-' ? "-" : "";
                    tempCalculation.PrimaryOperations = Double.Parse($"{sign}{number}");
                    tempCalculation.Operand = letter;
                    number = "";
                }

                else if (letter == '(')
                {
                    position++;
                    double value = Calculate(textInput);
                    string sign = tempCalculation.Operand == '-' ? "-" : "";
                    if (tempCalculation.Operand == '*' || tempCalculation.Operand == '/')
                        tempCalculation.PrimaryOperations = Double.Parse($"{sign}{value}");
                    else
                        tempCalculation.NonPrimaryOperations = Double.Parse($"{sign}{value}");
                    number = "";
                }

                else if (letter == ')')
                {
                    string sign = tempCalculation.Operand == '-' ? "-" : "";
                    if (tempCalculation.PrimaryOperations != 0 &&
                        (tempCalculation.Operand == '*' || tempCalculation.Operand == '/'))
                    {
                        tempCalculation.PrimaryOperations = Double.Parse($"{sign}{number}");
                        tempCalculation.NonPrimaryOperations = tempCalculation.PrimaryOperations;
                        tempCalculation.PrimaryOperations = 0;
                    }
                    else
                        tempCalculation.NonPrimaryOperations = Double.Parse($"{sign}{number}");
                    position++;
                    return tempCalculation.NonPrimaryOperations;
                }
                else
                {
                    number += letter;
                }

                position++;
            }

            if (tempCalculation.PrimaryOperations != 0)
            {
                string sign = tempCalculation.Operand == '-' ? "-" : "";
                if (number != "")
                    tempCalculation.PrimaryOperations = Double.Parse($"{sign}{number}");
                return tempCalculation.PrimaryOperations + tempCalculation.NonPrimaryOperations;
            }

            
            if (number != "")
            {
                string sign = tempCalculation.Operand == '-' ? "-" : "";
                tempCalculation.NonPrimaryOperations = Double.Parse($"{sign}{number}");
            }
            return tempCalculation.NonPrimaryOperations;
        }

    }
}
