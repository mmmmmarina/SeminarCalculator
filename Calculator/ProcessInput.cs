using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace Calculator
{
    class Calculation
    {
        private double _primaryOperations;
        private bool _primaryOperationsFlag;
        private List<double> _nonPrimaryOperations;
        private char _operand;

        public Calculation()
        {
            _primaryOperations = 0;
            _primaryOperationsFlag = false;
            _nonPrimaryOperations = new List<double>();
            _operand = '\0';
        }

        public double NonPrimaryOperations
        {
            get => _nonPrimaryOperations.Sum();
            set => _nonPrimaryOperations.Add(value);
        }

        public bool PrimaryOperationsFlag
        {
            get => _primaryOperationsFlag;
            set => _primaryOperationsFlag = value;
        }

        public double PrimaryOperations
        {
            get
            {
                PrimaryOperationsFlag = false; 
                return _primaryOperations;
            }
            set
            {
                PrimaryOperationsFlag = true;
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
        public static int Position = 0;

        private static string EmptyPrimaryOperations(Calculation tempCalculation)
        {
            if (tempCalculation.PrimaryOperationsFlag)
            {
                tempCalculation.NonPrimaryOperations = tempCalculation.PrimaryOperations;
                tempCalculation.PrimaryOperations = 0;
                tempCalculation.PrimaryOperationsFlag = false;
            }

            return tempCalculation.Operand == '-' ? "-" : "";
        }

        private static double HandleSign(string sign, string number)
        {
            if (sign == "-" && number[0] == '-')
                return double.Parse(number.Remove(0, 1));
            return double.Parse($"{sign}{number}");
        }

        /// <summary>
        /// Calculate expression given in textInput
        ///
        /// Method goes through every char in string textInput and process it obeying next rules:
        /// -> if char is number => save it to string
        /// -> if char is + or - => save number to nonPrimaryNumbers array respecting the omen
        /// -> if char is * or / => multiply/divide this number with the one saved to PrimaryNumbers
        /// -> if char is ( or ) => recursively call Calculation for expression in brackets
        /// </summary>
        /// <param name="textInput"></param>
        /// <returns></returns>
        public static double Calculate(string textInput)
        {
            var number = "";
            var sign = "";
            var tempCalculation = new Calculation();
            
            while (Position < textInput.Length)
            {
                var letter = textInput[Position];
                switch (letter)
                {
                    case '+':
                    {
                        sign = tempCalculation.Operand == '-' ? "-" : "";
                        if (tempCalculation.PrimaryOperationsFlag)
                        {
                            tempCalculation.PrimaryOperations = HandleSign(sign, number);
                            tempCalculation.NonPrimaryOperations = tempCalculation.PrimaryOperations;
                            tempCalculation.PrimaryOperations = 0;
                            tempCalculation.PrimaryOperationsFlag = false;
                        }
                        else
                            tempCalculation.NonPrimaryOperations = HandleSign(sign, number);
                        tempCalculation.Operand = '+';
                        number = "";
                        break;
                    }
                    case '-':
                    {

                            // Covers negative first number in expression
                        sign = tempCalculation.Operand == '-' ? "-" : "";
                        if (number == "")
                            number = "0";
                        if (tempCalculation.PrimaryOperationsFlag)
                        {
                            tempCalculation.PrimaryOperations = HandleSign(sign, number);
                            tempCalculation.NonPrimaryOperations = tempCalculation.PrimaryOperations;
                            tempCalculation.PrimaryOperations = 0;
                            tempCalculation.PrimaryOperationsFlag = false;
                        }
                        else
                            tempCalculation.NonPrimaryOperations = HandleSign(sign, number);
                        tempCalculation.Operand = '-';
                        number = "";
                        break;
                    }
                    case '*':
                    case '/':
                    {
                        sign = tempCalculation.Operand == '-' ? "-" : "";
                        if (number != "")
                            tempCalculation.PrimaryOperations = HandleSign(sign, number);
                        tempCalculation.Operand = letter;
                        number = "";
                        break;
                    }
                    case '(':
                    {
                        Position++;
                        double value = Calculate(textInput);
                        number = value.ToString();
                        break;
                    }
                    case ')':
                    {
                        sign = tempCalculation.Operand == '-' ? "-" : "";
                        if (tempCalculation.Operand == '*' || tempCalculation.Operand == '/')
                        {
                            tempCalculation.PrimaryOperations = HandleSign(sign, number);
                            tempCalculation.NonPrimaryOperations = tempCalculation.PrimaryOperations;
                            tempCalculation.PrimaryOperations = 0;
                        }
                        else
                            tempCalculation.NonPrimaryOperations = HandleSign(sign, number);
                        return tempCalculation.NonPrimaryOperations;
                    }
                    default:
                        number += letter;
                        break;
                }

                Position++;
            }

            sign = tempCalculation.Operand == '-' ? "-" : "";
            if (tempCalculation.PrimaryOperationsFlag)
            {
                if (number != "")
                    tempCalculation.PrimaryOperations = HandleSign(sign, number);
                return tempCalculation.PrimaryOperations + tempCalculation.NonPrimaryOperations;
            }


            if (number == "") return tempCalculation.NonPrimaryOperations;
            
            tempCalculation.NonPrimaryOperations = HandleSign(sign, number);
            return tempCalculation.NonPrimaryOperations;
        }

    }
}
