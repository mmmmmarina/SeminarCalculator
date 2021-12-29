//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Runtime.CompilerServices;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;

//namespace Calculator
//{
//    struct Data
//    {
//        private static string _number = "";
//        private static char _operand = '\0';

//        public static double Number
//        {
//            get
//            {
//                string _sign = _operand == '-' ? "-" : "";
//                double numberValue = Double.Parse($"{_sign}{_number}");
//                _number = "";
//                return numberValue;
//            }
//            set => _number += value;
//        }

//        public static char Operand
//        {
//            get => _operand;
//            set => _operand = value;
//        }
//    }

//    class Computing
//    {
//        public List<double> PriorityOperations = new List<double>(); // * and /
//        public List<double> NonPriorityOperations = new List<double>(); // + and -
//    }
//    class Numbers
//    {
//        public static Computing InitializeComputing()
//        {
//            return new Computing();
//        }

//        public static UpdateArrayOfNumbers(Computing )
//        //    public List<double> ArrayOfNumbers = new List<double>();
//        //    private double _calculatePrimaryOperations = 1; // Calculate * and /
//        //    private string _createNumber = "";
//        //    private char _operator = '\0';

//        //    public double CreateNumber
//        //    {
//        //        get
//        //        {
//        //            string _sign = _operator == '-' ? "-" : "";
//        //            double doubleValue = Double.Parse($"{_sign}{_createNumber}");
//        //            _createNumber = "";
//        //            return doubleValue;
//        //        }
//        //        set => _createNumber += (char)value;
//        //    }

//        //    public char LastOperator
//        //    {
//        //        get => _operator;
//        //        set => _operator = value;
//        //    }

//        //    public int CalculatePrimaryOperations
//        //    {
//        //        set
//        //        {
//        //            if (value == 42)
//        //                _calculatePrimaryOperations *= CreateNumber;
//        //            else if (value == 47)
//        //                _calculatePrimaryOperations /= CreateNumber;
//        //        }
//        //    }
//        //}
//    }
