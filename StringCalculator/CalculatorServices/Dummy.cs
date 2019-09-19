using SimpleStringCalculator;
using System;
using System.Collections.Generic;
using System.Text;

namespace StringCalculatorLib.CalculatorServices
{
    public class Dummy : BaseCalculatorService
    {
        public override double Add(string stringNumberInput)
        {
            return double.Parse(stringNumberInput);
        }
    }
}
