﻿// <auto-generated />
using System;
using Memento.Gpx.Infrastructures.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Memento.Gpx.Infrastructures.MementoMigrations
{
    [DbContext(typeof(MementoDbContext))]
    partial class MementoDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GpxMetadataTypeLinkType", b =>
                {
                    b.Property<int>("GpxMetadataTypesId")
                        .HasColumnType("int");

                    b.Property<int>("LinkTypesId")
                        .HasColumnType("int");

                    b.HasKey("GpxMetadataTypesId", "LinkTypesId");

                    b.HasIndex("LinkTypesId");

                    b.ToTable("GpxMetadataTypeLinkType");
                });

            modelBuilder.Entity("GpxWptTypeLinkType", b =>
                {
                    b.Property<int>("GpxWptTypesId")
                        .HasColumnType("int");

                    b.Property<int>("LinkTypesId")
                        .HasColumnType("int");

                    b.HasKey("GpxWptTypesId", "LinkTypesId");

                    b.HasIndex("LinkTypesId");

                    b.ToTable("GpxWptTypeLinkType");
                });

            modelBuilder.Entity("Memento.Gpx.Domain.BoundsType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:Identity", "1, 1");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("GpxMetadataTypeId")
                        .HasColumnType("int");

                    b.Property<float>("Maxlat")
                        .HasColumnType("real");

                    b.Property<float>("Maxlon")
                        .HasColumnType("real");

                    b.Property<float>("Minlat")
                        .HasColumnType("real");

                    b.Property<float>("Minlon")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("GpxMetadataTypeId")
                        .IsUnique();

                    b.ToTable("Bounds", (string)null);
                });

            modelBuilder.Entity("Memento.Gpx.Domain.GpxMetadataType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:Identity", "1, 1");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AuthorId")
                        .HasColumnType("int");

                    b.Property<string>("Copyright")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Desc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Extensions")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GpxTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Keywords")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Time")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("GpxTypeId")
                        .IsUnique();

                    b.ToTable("MetaData", (string)null);
                });

            modelBuilder.Entity("Memento.Gpx.Domain.GpxType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:Identity", "1, 1");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Creator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Extensions")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Version")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Gpx", (string)null);
                });

            modelBuilder.Entity("Memento.Gpx.Domain.GpxWptType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:Identity", "1, 1");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<float?>("Ageofgpsdata")
                        .HasColumnType("real");

                    b.Property<string>("Cmt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Desc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Dgpsid")
                        .HasColumnType("int");

                    b.Property<float?>("Ele")
                        .HasColumnType("real");

                    b.Property<string>("Extensions")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Fix")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float?>("Geoidheight")
                        .HasColumnType("real");

                    b.Property<int>("GpxTypeId")
                        .HasColumnType("int");

                    b.Property<float?>("Hdop")
                        .HasColumnType("real");

                    b.Property<float>("Lat")
                        .HasColumnType("real");

                    b.Property<float>("Lon")
                        .HasColumnType("real");

                    b.Property<float?>("Magvar")
                        .HasColumnType("real");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float?>("Pdop")
                        .HasColumnType("real");

                    b.Property<byte?>("Sat")
                        .HasColumnType("tinyint");

                    b.Property<string>("Src")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sym")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Time")
                        .HasColumnType("datetime2");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float?>("Vdop")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("GpxTypeId");

                    b.ToTable("WayPoint", (string)null);
                });

            modelBuilder.Entity("Memento.Gpx.Domain.LinkType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:Identity", "1, 1");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Link", (string)null);
                });

            modelBuilder.Entity("Memento.Gpx.Domain.PersonType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:Identity", "1, 1");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("LinkTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LinkTypeId");

                    b.ToTable("Person", (string)null);
                });

            modelBuilder.Entity("GpxMetadataTypeLinkType", b =>
                {
                    b.HasOne("Memento.Gpx.Domain.GpxMetadataType", null)
                        .WithMany()
                        .HasForeignKey("GpxMetadataTypesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Memento.Gpx.Domain.LinkType", null)
                        .WithMany()
                        .HasForeignKey("LinkTypesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GpxWptTypeLinkType", b =>
                {
                    b.HasOne("Memento.Gpx.Domain.GpxWptType", null)
                        .WithMany()
                        .HasForeignKey("GpxWptTypesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Memento.Gpx.Domain.LinkType", null)
                        .WithMany()
                        .HasForeignKey("LinkTypesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Memento.Gpx.Domain.BoundsType", b =>
                {
                    b.HasOne("Memento.Gpx.Domain.GpxMetadataType", "GpxMetadataType")
                        .WithOne("BoundsType")
                        .HasForeignKey("Memento.Gpx.Domain.BoundsType", "GpxMetadataTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GpxMetadataType");
                });

            modelBuilder.Entity("Memento.Gpx.Domain.GpxMetadataType", b =>
                {
                    b.HasOne("Memento.Gpx.Domain.PersonType", "Author")
                        .WithMany("GpxMetadataType")
                        .HasForeignKey("AuthorId");

                    b.HasOne("Memento.Gpx.Domain.GpxType", "GpxType")
                        .WithOne("GpxMetadataType")
                        .HasForeignKey("Memento.Gpx.Domain.GpxMetadataType", "GpxTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("GpxType");
                });

            modelBuilder.Entity("Memento.Gpx.Domain.GpxWptType", b =>
                {
                    b.HasOne("Memento.Gpx.Domain.GpxType", "GpxType")
                        .WithMany("GpxWptTypes")
                        .HasForeignKey("GpxTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GpxType");
                });

            modelBuilder.Entity("Memento.Gpx.Domain.PersonType", b =>
                {
                    b.HasOne("Memento.Gpx.Domain.LinkType", "LinkType")
                        .WithMany("PersonTypes")
                        .HasForeignKey("LinkTypeId");

                    b.Navigation("LinkType");
                });

            modelBuilder.Entity("Memento.Gpx.Domain.GpxMetadataType", b =>
                {
                    b.Navigation("BoundsType");
                });

            modelBuilder.Entity("Memento.Gpx.Domain.GpxType", b =>
                {
                    b.Navigation("GpxMetadataType");

                    b.Navigation("GpxWptTypes");
                });

            modelBuilder.Entity("Memento.Gpx.Domain.LinkType", b =>
                {
                    b.Navigation("PersonTypes");
                });

            modelBuilder.Entity("Memento.Gpx.Domain.PersonType", b =>
                {
                    b.Navigation("GpxMetadataType");
                });
#pragma warning restore 612, 618
        }
    }
}