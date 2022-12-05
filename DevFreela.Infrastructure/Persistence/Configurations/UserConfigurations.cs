﻿using DevFreela.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Infrastructure.Persistence.Configurations
{
    public class UserConfigurations : IEntityTypeConfiguration<User>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<User> builder)
        {
            builder
            .HasKey(p => p.Id);

            builder
                .HasMany(u => u.Skills)
                .WithOne()
                .HasForeignKey(u => u.IdSkill)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
