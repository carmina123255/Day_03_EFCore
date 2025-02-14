using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Demo.Data.Migrations
{
    /// <inheritdoc />
    public partial class EmployeesDepartmentsView : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"Create View EmployeesDpartmentsView 
                               with Encryption ,SchemaBinding 
                               As
                               Select E.Code 'EmployeeCode' ,E.Name 'EmployeeName' ,D.DeptId 'DepartmentId' ,D.DepartmentName 'DepartmentName'
                               from dbo.Employees E left outer join dbo.Departments D
                               on E.DepartmentDeptId=D.DeptId");
        }

        /// <inheritdoc />
      protected override void Down(MigrationBuilder migrationBuilder)
      {
          migrationBuilder.Sql(@"Drop View EmployeesDpartmentsView ");
      }
    }
}
