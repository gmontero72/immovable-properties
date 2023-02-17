﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence;

#nullable disable

namespace Persistence.Migrations
{
    [DbContext(typeof(WepsysContext))]
    partial class WepsysContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("RINovus")
                .HasAnnotation("ProductVersion", "6.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Persistence.Models.ImmovableOwnerDb", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Codia")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("CreationDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("IdentificationNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Owners", "RINovus");
                });

            modelBuilder.Entity("Persistence.Models.ImmovablePropertyDb", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Area")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("ImmovableOwnerClassId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("ImmovablePropertyTypes")
                        .HasColumnType("int");

                    b.Property<decimal>("Region")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Surface")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("ImmovableOwnerClassId");

                    b.ToTable("Properties", "RINovus");
                });

            modelBuilder.Entity("Persistence.Models.ImmovablePropertyDb", b =>
                {
                    b.HasOne("Persistence.Models.ImmovableOwnerDb", "OwnerDb")
                        .WithMany("PropertiesList")
                        .HasForeignKey("ImmovableOwnerClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OwnerDb");
                });

            modelBuilder.Entity("Persistence.Models.ImmovableOwnerDb", b =>
                {
                    b.Navigation("PropertiesList");
                });
#pragma warning restore 612, 618
        }
    }
}
