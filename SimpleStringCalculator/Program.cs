using System;
using StringCalculatorLib;
using StringCalculatorLib.CalculatorServices;

namespace SimpleStringCalculator
{
    internal class Program
    {
        private static void Main()
        {
            Console.WriteLine("String Calculator:");
            Console.WriteLine("Hello! Input your calculation string:");

            Console.Out.Flush();

            var calcInfo = Console.ReadLine();

            var svc = new CalculatorServiceReq08();
            var calc = new StringCalculator(svc);

            try
            {
                calc.Multiply(calcInfo);
                Console.WriteLine(calc.ResultFormula);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}