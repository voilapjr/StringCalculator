namespace StringCalculatorLib
{
    public class StringCalculator
    {
        private readonly BaseCalculatorService _calcService;

        public StringCalculator(BaseCalculatorService calcService)
        {
            _calcService = calcService;
        }

        public string ResultFormula { get; private set; }

        public double Add(string stringNumberInput)
        {
            var ret = _calcService.Add(stringNumberInput);
            ResultFormula = _calcService.GetResultFormula("+");
            return ret;
        }

        public double Subtract(string stringNumberInput)
        {
            var ret = _calcService.Subtract(stringNumberInput);
            ResultFormula = _calcService.GetResultFormula("-");
            return ret;
        }

        public double Divide(string stringNumberInput)
        {
            var ret = _calcService.Divide(stringNumberInput);
            ResultFormula = _calcService.GetResultFormula("/");
            return ret;
        }

        public double Multiply(string stringNumberInput)
        {
            var ret = _calcService.Multiply(stringNumberInput);
            ResultFormula = _calcService.GetResultFormula("*");
            return ret;
        }
    }
}