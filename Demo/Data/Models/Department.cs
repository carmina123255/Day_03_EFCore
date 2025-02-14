using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Data.Models
{
    internal class Department
    {
        public int DeptId { get; set; }
        public string? Name { get; set; }

        public DateTime? CreationDate { get; set; }
        public ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();



        public Employee? Manager { get; set; } = null!; //Navigation propery [one]
        public int? ManagerId { get; set; }

    }
}
