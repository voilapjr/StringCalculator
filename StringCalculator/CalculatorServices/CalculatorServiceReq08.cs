using System.Diagnostics;
using System.Linq;

namespace StringCalculatorLib.CalculatorServices
{
    public class CalculatorServiceReq08 : BaseCalculatorService
    {
        public override double Add(string stringNumberInput)
        {
            if (string.IsNullOrEmpty(stringNumberInput)) return 0;

            var listOfNumbers = GetListOfNumbersFromInput(stringNumberInput);

            Result = listOfNumbers.Sum();

            Debug.WriteLine(NumberString);
            Debug.WriteLine(GetResultFormula("+"));
            Debug.WriteLine(Result);

            return Result;
        }
    }
}