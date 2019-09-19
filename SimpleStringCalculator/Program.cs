using SimpleStringCalculator.CalculatorServices;
using System;

namespace SimpleStringCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("String Calculator:");
            Console.WriteLine("Hello: Input calculation string:");

            Console.Out.Flush();
            var calcinfo = Console.ReadLine();

            //calc here
            Dummy svc = new Dummy();
            SimpleStringCalculator.StringCalculator calc = new SimpleStringCalculator.StringCalculator(svc);
            var ret = calc.Add(calcinfo);

            Console.WriteLine("Your string is: " + calcinfo + " :: " + ret);
        }
    }
}
