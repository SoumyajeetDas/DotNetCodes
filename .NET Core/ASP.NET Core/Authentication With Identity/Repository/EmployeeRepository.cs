using Authentication_With_Identity.Data;
using Authentication_With_Identity.Models;
using Authentication_With_Identity.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Authentication_With_Identity.Repository
{
    [Authorize(Roles ="Admin")]
    public class EmployeeRepository : IEmployeeRepository
    {
        private ApplicationDbContext context;
        public EmployeeRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<List<Employee>> GetAllEmployees()
        {
            var emps = await context.Employees.ToListAsync();

            return emps;
        }
    }
}
