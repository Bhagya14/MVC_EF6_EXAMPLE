using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_EF6_Example.Models
{
    public class EmployeeModel
    {
        [Key]
        public string Employeeemailid { get; set; }

        [Required(ErrorMessage ="*")]
        public string Employeename { get; set; }
        [Required(ErrorMessage ="*")]
        public int Employeesalary { get; set; }
    }
}