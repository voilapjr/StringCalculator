using System;
using System.Diagnostics;
using System.Linq;

namespace StringCalculatorLib.CalculatorServices
{
    public class CalculatorServiceReq01 : BaseCalculatorService
    {
        public override double Add(string stringNumberInput)
        {
            if (string.IsNullOrEmpty(stringNumberInput)) return 0;

            stringNumberInput = PrepInputString(stringNumberInput);

            NumberString = stringNumberInput;

            ValueList = NumberString.Split(StringNumberDelimiters.ToArray(), StringSplitOptions.None).Take(2).ToList();

            NumberList = (from x in ValueList select GetDouble(x)).ToList();

            this.Result = NumberList.Sum();

            Debug.WriteLine(NumberString);
            Debug.WriteLine(this.GetResultFormula("+"));
            Debug.WriteLine(Result);

            return Result;
        }
    }
}