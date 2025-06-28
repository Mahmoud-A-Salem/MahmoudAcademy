using MahmoudAcademy.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MahmoudAcademy.Data.Config
{
    public class OfficeConfiguration : IEntityTypeConfiguration<Office>
    {
        public void Configure(EntityTypeBuilder<Office> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id).ValueGeneratedNever();

            builder.Property(o => o.OfficeName)
                .HasColumnType("VARCHAR")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(o => o.OfficeLocation)
                .HasColumnType("VARCHAR")
                .HasMaxLength(50)
                .IsRequired();

            builder.ToTable("Offices");

            builder.HasData(LoadOffices());
        }

        private static List<Office> LoadOffices()
        {
            return new List<Office>() {
                    new Office { Id = 1, OfficeName = "Off_05", OfficeLocation = "building A"},
                    new Office { Id = 2, OfficeName = "Off_12", OfficeLocation = "building B"},
                    new Office { Id = 3, OfficeName = "Off_32", OfficeLocation = "Adminstration"},
                    new Office { Id = 4, OfficeName = "Off_44", OfficeLocation = "IT Department"},
                    new Office { Id = 5, OfficeName = "Off_43", OfficeLocation = "IT Department"}
            };
        }
    }
}
