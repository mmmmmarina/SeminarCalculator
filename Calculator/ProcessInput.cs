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
        private readonly List<double> _nonPrimaryOperations;

        public Calculation()
        {
            _primaryOperations = 0;
            PrimaryOperationsFlag = false;
            _nonPrimaryOperations = new List<double>();
            Operand = '\0';
        }

        public double NonPrimaryOperations
        {
            get => _nonPrimaryOperations.Sum();
            set => _nonPrimaryOperations.Add(value);
        }

        public bool PrimaryOperationsFlag { get; set; }

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
                if (Operand == '*')
                    _primaryOperations *= value;
                else if (Operand == '/')
                    _primaryOperations /= value;
                else
                    _primaryOperations = value;
            }
        }

        public char Operand { get; set; }
    }
    class ProcessInput
    {
        public static int Position = 0;

        private static double HandleSign(string sign, StringBuilder number)
        {
            if (sign == "-" && number[0] == '-')
                return double.Parse(number.Remove(0, 1).ToString());
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
            var number = new StringBuilder();
            var tempCalculation = new Calculation();
            string sign;

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
                        number = new StringBuilder();
                        break;
                    }
                    case '-':
                    {

                            // Covers negative first number in expression
                        sign = tempCalculation.Operand == '-' ? "-" : "";
                        if (number.Length ==0)
                             number.Append('0'); 
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
                        number.Clear();
                        break;
                    }
                    case '*':
                    case '/':
                    {
                        sign = tempCalculation.Operand == '-' ? "-" : "";
                        if (number.Length != 0)
                            tempCalculation.PrimaryOperations = HandleSign(sign, number);
                        tempCalculation.Operand = letter;
                        number.Clear();
                        break;
                    }
                    case '(':
                    {
                        Position++;
                        double value = Calculate(textInput);
                        number = new StringBuilder(value.ToString());
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
                        number.Append(letter);
                        break;
                }

                Position++;
            }

            sign = tempCalculation.Operand == '-' ? "-" : "";
            if (tempCalculation.PrimaryOperationsFlag)
            {
                if (number.Length != 0)
                    tempCalculation.PrimaryOperations = HandleSign(sign, number);
                return tempCalculation.PrimaryOperations + tempCalculation.NonPrimaryOperations;
            }


            if (number.Length == 0) return tempCalculation.NonPrimaryOperations;
            
            tempCalculation.NonPrimaryOperations = HandleSign(sign, number);
            return tempCalculation.NonPrimaryOperations;
        }

    }
}
