namespace StringCalculatorLib
{
    public class StringCalculator
    {
        private BaseCalculatorService _calcService;

        public string ResultFormula { get; private set; }

        public StringCalculator(BaseCalculatorService calcService)
        {
            _calcService = calcService;
        }

        public double Add(string stringNumberInput)
        {
            double ret = _calcService.Add(stringNumberInput);
            ResultFormula = _calcService.GetResultFormula("+");
            return ret;
        }
        public double Subtract(string stringNumberInput)
        {
            double ret = _calcService.Subtract(stringNumberInput);
            ResultFormula = _calcService.GetResultFormula("-");
            return ret;
        }

        public double Divide(string stringNumberInput)
        {
            double ret = _calcService.Divide(stringNumberInput);
            ResultFormula = _calcService.GetResultFormula("/");
            return ret;
        }

        public double Multiply(string stringNumberInput)
        {
            double ret = _calcService.Multiply(stringNumberInput);
            ResultFormula = _calcService.GetResultFormula("*");
            return ret;
        }
    }
}