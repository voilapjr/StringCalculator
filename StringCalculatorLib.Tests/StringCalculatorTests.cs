using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleStringCalculator;
using SimpleStringCalculator.CalculatorServices;

namespace StringCalculatorLib.Tests
{
    [TestClass]
    public class StringCalculatorTests
    {
        [DataTestMethod]
        //[DataRow("", 0)]
        //[DataRow(null, 0)]
        //[DataRow("5,tytyt", 5)]
        //[DataRow("1,2,3,4,5,6,7,8,9,10,11,12", 78)]
        //[DataRow("1\n2,3", 6)]
        //[DataRow("1\n2,3,-1", 6)]
        //[DataRow("2,1001,6", 8)]
        //[DataRow("//;\n2;5", 7)]
        //[DataRow("//[***]\n11***22***33", 66)]
        //[DataRow("//[\n][*][!!][r9r]\n11r9r22*33!!44, null", 110)]
        //[DataRow("//[*][!!][r9r]\n11r9r22*33!!aaa*44.123*1000*1006", 1110.123)]


        [DataRow("0", 0)]
        public void AddTest(string caclString, double expected)
        {
            // Arrange

            Dummy svc = new Dummy();
            StringCalculator calc = new StringCalculator(svc);

            // Act

            var z = calc.Add(caclString);
            double actual = calc.Add(caclString);

            // Assert

            Assert.AreEqual(actual, expected, 0.001, "calc");
        }
    }
}
