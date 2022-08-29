using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assi7.Models
{
    [Table("tblEmployee")]
    public class Employee
    {
         [Key]
        public int EmpId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, MinimumLength = 4, ErrorMessage = "can not accept less than 4 or more than 100 character")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Gender is required")]

        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$")]

        public string Gender { get; set; }


        //[Required(ErrorMessage = "City is required")]
        //[StringLength(100, MinimumLength = 4, ErrorMessage = "can not accept less than 4 or more than 100 character")]
        
        public string City { get; set; }


        
        [Required(ErrorMessage = "Salary is required")]

        public decimal Salary { get; set; }

        [Required(ErrorMessage = "Department Id is required")]
        [ForeignKey ("Department")]
        public int Departments_DeptId{ get; set; }

       
        public Department Department { get; set; }



    }
}