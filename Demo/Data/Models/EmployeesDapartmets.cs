using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Data.Models
{
    public class EmployeesDapartmets
    {
        public int EmployeeCode { get; set; }   
        public string? EmployeeName { get; set; }
        public int DepartmentId { get; set; }   
        public string? DepartmentName { get; set; }
    }
}
