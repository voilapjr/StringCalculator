using SimpleStringCalculator;
using System;
using System.Diagnostics;
using System.Linq;

namespace StringCalculatorLib.CalculatorServices
{
    public class CalculatorServiceReq03 : BaseCalculatorService
    {
        public override double Add(string stringNumberInput)
        {
            if (string.IsNullOrEmpty(stringNumberInput)) return 0;

            stringNumberInput = prepInputString(stringNumberInput);

            nunmberString = stringNumberInput;

            valueList = nunmberString.Split(stringNumberDelimiters.ToArray(), StringSplitOptions.None).ToList();

            numberList = (from x in valueList select GetDouble(x)).ToList();

            this.Result = numberList.Sum();

            Debug.WriteLine(nunmberString);
            Debug.WriteLine(this.ResultFormula);
            Debug.WriteLine(Result);

            return Result;
        }
    }
}