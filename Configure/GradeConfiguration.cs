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
    class GradeConfiguration: IEntityTypeConfiguration<Grade>
    {
        public void Configure(EntityTypeBuilder<Grade> builder)
        {
            builder.HasKey(g => g.ID);
            builder.Property(g => g.Value).IsRequired();
            builder.Property(g => g.SubjectID).IsRequired();
            builder.Property(g => g.StudentID).IsRequired();
        }
    }
}
