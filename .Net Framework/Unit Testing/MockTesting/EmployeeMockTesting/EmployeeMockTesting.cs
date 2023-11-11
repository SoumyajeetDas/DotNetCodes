using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Employee;
using Moq;



namespace EmployeeMockTesting
{
    [TestClass]
    public class EmployeeMockTesting
    {
        [TestMethod]
        public void TestMethod1()
        {
            //EmployeeGetDetails egd = new EmployeeGetDetails();

            //int res = egd.GetWorkDurationTotalSalary(1);

            //Assert.AreEqual(180000, res);




            // Moq creates an implementation of the mocked type. If the type is an interface,
            // it creates a class that implements the interface. If the type is a class, it creates
            // an inherited class, and the members of that inherited class call the base class.
            // But in order to do that it has to override the members. If a class has members that
            // can't be overridden (they aren't virtual, abstract) then Moq can't override them to
            // add its own behaviors.

            //Mock<IEmployeeDetails> moqdetails = new Mock<IEmployeeDetails>();
            Mock<EmployeeGetDetails> moqdetails = new Mock<EmployeeGetDetails>();

            //int res = moqdetails.Object.GetWorkDurationTotalSalary(1);
            //Assert.AreEqual(1800, res);


            //If for the mock if you are using the Class Type Mock<EmployeeGetDetails> where EmployeeGetDetails is the class that have been used the function that
            //is used in the setup must be virtual otherwise will give error
            // Like here the GetWorkDurationTotalSalary is virtual in nature.
            moqdetails.Setup(x => x.GetWorkDurationTotalSalary(It.IsAny<int>())).Returns(() => 18000000);
            //It.IsAny<int> means not caring about what value is passed and the value passed is a default value like here since it is int so it will pass 0.

            var res1 = moqdetails.Object;


            Assert.AreEqual(true, res1.SufficientSalary(1800));
            //So in SufficientSalary whereever the GetWorkDuration is getting implemented and whatever data is paeed the return will be always 18000000



        }

        public void setEmployee(Employees e)
        {
            e.EmpId = 1;
            e.Emp_Name = "Soumya";
            e.Emp_Salary = 12000;
            e.DurationWorked = 9;
        }
        [TestMethod]
        public void TestMethod2()
        {
            Mock<Employees> mockem = new Mock<Employees>().SetupAllProperties();

            setEmployee(mockem.Object);

            Assert.AreEqual(1, mockem.Object.EmpId);

        }


    }
}
