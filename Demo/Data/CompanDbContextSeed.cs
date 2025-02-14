using Demo.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Demo.Data
{
    internal static class CompanDbContextSeed
    {

        public static void seed(CompanyDbContext db)
        {
            if (!db.Departments.Any())
            {
            var departmentdata = File.ReadAllText("D:\\Route\\Entity Framework\\Session03\\Departments.json");

                var departments = JsonSerializer.Deserialize<List<Department>>(departmentdata);
                if (departments?.Count > 0)
                {
                    foreach (var item in departments)
                    {
                        db.Departments.Add(item);

                    }
                    db.SaveChanges();
                }
            }

         if (!db.Employees.Any())
         {
         var EmployeeData = File.ReadAllText("D:\\Route\\Entity Framework\\Session03\\Employees.json");
        
             var Employees = JsonSerializer.Deserialize<List<Employee>>(EmployeeData);
             if (Employees?.Count > 0)
             {
                 foreach (var employee in  Employees)
                 {
                     db.Employees.Add(employee);
        
                 }
                 db.SaveChanges();
             }
         }
        }
    }


}
