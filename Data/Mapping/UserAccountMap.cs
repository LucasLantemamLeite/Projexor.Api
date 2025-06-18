using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projexor.Models;

namespace Projexor.Data.Mapping;

public class UserAccountMap : IEntityTypeConfiguration<UserAccount>
{
    public void Configure(EntityTypeBuilder<UserAccount> builder)
    {
        builder.ToTable("UserAccount");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("Id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Email)
            .HasColumnName("Email")
            .HasColumnType("TEXT")
            .IsRequired();

        builder.HasIndex(x => x.Email, "Unique_Key_Email_UserAccount")
            .IsUnique();

        builder.Property(x => x.PasswordHash)
            .HasColumnName("PasswordHash")
            .HasColumnType("TEXT")
            .IsRequired();

        builder.Property(x => x.PhoneNumber)
            .HasColumnName("PhoneNumber")
            .HasColumnType("TEXT")
            .IsRequired();

        builder.HasIndex(x => x.PhoneNumber, "Unique_Key_PhoneNumber_UserAccount")
           .IsUnique();

        builder.Property(x => x.BirthDate)
            .HasColumnName("BirthDate")
            .HasColumnType("TEXT")
            .IsRequired();

        builder.Property(x => x.CreateAt)
            .HasColumnName("CreateAt")
            .HasColumnType("TEXT")
            .IsRequired();

        builder.Property(x => x.Active)
            .HasColumnName("Active")
            .HasColumnType("INTEGER")
            .IsRequired();

        builder.Property(x => x.Role)
            .HasColumnName("Role")
            .HasColumnType("INTEGER")
            .IsRequired();
    }
}