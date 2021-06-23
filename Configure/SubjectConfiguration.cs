using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GradingSystem.Models;

namespace GradingSystem.Configure
{
    class SubjectConfiguration: IEntityTypeConfiguration<Subject>
    {
        public void Configure(EntityTypeBuilder<Subject> builder)
        {
            builder.HasIndex(s => s.Name).IsUnique();
            builder.Property(s => s.Name).IsRequired();
        }
    }
}
