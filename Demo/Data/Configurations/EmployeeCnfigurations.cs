using Demo.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Data.Configurations
{
    internal class EmployeeCnfigurations : IEntityTypeConfiguration<Employee>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Employee> builder)
        {
            builder
           .Property<string>("Address")//2. nameof(Employee.Address) ||3. E=>E.Address ==>2 and 3 used when property is found in moder
           .HasColumnName("varchar")
           .HasMaxLength(100)
           .HasDefaultValue("cairo")
           .IsRequired();


            builder.HasOne(D => D.DepartmentManager)
                .WithOne(E => E.Manager)
                .HasForeignKey<Department>(E => E.ManagerId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.NoAction);


            //  builder.OwnsOne(E => E.DetailsAddress, Address => Address.WithOwner());

        }
    }
}
