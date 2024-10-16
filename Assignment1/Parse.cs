using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    internal class Parse
    {
        private static int index; // used to track current position while parsing

        public static string EvaluateExpression(string input)
        {
            if (string.IsNullOrEmpty(input))
                return "Error: No expression entered.";

            input = input.Replace(" ", ""); // remove whitespace
            index = 0;
            double result = Evaluate(input);

            if (index != input.Length) // Check for any unprocessed characters
            {
                throw new InvalidOperationException("Error: Unexpected characters or missing parenthesis.");
            }
            return result.ToString();
        }

        private static double Evaluate(string expression)
        {
            double result = ParseTerm(expression);

            while (index < expression.Length)
            {
                char op = expression[index];

                if (op == '+' || op == '-') //checks if string uses addition or subtraction
                {
                    index++; // move past the operator
                    double nextTerm = ParseTerm(expression);

                    if (op == '+')
                    {
                        result += nextTerm;
                    }
                    else
                    {
                        result -= nextTerm;
                    }
                }
                else
                {
                    break;
                }
            }

            return result;
        }

        private static double ParseTerm(string expression)
        {
            double result = ParseFactor(expression);

            while (index < expression.Length)
            {
                char op = expression[index];

                if (op == '*' || op == '/') //checks if string uses multiplication or division
                {
                    index++;
                    double nextFactor = ParseFactor(expression);

                    if (op == '*')
                    {
                        result *= nextFactor;
                    }
                    else
                    {
                        if (nextFactor == 0)
                        {
                            throw new DivideByZeroException(); //throws error if divided by zero
                        }
                        result /= nextFactor;
                    }
                }
                else
                {
                    break;
                }
            }
            return result;
        }

        private static double ParseFactor(string expression)
        {
            if (index < expression.Length && expression[index] == '(')
            {
                index++; // move past '('
                double innerResult = Evaluate(expression);

                if (index >= expression.Length || expression[index] != ')')
                    throw new InvalidOperationException("Error: Missing closing parenthesis."); //throws customer error if missed the closing parenthesis

                index++; // move past ')'
                return innerResult;
            }

            bool isNegative = false;
            if (index < expression.Length && expression[index] == '-')
            {
                isNegative = true;
                index++;
            }

            double result = 0;
            int startIndex = index;

            while (index < expression.Length && (char.IsDigit(expression[index]) || expression[index] == '.'))
            {
                index++;
            }

            if (index > startIndex)
            {
                string numberStr = expression.Substring(startIndex, index - startIndex);
                try
                {
                    result = double.Parse(numberStr);
                }
                catch (FormatException)
                {
                    throw new FormatException("Error: Invalid number format or unexpected symbol."); //throws error if letters or special characters are used
                }
                catch (OverflowException)
                {
                    throw new OverflowException();
                }
            }
            else if (index < expression.Length && !char.IsDigit(expression[index]) && expression[index] != '(' && expression[index] != ')')
            {
                throw new FormatException("Error: Unexpected symbol or character in expression.");
            }
            else
            {
                throw new InvalidOperationException("Error: Missing operand.");
            }
            return isNegative ? -result : result;
        }
    }
}
