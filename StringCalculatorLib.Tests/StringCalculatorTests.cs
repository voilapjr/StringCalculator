using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringCalculatorLib.CalculatorServices;

namespace StringCalculatorLib.Tests
{
    [TestClass]
    public class StringCalculatorTests
    {
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

        [DataTestMethod]
        [DataRow("0", 0)]
        public void Add_Test_Dummy(string caclString, double expected)
        {
            // Arrange

            var svc = new Dummy();
            var calc = new StringCalculator(svc);

            // Act

            var actual = calc.Add(caclString);

            // Assert

            Assert.AreEqual(actual, expected, 0.001, "calc");
        }

        [DataTestMethod]
        [DataRow("0", 0)]
        [DataRow("", 0)]
        [DataRow("5,tytyt", 5)]
        [DataRow("5,tytyt,10", 5)]
        public void Add_Test_CalculatorServiceReq01(string caclString, double expected)
        {
            // Arrange

            var svc = new CalculatorServiceReq01();
            var calc = new StringCalculator(svc);

            // Act

            var actual = calc.Add(caclString);

            // Assert

            Assert.AreEqual(actual, expected, 0.001, "calc");
        }

        [DataTestMethod]
        [DataRow("0", 0)]
        [DataRow("", 0)]
        [DataRow("5,tytyt", 5)]
        [DataRow("5,tytyt,10", 15)]
        [DataRow("1,2,3,4,5,6,7,8,9,10,11,12", 78)]
        public void Add_Test_CalculatorServiceReq02(string caclString, double expected)
        {
            // Arrange

            var svc = new CalculatorServiceReq02();
            var calc = new StringCalculator(svc);

            // Act

            var actual = calc.Add(caclString);

            // Assert

            Assert.AreEqual(actual, expected, 0.001, "calc");
        }

        [DataTestMethod]
        [DataRow("0", 0)]
        [DataRow("", 0)]
        [DataRow("5,tytyt", 5)]
        [DataRow("5,tytyt,10", 15)]
        [DataRow("1,2,3,4,5,6,7,8,9,10,11,12", 78)]
        [DataRow("1\n2,3", 6)]
        public void Add_Test_CalculatorServiceReq03(string caclString, double expected)
        {
            // Arrange

            var svc = new CalculatorServiceReq03();
            var calc = new StringCalculator(svc);

            // Act

            var actual = calc.Add(caclString);

            // Assert

            Assert.AreEqual(actual, expected, 0.001, "calc");
        }

        /*
        [DataTestMethod]
        //[DataRow("0", 0)]
        //[DataRow("", 0)]
        //[DataRow("5,tytyt", 5)]
        //[DataRow("5,tytyt,10", 15)]
        //[DataRow("1,2,3,4,5,6,7,8,9,10,11,12", 78)]
        //[DataRow("1\n2,3", 6)]
        public void Add_Test_CalculatorServiceReq04(string caclString, double expected)
        {
            // Arrange

            CalculatorServiceReq04 svc = new CalculatorServiceReq04();
            StringCalculator calc = new StringCalculator(svc);

            // Act

            double actual = calc.Add(caclString);

            // Assert

            Assert.AreEqual(actual, expected, 0.001, "calc");
        }
        */

        [TestMethod]
        [ExpectedException(typeof(NegativeNumberException))]
        public void Add_Test_CalculatorServiceReq04_negative()
        {
            // Arrange

            var svc = new CalculatorServiceReq04();
            var calc = new StringCalculator(svc);

            // Act

            calc.Add("1,2,3,4,5,6,+7,8,9,10,11,-12");

            // Assert - Expects NegativeNumberException
        }

        [DataTestMethod]
        [DataRow("0", 0)]
        [DataRow("", 0)]
        [DataRow("5,tytyt", 5)]
        [DataRow("5,tytyt,10", 15)]
        [DataRow("1,2,3,4,5,6,7,8,9,10,11,12", 78)]
        [DataRow("1\n2,3", 6)]
        [DataRow("2,1001,6", 8)]
        [DataRow("2,1000.5,6,10.5", 18.5)]
        public void Add_Test_CalculatorServiceReq05(string caclString, double expected)
        {
            // Arrange

            var svc = new CalculatorServiceReq05();
            var calc = new StringCalculator(svc);

            // Act

            var actual = calc.Add(caclString);

            // Assert

            Assert.AreEqual(actual, expected, 0.001, "calc");
        }

