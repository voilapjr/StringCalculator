using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleStringCalculator
{
    public class StringCalculator
    {
        private BaseCalculatorService _calcService;

        public StringCalculator(BaseCalculatorService calcService)
        {
            _calcService = calcService;
        }

        public double Add(string stringNumberInput)
        {
            return _calcService.Add(stringNumberInput);
        }
    }
}
