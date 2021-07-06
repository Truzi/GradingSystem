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
            // Many-Many relation has a different configuration
            // refer to following: https://www.learnentityframeworkcore.com/configuration/many-to-many-relationship-configuration
            builder.Property(g => g.Value).IsRequired();
            builder.Property(g => g.SubjectId).IsRequired();
            builder.Property(g => g.StudentId).IsRequired();

            builder.HasKey(g => new { g.StudentId, g.SubjectId });
            builder.HasOne(g => g.Student).WithMany(s => s.Grades).HasForeignKey(g => g.StudentId);
            builder.HasOne(g => g.Subject).WithMany(s => s.Grades).HasForeignKey(g => g.SubjectId);
        }
    }
}
