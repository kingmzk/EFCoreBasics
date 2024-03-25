using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreBasics.Models
{
    public class Manager
    {
        public int ManagerId { get; set; }  //PrimaryKey

        public string MngFirstName { get; set; }

        public string MngLastName { get; set; }

        //one to many relationship with Employee
        public virtual ICollection<Employee> Employees { get; set; }  //Collection Navigation property to represent all employees managed by this manager
    }
}
