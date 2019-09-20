namespace SimpleStringCalculator
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
    }
}