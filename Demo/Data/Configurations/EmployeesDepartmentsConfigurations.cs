using Demo.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Data.Configurations
{
    internal class EmployeesDepartmentsConfigurations : IEntityTypeConfiguration<EmployeesDapartmets>
    {
        public void Configure(EntityTypeBuilder<EmployeesDapartmets> builder)
        {
          builder.ToView("EmployeesDepartmentsView").HasNoKey();
        }
    }

}
