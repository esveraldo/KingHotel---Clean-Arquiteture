using KingHotel.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingHotel.Infraestructure.Data.Mapping
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .HasColumnName("Name")
                .HasColumnType("varchar(150)")
                .IsRequired();

            builder.Property(x => x.Email)
                .HasColumnName("Email")
                .HasColumnType("varchar(150)")
                .IsRequired();

            builder.Property(x => x.Password)
                .HasColumnName("Password")
                .HasColumnType("varchar(255)")
                .IsRequired();

            builder.Property(x => x.Role)
                .HasColumnName("Role")
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder.OwnsOne(x => x.Address, x => {

                x.Property(x => x.Number)
                    .HasColumnType("varchar(10)")
                    .HasDefaultValue("Not informed");

                x.Property(x => x.Street)
                    .HasColumnType("varchar(100)")
                    .HasDefaultValue("Not informed");

                x.Property(x => x.City)
                    .HasColumnType("varchar(30)")
                    .HasDefaultValue("Not informed");

                x.Property(x => x.ZipCode)
                    .HasColumnType("varchar(10)")
                    .HasDefaultValue("Not informed");

            });

            builder.Property<int>(x => (int)x.Document)
                .HasColumnType("int")
                .IsRequired();

            builder.Property<int>(x => (int)x.Status)
                .HasColumnType("int")
                .IsRequired();
        }
    }
}
