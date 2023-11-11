using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee
{
    public class EmployeeGetDetails : IEmployeeDetails
    {
        private int totalsalary=0;
        List<Employees> emp = new List<Employees>()
        {
            new Employees()
            {
                EmpId=1,
                Emp_Name="A",
                Emp_Salary=20000,
                DurationWorked = 9
            },

            new Employees()
            {
                EmpId=1,
                Emp_Name="b",
                Emp_Salary=30000,
                DurationWorked = 10
            },

            new Employees()
            {
                EmpId=1,
                Emp_Name="C",
                Emp_Salary=40000,
                DurationWorked = 11
            },
            new Employees()
            {
                EmpId=1,
                Emp_Name="D",
                Emp_Salary=50000,
                DurationWorked = 12
            }
        };

        public virtual int GetWorkDurationTotalSalary(int EmpId)
        {
            var e = emp.FirstOrDefault(x => x.EmpId == EmpId);

            totalsalary = e.Emp_Salary * e.DurationWorked;

            return totalsalary;
        }

        public bool SufficientSalary(int Salary)
        {
            
            
            if (GetWorkDurationTotalSalary(1)>Salary)
                return true;
            return false;
        }
    }
}