        [DataTestMethod]
        [DataRow("0", 0)]
        [DataRow("", 0)]
        [DataRow("5,tytyt", 5)]
        [DataRow("5,tytyt,10", 15)]
        [DataRow("1,2,3,4,5,6,7,8,9,10,11,12", 78)]
        [DataRow("1\n2,3", 6)]
        [DataRow("2,1001,6", 8)]
        [DataRow("2,1000.5,6,10.5", 18.5)]
        [DataRow("//;\n2;5", 7)]
        public void Add_Test_CalculatorServiceReq06(string caclString, double expected)
        {
            // Arrange

            var svc = new CalculatorServiceReq06();
            var calc = new StringCalculator(svc);

            // Act

            var actual = calc.Add(caclString);

            // Assert

            Assert.AreEqual(actual, expected, 0.001, "calc");
        }

        [DataTestMethod]
        [DataRow("0", 0)]
        [DataRow("", 0)]
        [DataRow("5,tytyt", 5)]
        [DataRow("5,tytyt,10", 15)]
        [DataRow("1,2,3,4,5,6,7,8,9,10,11,12", 78)]
        [DataRow("1\n2,3", 6)]
        [DataRow("2,1001,6", 8)]
        [DataRow("2,1000.5,6,10.5", 18.5)]
        [DataRow("//;\n2;5", 7)]
        [DataRow("//[***]\n11***22***33", 66)]
        // [DataRow("//[\n][*][!!][r9r]\n11r9r22*33!!44, null", 110)]
        public void Add_Test_CalculatorServiceReq07(string caclString, double expected)
        {
            // Arrange

            var svc = new CalculatorServiceReq07();
            var calc = new StringCalculator(svc);

            // Act

            var actual = calc.Add(caclString);

            // Assert

            Assert.AreEqual(actual, expected, 0.001, "calc");
        }

        [DataTestMethod]
        [DataRow("0", 0)]
        [DataRow("", 0)]
        [DataRow("5,tytyt", 5)]
        [DataRow("5,tytyt,10", 15)]
        [DataRow("1,2,3,4,5,6,7,8,9,10,11,12", 78)]
        [DataRow("1\n2,3", 6)]
        [DataRow("2,1001,6", 8)]
        [DataRow("2,1000.5,6,10.5", 18.5)]
        [DataRow("//;\n2;5", 7)]
        [DataRow("//[***]\n11***22***33", 66)]
        [DataRow("//[\n][*][!!][r9r]\n11r9r22*33!!44, null", 110)]
        public void Add_Test_CalculatorServiceReq08(string caclString, double expected)
        {
            // Arrange

            var svc = new CalculatorServiceReq08();
            var calc = new StringCalculator(svc);

            // Act

            var actual = calc.Add(caclString);

            // Assert

            Assert.AreEqual(actual, expected, 0.001, "calc");
        }

        [DataTestMethod]
        [DataRow("5,2,10", -7)]
        public void Test_CalculatorServiceStretch05_Subtract(string caclString, double expected)
        {
            // Arrange

            var svc = new CalculatorServiceReq08();
            var calc = new StringCalculator(svc);

            // Act

            var actual = calc.Subtract(caclString);

            // Assert

            Assert.AreEqual(actual, expected, 0.001, "calc");
        }

        [DataTestMethod]
        [DataRow("5,2,10", 100)]
        public void Test_CalculatorServiceStretch05_Multiply(string caclString, double expected)
        {
            // Arrange

            var svc = new CalculatorServiceReq08();
            var calc = new StringCalculator(svc);

            // Act

            var actual = calc.Multiply(caclString);

            // Assert

            Assert.AreEqual(actual, expected, 0.001, "calc");
        }


        [DataTestMethod]
        [DataRow("5,2,10", 0.25)]
        public void Test_CalculatorServiceStretch05_Divide(string caclString, double expected)
        {
            // Arrange

            var svc = new CalculatorServiceReq08();
            var calc = new StringCalculator(svc);

            // Act

            var actual = calc.Divide(caclString);

            // Assert

            Assert.AreEqual(actual, expected, 0.001, "calc");
        }
    }
}