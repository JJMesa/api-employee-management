﻿// <auto-generated />
using System;
using EmployeeManagement.Api.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EmployeeManagement.Api.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240318164206_Create_Model")]
    partial class Create_Model
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseCollation("Modern_Spanish_CI_AS")
                .HasAnnotation("ProductVersion", "6.0.27")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("EmployeeManagement.Api.Models.Entities.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("EMPLOYEE_ID")
                        .HasColumnOrder(1);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeId"), 1L, 1);

                    b.Property<DateTime>("DateBirth")
                        .HasColumnType("date")
                        .HasColumnName("BIRTH_DATE")
                        .HasColumnOrder(5);

                    b.Property<DateTime>("DateEntry")
                        .HasColumnType("date")
                        .HasColumnName("DATE_ENTRY")
                        .HasColumnOrder(6);

                    b.Property<string>("Identification")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("varchar(16)")
                        .HasColumnName("IDENTIFICATION")
                        .HasColumnOrder(4);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)")
                        .HasColumnName("LAST_NAME")
                        .HasColumnOrder(3);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)")
                        .HasColumnName("NAME")
                        .HasColumnOrder(2);

                    b.Property<string>("PathPhoto")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)")
                        .HasColumnName("PATH_PHOTO")
                        .HasColumnOrder(7);

                    b.HasKey("EmployeeId");

                    b.ToTable("EMPLOYEE", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
