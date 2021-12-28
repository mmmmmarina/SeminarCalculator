using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Calculate
    {
        public static int CalculateInput(string textInput)
        {
            return ResolveCalculation(ProcessText.ParseInput(textInput));
        }
        public static int ResolveCalculation((Queue<int>, Queue<char>) inputValues, int previousElement = 0)
        {
            (Queue<int> numbers, Queue<char> numOperators) = inputValues;
            int number;
            char sign;

            //previousElement = (numbers.Count == 0 || previousElement !=0) ? previousElement : numbers.Dequeue();
            previousElement = numbers.Dequeue();
            Queue<int> numForAddition = new Queue<int>();
            while (numOperators.Count > 0)
            {
                number = numbers.Count == 0 ? previousElement : numbers.Dequeue();
                sign = numOperators.Dequeue();

                switch (sign)
                {
                    case '(':
                        previousElement = ResolveCalculation((numbers, numOperators), previousElement);
                        numForAddition.Enqueue(previousElement);
                        break;
                    case ')':
                        return previousElement;
                    case '+':
                        numForAddition.Enqueue(previousElement);
                        previousElement = number;
                        if (numOperators.Peek() == '(')
                        {
                            
                            goto case '(';
                        }
                        break;
                    case '-':
                        numForAddition.Enqueue(previousElement);
                        previousElement = -number;
                        break;
                    case '*':
                        previousElement *= number;
                        break;
                    case '/':
                        previousElement /= number;
                        break;
                    default:
                        throw new InvalidOperationException("Operator not recognizes. Please use one of the following: +, -, * or /");
                }
            }

            //Add the last element
            numForAddition.Enqueue(previousElement);
            return numForAddition.Sum();
        }
    }
}

