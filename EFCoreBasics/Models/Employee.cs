using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreBasics.Models
{
    public class Employee
    {
       // [Key]
        public int EmployeeId { get; set; } //primary key

       // [Required]
        public string EmpFirstName { get; set; }

        public string EmpLastName { get; set; }

        public long EmpSalary { get; set; }

        //one-to-one relationship with employee details
        public EmployeeDetails EmployeeDetails { get; set; } //reference navigation property to dependent


        //one-to-Many relationship with manager
        public int ManagerId { get; set; }  //ForeignKey
        public Manager Manager { get; set; }  //reference navigation property to dependent (Manager)


        //Many to Many relationship with Project
        public ICollection<EmployeeProject> EmployeeProjects { get; set; } //Collection navigation property


    }
}
