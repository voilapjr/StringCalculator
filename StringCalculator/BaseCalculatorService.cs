using System.Collections.Generic;

namespace SimpleStringCalculator
{
    public abstract class BaseCalculatorService
    {
        protected List<string> stringNumberDelimiters = new List<string> { "," };

        protected string nunmberString = string.Empty;

        //protected string formatString = string.Empty;

        protected List<string> valueList;
        protected List<double> numberList;

        public double Result { get; protected set; }

        public string ResultFormula
        {
            get
            {
                if (this.numberList == null)
                    return string.Empty;
                string ret = string.Empty;
                foreach (var x in this.numberList)
                {
                    ret = ret + $"+{GetDouble(x)}";
                }
                return ret.Substring(1, ret.Length - 1) + " = " + this.Result.ToString();
            }
            private set { _resultFormula = value; }
        }

        private string _resultFormula = string.Empty;

        public abstract double Add(string stringNumberInput);

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
    }
}