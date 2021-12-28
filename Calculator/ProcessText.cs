using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class ProcessText
    {

        public static (Queue<int>, Queue<char>) ParseInput(string textInput)
        {
            Queue<int> numbers = new Queue<int>();
            Queue<char> numOperators = new Queue<char>();

            string helperNum = textInput[0] != '-' ? "" : "0";
            foreach (char letter in textInput)
            {
                if (letter == '+' || letter == '-' || letter == '*' || letter == '/' || letter == '(' || letter == ')')
                {
                    if (helperNum != "")
                        numbers.Enqueue(Int32.Parse(helperNum));
                    numOperators.Enqueue(letter);
                    helperNum = "";
                }
                else
                {
                    helperNum += letter;
                }
            }

            // Save the last element
            if (helperNum != "")
                numbers.Enqueue(Int32.Parse(helperNum));
            return (numbers, numOperators);
        }
    }
}
