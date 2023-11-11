using _modelcheck.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _modelcheck
{
    public class Repository
    {
        public List<Employee> GetAllEmployees()
        {
            return DataSource();
        }

        public Employee GetById(int id)
        {
            return DataSource().FirstOrDefault(x => x.id == id);
        }

        public List<Employee> SearchEmployee(string name )
        {
            return DataSource().Where(x => x.Name.Contains(name)).ToList();
        }

        private List<Employee> DataSource()
        {
            return new List<Employee>()
            {
                new Employee()
                {
                    id=1,
                    Name="Soumyajeet",
                    Age=22
                },
                new Employee()
                {
                    id=2,
                    Name="Sounak",
                    Age=22
                },
                new Employee()
                {
                    id=3,
                    Name="Sounak",
                    Age=23
                },
                new Employee()
                {
                    id=4,
                    Name="Sehroz",
                    Age=23
                }

            };
        }
    }
}
