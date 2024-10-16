using System;
using System.Collections.Generic;

namespace Assignment1
{

    public class Program
    {
        public static string ProcessCommand(string input)
        {
            try //tries to parse the string
            {
                return Parse.EvaluateExpression(input);
            }
            catch (InvalidOperationException ex)
            {
                return ex.Message;
            }
            catch (Exception)
            {
                return "Error: An unexpected error occurred.";
            }
        }

        public static void Main(string[] args)
        {
            string input;

            Console.WriteLine("Please enter the formula you wish to have computed: ");
            Console.WriteLine("(Type 'exit' to quit the program)");

            while ((input = Console.ReadLine()) != "exit")
            {
                Console.WriteLine(ProcessCommand(input));
            }
        }
    }
}
