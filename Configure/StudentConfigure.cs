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
    class StudentConfigure: IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(s => s.ID);
            builder.Property(s => s.First).IsRequired();
            builder.Property(s => s.Last).IsRequired();
        }
    }
}
