﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Zoo.Data;

namespace Zoo.Data.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20211030121340_InitialCreateMigration")]
    partial class InitialCreateMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Zoo.Core.Models.Enclosure", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<Guid>("Guid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Enclosures");
                });

            modelBuilder.Entity("Zoo.Core.Models.Giraffe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime2");

                    b.Property<int>("EnclosureId")
                        .HasColumnType("int");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<Guid>("Guid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NeckLengthInCm")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EnclosureId");

                    b.ToTable("Giraffes");
                });

            modelBuilder.Entity("Zoo.Core.Models.MigrationsHistory", b =>
                {
                    b.Property<string>("MigrationId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("IsSeeded")
                        .HasColumnType("bit");

                    b.Property<string>("ProductVersion")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MigrationId");

                    b.ToTable("__EFMigrationsHistory");
                });

            modelBuilder.Entity("Zoo.Core.Models.Zebra", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime2");

                    b.Property<int>("EnclosureId")
                        .HasColumnType("int");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<Guid>("Guid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Stripes")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EnclosureId");

                    b.ToTable("Zebras");
                });

            modelBuilder.Entity("Zoo.Core.Models.Giraffe", b =>
                {
                    b.HasOne("Zoo.Core.Models.Enclosure", "Enclosure")
                        .WithMany()
                        .HasForeignKey("EnclosureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Enclosure");
                });

            modelBuilder.Entity("Zoo.Core.Models.Zebra", b =>
                {
                    b.HasOne("Zoo.Core.Models.Enclosure", "Enclosure")
                        .WithMany()
                        .HasForeignKey("EnclosureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Enclosure");
                });
#pragma warning restore 612, 618
        }
    }
}
