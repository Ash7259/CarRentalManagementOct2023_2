﻿using CarRentalManagementOct2023_2.Shared.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRentalManagementOct2023_2.Server.Configurations.Entities
{
    public class MakeSeedConfiguration : IEntityTypeConfiguration<Make>
    {
        public void Configure(EntityTypeBuilder<Make> builder)
        {
            builder.HasData(
               new Make
               {
                   Id = 1,
                   Name = "BMW",
                   DateCreated = DateTime.Now,
                   DateUpdated = DateTime.Now,
                   CreatedBy = "System",
                   UpdatedBy = "System"
               },
               new Make
               {
                   Id = 2,
                   Name = "Toyota",
                   DateCreated = DateTime.Now,
                   DateUpdated = DateTime.Now,
                   CreatedBy = "System",
                   UpdatedBy = "System"
               }
               );
        }
    }
}
