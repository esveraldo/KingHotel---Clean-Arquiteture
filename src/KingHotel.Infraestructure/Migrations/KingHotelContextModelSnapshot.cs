﻿// <auto-generated />
using System;
using KingHotel.Infraestructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace KingHotel.Infraestructure.Migrations
{
    [DbContext(typeof(KingHotelContext))]
    partial class KingHotelContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("KingHotel.Domain.Entity.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("Document")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(150)")
                        .HasColumnName("Email");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(150)")
                        .HasColumnName("Name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("Password");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Role");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("KingHotel.Domain.Entity.User", b =>
                {
                    b.OwnsOne("KingHotel.Domain.VOs.Address", "Address", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("City")
                                .IsRequired()
                                .ValueGeneratedOnAdd()
                                .HasColumnType("varchar(30)")
                                .HasDefaultValue("Not informed");

                            b1.Property<string>("Number")
                                .IsRequired()
                                .ValueGeneratedOnAdd()
                                .HasColumnType("varchar(10)")
                                .HasDefaultValue("Not informed");

                            b1.Property<string>("Street")
                                .IsRequired()
                                .ValueGeneratedOnAdd()
                                .HasColumnType("varchar(100)")
                                .HasDefaultValue("Not informed");

                            b1.Property<string>("ZipCode")
                                .IsRequired()
                                .ValueGeneratedOnAdd()
                                .HasColumnType("varchar(10)")
                                .HasDefaultValue("Not informed");

                            b1.HasKey("UserId");

                            b1.ToTable("Users");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.Navigation("Address")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
