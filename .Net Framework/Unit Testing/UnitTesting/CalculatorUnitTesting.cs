using Calculation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTesting
{
    [TestClass]
    public class CalculatorUnitTesting
    {
        [TestMethod]
        public void Test_Addition()
        {
            //Arrange
            Calculator c = new Calculator();

            //Act
            int res = c.Addition(2, 3);

            //Assert
            Assert.AreEqual(5, res);
            

            Assert.AreEqual("Soumyajeet", "Soumya");

        }

        [TestMethod]
        public void Test_Substraction()
        {
            Calculator c = new Calculator();

            Assert.ThrowsException<ArgumentException>(() => c.substraction(4,5));
        }

        [Ignore("Ignore this test")]
        [TestMethod]
        public void TestIgnore()
        {

        }
    }
}
