using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApi
{
    public class Calculator : ISimpleCalculator
    {
        private readonly IDiagnostics _diagnostics;
        public Calculator() { }
        public Calculator(IDiagnostics diagnostics) 
        {
            _diagnostics = diagnostics;
        }

        public int Add(int valueOne, int valueTwo)
        {
            int answer = valueOne + valueTwo;
            if (_diagnostics != null)
            {
                _diagnostics.Log($"Successfully added: {valueOne} and {valueTwo} to {answer}");
            }
            else
            {
                Console.WriteLine("Diagnostics logger is not available for this implementation.");
            }
           
            return answer;
        }

        public int Subtract(int valueOne, int valueTwo) 
        {
            int answer = valueOne - valueTwo;

            if (_diagnostics != null)
            {
                _diagnostics.Log($"Successfully subtracted: {valueOne} and {valueTwo} to {answer}");
            }
            else
            {
                Console.WriteLine("Diagnostics logger is not available for this implementation.");
            }

            return answer;
        }

        public int Multiply(int valueOne, int valueTwo) 
        {
            int answer = valueOne * valueTwo;

            if (_diagnostics != null)
            {
                _diagnostics.Log($"Successfully multiplied: {valueOne} and {valueTwo} to {answer}");
            }
            else
            {
                Console.WriteLine("Diagnostics logger is not available for this implementation.");
            }

            return answer;
        }

        public int Divide(int valueOne, int valueTwo)
        {
            int answer = valueOne / valueTwo;

            if (_diagnostics != null)
            {
                _diagnostics.Log($"Successfully divided: {valueOne} and {valueTwo} to {answer}");
            }
            else
            {
                Console.WriteLine("Diagnostics logger is not available for this implementation.");
            }

            return answer;
        }

    }
}
