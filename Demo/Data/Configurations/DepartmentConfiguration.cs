using Demo.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Data.Configurations
{
    internal class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Department> builder)
        {
            builder
                     .ToTable("Departments")
                      .HasKey(D => D.DeptId);
            //.HasKey("DeptId");
            builder
                  .Property(D => D.DeptId)
                   .UseIdentityColumn(10, 10);

            builder.Property(D => D.Name)
                 .HasColumnName("DepartmentName")
                 .HasColumnType("varchar")
                 .IsRequired()
                 .HasAnnotation("MaxLength", 50);

         //  builder.Property(D => D.CreationDate)
         //        .HasComputedColumnSql("GETDATE()")//value calculated based on other Coulmn
         //        /*.HasDefaultValueSql("GETDATE()")*/;//default value of a coulmn if no value 

            //one to manyRelation ship work
            builder.HasMany(D => D.Employees)
                    .WithOne(D => D.Department)
                    .HasForeignKey(D => D.DepartmentDeptId)
                    .IsRequired(false)
                    .OnDelete(DeleteBehavior.SetNull);
        }
    }
}