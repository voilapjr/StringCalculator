using System;
using System.Diagnostics;
using System.Linq;

namespace StringCalculatorLib.CalculatorServices
{
    public class CalculatorServiceReq05 : BaseCalculatorService
    {
        public override double Add(string stringNumberInput)
        {
            if (string.IsNullOrEmpty(stringNumberInput)) return 0;

            stringNumberInput = PrepInputString(stringNumberInput);

            NumberString = stringNumberInput;

            ValueList = NumberString.Split(StringNumberDelimiters.ToArray(), StringSplitOptions.None).ToList();

            NumberList = (from x in ValueList select GetDouble(x)).ToList();

            var negativeNumberList = (from x in NumberList where x < 0 select x).ToList();

            if (negativeNumberList.Any())
            {
                throw new NegativeNumberException(negativeNumberList);
            }

            NumberList = NumberList.Where(x => IsLessThanOrEqualTo(1000, x)).ToList();

            this.Result = NumberList.Sum();

            Debug.WriteLine(NumberString);
            Debug.WriteLine(this.GetResultFormula("+"));
            Debug.WriteLine(Result);

            return Result;
        }
    }
}