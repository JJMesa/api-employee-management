using EmployeeManagement.Api.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeeManagement.Api.Models.Configurations;

public class EmployeeConfig : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.ToTable("EMPLOYEE");

        builder.HasKey(e => e.EmployeeId);

        builder.Property(e => e.EmployeeId)
            .HasColumnName("EMPLOYEE_ID")
            .HasColumnOrder(1);

        builder.Property(e => e.Name)
            .HasColumnName("NAME")
            .HasColumnType("varchar(128)")
            .HasMaxLength(128)
            .HasColumnOrder(2);

        builder.Property(e => e.LastName)
            .HasColumnName("LAST_NAME")
            .HasColumnType("varchar(128)")
            .HasMaxLength(128)
            .HasColumnOrder(3);

        builder.Property(e => e.Identification)
            .HasColumnName("IDENTIFICATION")
            .HasColumnType("varchar(16)")
            .HasMaxLength(16)
            .HasColumnOrder(4);

        builder.Property(e => e.DateBirth)
            .HasColumnName("BIRTH_DATE")
            .HasColumnType("date")
            .HasColumnOrder(5);

        builder.Property(e => e.DateEntry)
            .HasColumnName("DATE_ENTRY")
            .HasColumnType("date")
            .HasColumnOrder(6);

        builder.Property(e => e.PathPhoto)
            .HasColumnName("PATH_PHOTO")
            .HasColumnType("varchar(256)")
            .HasMaxLength(256)
            .HasColumnOrder(7);
    }
}