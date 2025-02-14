using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Data.Models
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Code { get; set; }
        public /*required*/ string? Name { get; set; }
        public int? Age { get; set; }

        [EmailAddress]
        //[DataType(DataType.EmailAddress)]
        public string? Email { get; set; }
        public double Salary { get; set; }

        public string? Address { get; set; } 

        public int? DepartmentDeptId { get; set; }
        public virtual Department? Department { get; set; }

        public virtual Department? DepartmentManager { get; set; }


        //   public Address? DetailsAddress { get; set; }
    }
}

