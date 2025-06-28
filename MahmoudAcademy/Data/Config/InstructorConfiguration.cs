using MahmoudAcademy.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MahmoudAcademy.Data.Config
{
    public class InstructorConfiguration : IEntityTypeConfiguration<Instructor>
    {
        public void Configure(EntityTypeBuilder<Instructor> builder)
        {
            builder.HasKey(i => i.Id);
            builder.Property(i => i.Id).ValueGeneratedNever();

            builder.Property(i => i.FName)
                .HasColumnType("VARCHAR")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(i => i.LName)
                .HasColumnType("VARCHAR")
                .HasMaxLength(50)
                .IsRequired();

            builder.HasOne(i => i.Office)
                .WithOne(o => o.Instructor)
                .HasForeignKey<Instructor>(i => i.OfficeId)
                .IsRequired(false);

            builder.HasIndex(i => i.OfficeId).IsUnique();

            builder.ToTable("Instructors");

            builder.HasData(LoadInstructors());
        }

        private static List<Instructor> LoadInstructors()
        {
            return new List<Instructor>
            {
                new Instructor { Id = 1, FName = "Ahmed", LName = "Abdullah", OfficeId = 1},
                new Instructor { Id = 2, FName = "Yasmeen", LName = "Yasmeen", OfficeId = 2},
                new Instructor { Id = 3, FName = "Khalid", LName = "Hassan", OfficeId = 3},
                new Instructor { Id = 4, FName = "Nadia", LName = "Ali", OfficeId = 4},
                new Instructor { Id = 5, FName = "Omar", LName = "Ibrahim", OfficeId = 5}
            };
        }
    }
}
