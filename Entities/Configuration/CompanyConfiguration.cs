using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Configuration
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasData
            (
                new Company
                {
                    Id = new Guid("b3a56076-8ef3-418b-8764-931a6bd19ace"),
                    Name = "IT_Solutions Ltd",
                    Address = "583 Wall Dr. Gwynn Oak, MD 21207",
                    Country = "USA"
                },
                new Company
                {
                    Id = new Guid("01a47ac2-cab8-40d8-b44e-93d02e50d605"),
                    Name = "Admin_Solutions Ltd",
                    Address = "313 Forest Avenue, BF 923",
                    Country = "USA"
                }
            );
        }
    }
}
