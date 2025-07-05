using MahmoudAcademy.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MahmoudAcademy.Data.Config
{
    public class SectionConfiguration : IEntityTypeConfiguration<Section>
    {
        public void Configure(EntityTypeBuilder<Section> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id).ValueGeneratedNever();

            builder.Property(s => s.SectionName)
                .HasColumnType("VARCHAR")
                .HasMaxLength(255)
                .IsRequired();

            builder.OwnsOne(s => s.TimeSlot, ts =>
            {
                ts.Property(s => s.StartTime).HasColumnType("time").HasColumnName("StartTime");
                ts.Property(e => e.EndTime).HasColumnType("time").HasColumnName("EndTime");
            });

            builder.HasOne(s => s.Course)
                .WithMany(c => c.Sections)
                .HasForeignKey(s => s.CourseId)
                .IsRequired();

            builder.HasOne(s => s.Instructor)
                .WithMany(i => i.Sections)
                .HasForeignKey(s => s.InstructorId)
                .IsRequired(false);

            builder.HasOne(c => c.Schedule)
                .WithMany(s => s.Sections)
                .HasForeignKey(s => s.ScheduleId)
                .IsRequired();

            builder.HasMany(s => s.Students)
                .WithMany(s => s.Sections)
                .UsingEntity<Enrollment>();

            builder.ToTable("Sections");
        }
    }
}
