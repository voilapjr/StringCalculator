﻿ 
using StringCalculatorLib.CalculatorServices;
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


            CalculatorServiceReq03 svc = new CalculatorServiceReq03();
            SimpleStringCalculator.StringCalculator calc = new SimpleStringCalculator.StringCalculator(svc);
            var ret = calc.Add(calcinfo);

            Console.WriteLine(calc.ResultFormula);
        }
    }
}
