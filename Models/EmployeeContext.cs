using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace Assi7.Models
{
    public class EmployeeContext:DbContext
    {
        public EmployeeContext()
            :base("name=DB")
        {

        }
        public DbSet<Employee> EmployeeTable { get; set; }
        public DbSet<Department> DepartmentTable { get; set; }
    }
}