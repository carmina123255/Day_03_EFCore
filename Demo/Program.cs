using Demo.Data;
using Demo.Data.Models;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System.Data.Entity;
using System.Reflection.Emit;

namespace Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using CompanyDbContext dbContext = new CompanyDbContext();

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
            ///  var department = (from d in dbContext.Departments.Include(D => D.Employees)
            ///                    where d.DeptId == 10
            ///                    select d).FirstOrDefault();
            ///
            ///
            ///  if (department is not null)
            ///  {
            ///      Console.WriteLine($"Department : Id = {department.DeptId} :: Name =  {department.Name}");
            ///      dbContext.Entry(department).Collection(nameof(Department.Employees)).Load();
            ///
            ///      foreach (var item in department.Employees)
            ///          Console.WriteLine($"---Employee : Name {item.Name}");
            ///
            ///  }

            #endregion


            #endregion

            #region Lazy Loading 

            #region Example01 
            /// var employee = (from e in dbContext.Employees
            ///                where e.Code == 6
            ///                select e).FirstOrDefault();
            ///
            /// if(employee is not null)
            /// {
            ///     
            ///     Console.WriteLine($"Employee :Id {employee.Code} :: Name ={employee.Name} :: \n Department : {employee.Department?.Name ?? "Not Found "} ");
            /// } 
            #endregion

            #region Example 02 
            ///   var department = (from d in dbContext.Departments
            ///                     where d.DeptId == 10
            ///                     select d).FirstOrDefault();
            ///
            ///
            ///   if (department is not null)
            ///   {
            ///       Console.WriteLine($"Department : Id = {department.DeptId} :: Name =  {department.Name}");
            ///       dbContext.Entry(department).Collection(nameof(Department.Employees)).Load();
            ///
            ///       foreach (var item in department.Employees)
            ///           Console.WriteLine($"---Employee : Name {item.Name}");
            ///
            ///   } 
            #endregion
            #endregion

            #endregion


            #region LINQ JOin Operators [Join() , GroupJoin() ]

            #region inner Join 
            /// var Result = from D in dbContext.Departments
            ///              join E in dbContext.Employees
            ///              on D.DeptId equals E.DepartmentDeptId
            ///              select new
            ///              {
            ///                  EmployeeId = E.Code,
            ///                  EmployeeName = E.Name,
            ///                  DepartmentId = D.DeptId,
            ///                  DepartmentName = D.Name
            ///              };

            ///  Result = dbContext.Departments.Join(dbContext.Employees,
            ///                                      D => D.DeptId,
            ///                                      E => E.DepartmentDeptId,
            ///                                      (D, E) => new
            ///                                      {
            ///                                          EmployeeId = E.Code,
            ///                                          EmployeeName = E.Name,
            ///                                          DepartmentId = D.DeptId,
            ///                                          DepartmentName = D.Name
            ///
            ///                                      });
            ///                  

            ///  foreach (var item in Result)
            ///  {
            ///      Console.WriteLine($"Employee : {item.EmployeeName}  Department : {item.DepartmentName}");
            ///  }


            #endregion

            #region GroupJoin 

            #region Example 01 
            /// var Result = dbContext.Departments.GroupJoin(dbContext.Employees
            ///                                       , D => D.DeptId,
            ///                                       E => E.DepartmentDeptId,
            ///                                       (Department, Employees) => new
            ///                                       {
            ///                                           Department,
            ///                                           Employees
            ///
            ///                                       }).Where(X => X.Employees.Count() > 0);//Where used to make innner JOin
            ///

            ///  Result = from D in dbContext.Departments
            ///           join E in dbContext.Employees
            ///           on D.DeptId equals E.DepartmentDeptId
            ///           into emps
            ///           select new
            ///           {
            ///               Department = D,
            ///               Employees = emps
            ///
            ///           } into X
            ///           where X.Employees.Count() > 0
            ///           select X;


            ///  foreach(var item in Result)
            ///  {
            ///      Console.WriteLine($"Department : Id = {item.Department.DeptId}  Name = {item.Department.Name}");
            ///      foreach(var employee in item.Employees)
            ///      {
            ///          Console.WriteLine($"...Employees : Code :{employee.Code} Name :{employee.Name} ");
            ///      }
            ///  }
            /// 
            #endregion

            #region Example 02

            /// var Result = dbContext.Employees.GroupJoin(dbContext.Departments,
            ///                                      E => E.DepartmentDeptId,
            ///                                      D => D.DeptId,
            ///                                      (Employee, Departments) => new
            ///                                      {
            ///                                          Employee,
            ///                                          Departments
            ///
            ///                                      }).Where(X => X.Departments.Count() > 0);//Where used to make innner JOin
            ///


            ///  Result = from E in dbContext.Employees
            ///          join D in dbContext.Departments
            ///        on E.DepartmentDeptId equals D.DeptId
            ///        into depts
            ///          select new
            ///          {
            ///              Employee = E,
            ///              Departments = depts
            ///
            ///          } into X
            ///          where X.Departments.Count() > 0
            ///          select X;


            /// foreach(var item in Result)
            /// {
            ///     Console.WriteLine($"Employee : Code = {item.Employee.Code}  Name = {item.Employee.Name}");
            ///     foreach(var departments in item.Departments)    
            ///         Console.WriteLine($"...Department : Id = {departments.DeptId}  Name ={departments.Name}");
            /// }


            #endregion
            #endregion


            #region Left Outer Join 

            #region Example 01 
            /// var Result = dbContext.Departments.GroupJoin(dbContext.Employees,
            ///                                                 D => D.DeptId,
            ///                                                 E => E.DepartmentDeptId,
            ///                                                 (Department, Employee) => new
            ///                                                 {
            ///                                                     Department,
            ///                                                     Employee = Employee.DefaultIfEmpty()
            ///                                                 }).SelectMany(X=>X.Employee,(X,Employee)=>new { X.Department, Employee });
            ///
            /// Result = from D in dbContext.Departments
            ///          join E in dbContext.Employees
            ///          on D.DeptId equals E.DepartmentDeptId
            ///          into Employee
            ///          select new
            ///          {
            ///              Department = D,
            ///              Employee = Employee.DefaultIfEmpty(),
            ///          } into X
            ///          from Employee in X.Employee
            ///          select new { X.Department, Employee }; 


            /// foreach(var item in Result )
            /// {
            ///     Console.WriteLine($"DepartmentName :{item.Department.Name}  , EmployeeName ={item.Employee?.Name??  "Not foune"} ");
            /// } 
            /// 
            #endregion


            #region Example 02 

            ///    var Result = dbContext.Employees.GroupJoin(dbContext.Departments,
            ///                                                    E => E.DepartmentDeptId,
            ///                                                    D => D.DeptId,
            ///                                                    (Employee, Departments) => new
            ///                                                    {
            ///                                                        Employee,
            ///                                                        Departments = Departments.DefaultIfEmpty()
            ///                                                    }).SelectMany(X => X.Departments, (X, Department) => new { X.Employee, Department });
            ///
            ///    Result = from E in dbContext.Employees
            ///             join D in dbContext.Departments
            ///           on E.DepartmentDeptId equals D.DeptId
            ///           into Departments
            ///             select new
            ///             {
            ///                 Employee = E,
            ///                 Departments = Departments.DefaultIfEmpty()
            ///             } into X
            ///             from Department in X.Departments
            ///             select new { X.Employee, Department };
            ///
            ///    foreach (var item in Result)
            ///    {
            ///        Console.WriteLine($"EmployeeName : {item.Employee.Name} , DepartmentName :{item.Department?.Name??"Not Found "}");
            ///    }
            ///
            #endregion

            #endregion

            #region Cross JOin 

         ///  var Result = from E in dbContext.Employees
         ///               from D in dbContext.Departments
         ///               select new
         ///               {
         ///                   Department = D,
         ///                   Employee = E
         ///               };

        ///    Result = dbContext.Employees.SelectMany(E => dbContext.Departments.Select( D => new
        ///    {
        ///       Department=D,
        ///       Employee=E
        ///    }));

          /// foreach(var item in Result)
          /// {
          ///     Console.WriteLine($"Employee :{item.Employee.Name} , Department : {item.Department.Name}");
          /// }
            #endregion
            #endregion

        }
    }
}

