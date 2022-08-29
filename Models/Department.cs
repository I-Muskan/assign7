using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Assi7.Models
{
    [Table("tblDepartment")]
    public class Department
    {

        
        [Key]
        public int DeptId { get; set; }

        [Required(ErrorMessage = "Department Name is required")]
        public string DeptName { get; set; }
    }
}