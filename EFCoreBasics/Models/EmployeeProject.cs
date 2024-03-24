using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreBasics.Models
{
    //Junction Table for Entity Framework Core (Many-to-Many) Model Example (Many-to-Many) Relationship between Employee and Project Tables 
    public class EmployeeProject
    {
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; } //Reference Navigation Property
        public int ProjectId { get; set; }
        public Project Project { get; set; } //Reference Navigation Property

    }
}
