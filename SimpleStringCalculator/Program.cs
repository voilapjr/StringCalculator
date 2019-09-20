using StringCalculatorLib.CalculatorServices;
using System;

namespace SimpleStringCalculator
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("String Calculator:");
            Console.WriteLine("Hello! Input your calculation string:");

            Console.Out.Flush();

            var calcinfo = Console.ReadLine();

            CalculatorServiceReq08 svc = new CalculatorServiceReq08();
            SimpleStringCalculator.StringCalculator calc = new SimpleStringCalculator.StringCalculator(svc);

            try
            {
                var ret = calc.Add(calcinfo);
                Console.WriteLine(calc.ResultFormula);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}