using SimpleStringCalculator;
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

            stringNumberInput = prepInputString(stringNumberInput);

            nunmberString = stringNumberInput;
            var splitter = -2;
            if (stringNumberInput.StartsWith(CustomDelimiterIdentifier))
            {
                 splitter = stringNumberInput.IndexOf("\n");
                if (splitter == 3)
                {
                    nunmberString = stringNumberInput.Substring(4);
                    formatString = stringNumberInput.Substring(2, 1);
                    stringNumberDelimiters.Add(formatString);
                }
                else
                {
                     splitter = stringNumberInput.IndexOf("]\n");
                    if (splitter == -1)
                    {
                        nunmberString = stringNumberInput;
                    }
                    else
                    {
                        nunmberString = stringNumberInput.Substring(splitter + 2);
                        formatString = stringNumberInput.Substring(3, splitter - 3);
                        string[] additionalDeliminators = formatString.Split(formatDelimiter.ToArray(), StringSplitOptions.RemoveEmptyEntries);

                        if (additionalDeliminators.Length>1)
                        {
                            throw new Exception("Too many custom delimiters!");
                        }

                        stringNumberDelimiters.AddRange(additionalDeliminators);
                    }
                }
            }
            else
            {
                nunmberString = stringNumberInput;
            }


            valueList = nunmberString.Split(stringNumberDelimiters.ToArray(), StringSplitOptions.None).ToList();

            numberList = (from x in valueList select GetDouble(x)).ToList();

            var negativeNumberList = (from x in numberList where x < 0 select x).ToList();

            if (negativeNumberList.Any())
            {
                throw new NegativeNumberException(negativeNumberList);
            }

            numberList = numberList.Where(x => IsLessThanOrEqualTo(1000, x)).ToList();

            this.Result = numberList.Sum();

            Debug.WriteLine(nunmberString);
            Debug.WriteLine(this.ResultFormula);
            Debug.WriteLine(Result);

            return Result;
        }
    }
}