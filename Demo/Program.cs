﻿using Demo.Data;
using Demo.Data.Models;
using System.Data.Entity;

namespace Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
           using  CompanyDbContext dbContext = new CompanyDbContext();

            #region Loading Navigation Properties 

            #region Navigation Property By Default Isn't Loeaded 
            #region Example01 

            // CompanDbContextSeed.seed(dbContext);  

            ///  var employee = (from e in dbContext.Employees
            ///                 where e.Code == 6
            ///                 select e).FirstOrDefault();
            ///
            ///  if(employee is not null)
            ///  {
            ///      Console.WriteLine($"Employee :Id {employee.Code} :: Name ={employee.Name} :: \n Department : {employee.Department?.Name ?? "Not Found "} ");
            ///  }

            #endregion

            #region Example 02 
            ///   var department =( from d in dbContext.Departments
            ///                    where d.DeptId==10
            ///                    select d).FirstOrDefault();
            ///
            ///
            ///   if (department is not null)
            ///   {
            ///       Console.WriteLine($"Department : Id = {department.DeptId} :: Name =  {department.Name}");
            ///
            ///       foreach(var item in department.Employees)
            ///           Console.WriteLine($"---Employee : Name {item.Name}");
            ///
            ///   }
            /// 
            #endregion
            #endregion

            #region Explicit Loading 

            #region Example01 


            ///  var employee = (from e in dbContext.Employees
            ///                 where e.Code == 6
            ///                 select e).FirstOrDefault();
            ///
            ///  if(employee is not null)
            ///  {
            ///      dbContext.Entry(employee).Reference(nameof(Employee.Department)).Load();
            ///      Console.WriteLine($"Employee :Id {employee.Code} :: Name ={employee.Name} :: \n Department : {employee.Department?.Name ?? "Not Found "} ");
            ///  }

            #endregion

            #region Example 02 
            ///   var department =( from d in dbContext.Departments
            ///                    where d.DeptId==10
            ///                    select d).FirstOrDefault();
            ///
            ///
            ///   if (department is not null)
            ///   {
            ///       Console.WriteLine($"Department : Id = {department.DeptId} :: Name =  {department.Name}");
            ///    dbContext.Entry(department).Collection(nameof(Department.Employees)).Load();
            ///
            ///       foreach(var item in department.Employees)
            ///           Console.WriteLine($"---Employee : Name {item.Name}");
            ///
            ///   }

            #endregion
            #endregion


            #region Eager Loading  
            #region Example01 


            ///  var employee = (from e in dbContext.Employees.Include("Department")
            ///                 where e.Code == 6
            ///                 select e).FirstOrDefault();
            ///
            ///  if(employee is not null)
            ///  {
            ///      
            ///      Console.WriteLine($"Employee :Id {employee.Code} :: Name ={employee.Name} :: \n Department : {employee.Department?.Name ?? "Not Found "} ");
            ///  }

            #endregion

            #region Example 02 
            ///  var department =( from d in dbContext.Departments.Include(D=>D.Employees)
            ///                   where d.DeptId==10
            ///                   select d).FirstOrDefault();
            ///
            ///
            ///  if (department is not null)
            ///  {
            ///      Console.WriteLine($"Department : Id = {department.DeptId} :: Name =  {department.Name}");
            ///   dbContext.Entry(department).Collection(nameof(Department.Employees)).Load();
            ///
            ///      foreach(var item in department.Employees)
            ///          Console.WriteLine($"---Employee : Name {item.Name}");
            ///
        }

        #endregion 
        #endregion


        #endregion

    }
    }

