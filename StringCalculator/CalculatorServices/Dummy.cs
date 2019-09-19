using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleStringCalculator.CalculatorServices
{
    public class Dummy : BaseCalculatorService
    {
        public override double Add(string stringNumberInput)
        {
            return double.Parse(stringNumberInput);
        }
    }
}
