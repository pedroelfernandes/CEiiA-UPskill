﻿// <auto-generated />
using System;
using Greenhouse.web.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Greenhouse.web.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Greenhouse.web.Models.API", b =>
                {
                    b.Property<int>("ApiId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ApiId"), 1L, 1);

                    b.Property<string>("ApiDescription")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ApiName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ApiId");

                    b.ToTable("APIs");
                });

            modelBuilder.Entity("Greenhouse.web.Models.Reading", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("ReadDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ReadingUnit")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SensorId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SensorType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Readings");
                });

            modelBuilder.Entity("Greenhouse.web.Models.Sensor", b =>
                {
                    b.Property<int>("SensorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SensorId"), 1L, 1);

                    b.Property<int>("ApiId")
                        .HasColumnType("int");

                    b.Property<string>("SensorName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SensorType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SensorId");

                    b.ToTable("Sensors");
                });

            modelBuilder.Entity("Greenhouse.web.Models.SensorType", b =>
                {
                    b.Property<int>("IdSensorType")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdSensorType"), 1L, 1);

                    b.Property<string>("NameSensorType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SensorTypeDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdSensorType");

                    b.ToTable("SensorTypes");
                });
#pragma warning restore 612, 618
        }
    }
}
