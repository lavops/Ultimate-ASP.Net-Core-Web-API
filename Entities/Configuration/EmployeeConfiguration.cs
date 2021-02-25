using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Configuration
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasData
            (
                new Employee
                {
                    Id = new Guid("95c117ba-3e58-4b37-a2f8-dd0b573c212d"),
                    Name = "Sam Raiden",
                    Age = 26,
                    Position = "Software developer",
                    CompanyId = new Guid("b3a56076-8ef3-418b-8764-931a6bd19ace")
                },
                new Employee
                {
                    Id = new Guid("6c780611-089a-4033-be80-83cf0998ea35"),
                    Name = "Jana McLeaf",
                    Age = 30,
                    Position = "Software developer",
                    CompanyId = new Guid("b3a56076-8ef3-418b-8764-931a6bd19ace")
                },
                new Employee
                {
                    Id = new Guid("4abf4778-4b19-4e6a-b9c5-fb970d79f10d"),
                    Name = "Kane Miller",
                    Age = 35,
                    Position = "Administrator",
                    CompanyId = new Guid("01a47ac2-cab8-40d8-b44e-93d02e50d605")
                }
            );
        }
    }
}
