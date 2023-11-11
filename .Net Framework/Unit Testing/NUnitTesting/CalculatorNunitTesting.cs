using Calculation;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTesting
{
    [TestFixture]
    public class CalculatorNunitTesting
    {
        Calculator c;
        [OneTimeSetUp]
        //[SetUp]
        public void Setup()
        {
            c = new Calculator();
        }

        [OneTimeTearDown]
        //[TearDown]
        public void Teardown()
        {
            c.Dispose();
        }

        [Test,Order(2)]
        public void Test_Addition()
        {

            //Assert.That(parameter, Expression) Expression-- > A Constraint expression to be applied
            Assert.That(5, Is.EqualTo(c.Addition(2, 3))); // EqualTo --> Returns a constraint that tests two items for equality



            //AreEqual(object ? expected, object ? actual);
            Assert.AreEqual(1, c.Addition(2, 3)); //  Verifies that two objects are equal. Two objects are considered equal if both
                                                  //     are null, or if both have the same value.


            //Assert.AreEqual(5,5);
            Assert.AreNotEqual("Soumyajeet", "Soumya");

        }

        [Test,Order(1)]
        public void Test_Substraction()
        {

            //Assert.Throws<ArgumentException>(() => c.substraction(4, 5));

            Assert.Catch<Exception>(() => c.substraction(4, 5));
        }

        [TestCase(1,2,3),Order(4)]
        [TestCase(4,2,3)]  
        public void Test_Addition_Multiple(int x , int y , int expectedres)
        {
            
            Assert.AreEqual(expectedres, c.Addition(x, y));
        }

        [Ignore("Ignore this test")] // Ignore should be having attribute
        [Test]
        public void TestIgnore()
        {

        }

    }
}
