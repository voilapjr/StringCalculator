using System;
using System.Diagnostics;
using System.Linq;

namespace StringCalculatorLib.CalculatorServices
{
    public class CalculatorServiceReq07 : BaseCalculatorService
    {
        public override double Add(string stringNumberInput)
        {
            if (string.IsNullOrEmpty(stringNumberInput)) return 0;

            stringNumberInput = PrepInputString(stringNumberInput);

            NumberString = stringNumberInput;
            int splitter;
            if (stringNumberInput.StartsWith(CustomDelimiterIdentifier))
            {
                splitter = stringNumberInput.IndexOf("\n", StringComparison.Ordinal);
                if (splitter == 3)
                {
                    NumberString = stringNumberInput.Substring(4);
                    FormatString = stringNumberInput.Substring(2, 1);
                    StringNumberDelimiters.Add(FormatString);
                }
                else
                {
                    splitter = stringNumberInput.IndexOf("]\n", StringComparison.Ordinal);
                    if (splitter == -1)
                    {
                        NumberString = stringNumberInput;
                    }
                    else
                    {
                        NumberString = stringNumberInput.Substring(splitter + 2);
                        FormatString = stringNumberInput.Substring(3, splitter - 3);
                        string[] additionalDeliminators = FormatString.Split(FormatDelimiter.ToArray(), StringSplitOptions.RemoveEmptyEntries);

                        if (additionalDeliminators.Length > 1)
                        {
                            throw new Exception("Too many custom delimiters!");
                        }

                        StringNumberDelimiters.AddRange(additionalDeliminators);
                    }
                }
            }
            else
            {
                NumberString = stringNumberInput;
            }


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