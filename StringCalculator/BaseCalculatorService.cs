using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleStringCalculator
{
    public abstract class BaseCalculatorService
    {
        protected List<string> stringNumberDelimiters = new List<string> { ",", "\n" };

        protected string nunmberString = string.Empty;

        protected List<string> valueList;
        protected List<double> numberList;

        protected string formatString = string.Empty;

        protected const string CustomDelimiterIdentifier = "//";
        protected List<string> formatDelimiter = new List<string> { "][" };

        public double Result { get; protected set; }

        public string GetResultFormula(string operation)
        {
            if (this.numberList == null)
                return string.Empty;
            string ret = string.Empty;
            foreach (var x in this.numberList)
            {
                ret = ret + $"{operation}{GetDouble(x)}";
            }
            return ret.Substring(1, ret.Length - 1) + " = " + this.Result.ToString();
        }

        public abstract double Add(string stringNumberInput);

        protected List<double> GetListOfNumbersFromInput(string stringNumberInput)
        {
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
            return numberList;
        }

        protected string prepInputString(string stringNumberInput)
        {
            return stringNumberInput.Replace("[,", string.Empty)
                .Replace("\\n", "\n")
                .Replace("[\n]", string.Empty)
                .Replace("[ ]", string.Empty)
                .Replace("[.]", string.Empty); // real number
        }

        protected double GetDouble(object val)
        {
            if (IsNumeric(val))
            {
                return double.Parse(val.ToString());
            }
            else
            {
                return 0;
            }
        }

        protected bool IsNumeric(object val) => double.TryParse(val.ToString(), out double result);

        protected bool IsLessThanOrEqualTo(double threshold, double val)
        {
            return val <= threshold ? true : false;
        }
    }

    public class NegativeNumberException : Exception
    {
        public NegativeNumberException()
        {
        }

        public NegativeNumberException(List<double> list)
            : base($"One or more negative number were found:'{string.Join(", ", list)}'.\nNegative numbers are not allowed!")
        {
        }
    }
}