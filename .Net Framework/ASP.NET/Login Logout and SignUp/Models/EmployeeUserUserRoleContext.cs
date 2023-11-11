using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Login_Logout_and_SignUp.Models
{
    public class EmployeeUserUserRoleContext : DbContext
    {
        public EmployeeUserUserRoleContext():base("name=LoginLogoutSignUpConn")
        {

        }
        public virtual DbSet<Employee> Employees { set; get; }
        public virtual DbSet<User> Users { set; get; }
        public virtual DbSet<UserRole> UserRoles { set; get; }
    }
}