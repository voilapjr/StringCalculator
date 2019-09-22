using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace StringCalculatorLib
{
    public abstract class BaseCalculatorService
    {
        protected readonly List<string> StringNumberDelimiters = new List<string> { ",", "\n" };

        protected string NumberString = string.Empty;

        protected List<string> ValueList;
        protected List<double> NumberList;

        protected string FormatString = string.Empty;

        protected const string CustomDelimiterIdentifier = "//";
        protected readonly List<string> FormatDelimiter = new List<string> { "][" };

        public double Result { get; protected set; }

        public virtual double Subtract(string stringNumberInput)
        {
            if (string.IsNullOrEmpty(stringNumberInput)) return 0;

            var listOfNumbers = GetListOfNumbersFromInput(stringNumberInput);

            if (!listOfNumbers.Any())
            {
                Result = 0;
                return Result;
            }
            Result = listOfNumbers[0];

            for (int i = 1; i < listOfNumbers.Count; i++)
            {
                double x = listOfNumbers[i];
                Result -= x;
            }

            Debug.WriteLine(NumberString);
            Debug.WriteLine(GetResultFormula("-"));
            Debug.WriteLine(Result);

            return Result;
        }

        public virtual double Multiply(string stringNumberInput)
        {
            if (string.IsNullOrEmpty(stringNumberInput)) return 0;

            var listOfNumbers = GetListOfNumbersFromInput(stringNumberInput);

            if (!listOfNumbers.Any())
            {
                Result = 0;
                return Result;
            }
            Result = listOfNumbers[0];

            for (int i = 1; i < listOfNumbers.Count; i++)
            {
                double x = listOfNumbers[i];
                Result = Result * x;
            }

            Debug.WriteLine(NumberString);
            Debug.WriteLine(GetResultFormula("*"));
            Debug.WriteLine(Result);

            return Result;
        }

        public virtual double Divide(string stringNumberInput)
        {
            if (string.IsNullOrEmpty(stringNumberInput)) return 0;

            var listOfNumbers = GetListOfNumbersFromInput(stringNumberInput);

            listOfNumbers = (from x in listOfNumbers where x > 0 select x).ToList();

            if (!listOfNumbers.Any())
            {
                Result = 0;
                return Result;
            }
            Result = listOfNumbers[0];

            for (int i = 1; i < listOfNumbers.Count; i++)
            {
                double x = listOfNumbers[i];
                Result = Result / x;
            }

            Debug.WriteLine(NumberString);
            Debug.WriteLine(GetResultFormula("/"));
            Debug.WriteLine(Result);

            return Result;
        }

        public string GetResultFormula(string operation)
        {
            if (NumberList == null)
                return string.Empty;
            string ret = string.Empty;
            foreach (var x in NumberList)
            {
                ret = ret + $"{operation}{GetDouble(x)}";
            }
            return ret.Substring(1, ret.Length - 1) + " = " + Result;
        }

        public abstract double Add(string stringNumberInput);

        protected List<double> GetListOfNumbersFromInput(string stringNumberInput)
        {
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
            return NumberList;
        }

        protected static string PrepInputString(string stringNumberInput)
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

            return 0;
        }

        protected bool IsNumeric(object val) => double.TryParse(val.ToString(), out _);

        protected bool IsLessThanOrEqualTo(double threshold, double val)
        {
            return val <= threshold;
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