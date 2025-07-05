using MahmoudAcademy.Entities;
using MahmoudAcademy.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MahmoudAcademy.Data.Config
{
    public class ScheduleConfiguration : IEntityTypeConfiguration<Schedule>
    {
        public void Configure(EntityTypeBuilder<Schedule> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id).ValueGeneratedNever();

            builder.Property(s => s.Title)
                .HasConversion(
                    x => x.ToString(),
                    x => (ScheduleEnum) Enum.Parse(typeof(ScheduleEnum), x)
                );

            builder.ToTable("Schedules");
        }
    }
}
