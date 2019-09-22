using StringCalculatorLib.CalculatorServices;
using System;
using StringCalculatorLib;

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

            CalculatorServiceReq08 svc = new CalculatorServiceReq08();
            StringCalculator calc = new StringCalculator(svc);

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