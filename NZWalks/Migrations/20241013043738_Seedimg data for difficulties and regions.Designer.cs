﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NZWalks.Data;

#nullable disable

namespace NZWalks.Migrations
{
    [DbContext(typeof(NZWalksDbContext))]
    [Migration("20241013043738_Seedimg data for difficulties and regions")]
    partial class Seedimgdatafordifficultiesandregions
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("NZWalks.Models.Domain.Difficulty", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Difficulties");

                    b.HasData(
                        new
                        {
                            Id = new Guid("f5b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3b"),
                            Name = "Easy"
                        },
                        new
                        {
                            Id = new Guid("f5b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3c"),
                            Name = "Moderate"
                        },
                        new
                        {
                            Id = new Guid("f5b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3d"),
                            Name = "Hard"
                        });
                });

            modelBuilder.Entity("NZWalks.Models.Domain.Region", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RegionImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Regions");

                    b.HasData(
                        new
                        {
                            Id = new Guid("f5b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3e"),
                            Code = "N",
                            Name = "Northland",
                            RegionImageUrl = "northland.jpg"
                        },
                        new
                        {
                            Id = new Guid("f5b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3f"),
                            Code = "A",
                            Name = "Auckland",
                            RegionImageUrl = "auckland.jpg"
                        },
                        new
                        {
                            Id = new Guid("f5b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b30"),
                            Code = "W",
                            Name = "Waikato",
                            RegionImageUrl = "waikato.jpg"
                        },
                        new
                        {
                            Id = new Guid("f5b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b31"),
                            Code = "B",
                            Name = "Bay of Plenty",
                            RegionImageUrl = "bayofplenty.jpg"
                        },
                        new
                        {
                            Id = new Guid("f5b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b32"),
                            Code = "T",
                            Name = "Taranaki",
                            RegionImageUrl = "taranaki.jpg"
                        });
                });

            modelBuilder.Entity("NZWalks.Models.Domain.Walk", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("DifficultyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("LengthInKm")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RegionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("WalkImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DifficultyId");

                    b.HasIndex("RegionId");

                    b.ToTable("Walks");
                });

            modelBuilder.Entity("NZWalks.Models.Domain.Walk", b =>
                {
                    b.HasOne("NZWalks.Models.Domain.Difficulty", "Difficulty")
                        .WithMany()
                        .HasForeignKey("DifficultyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NZWalks.Models.Domain.Region", "Region")
                        .WithMany()
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Difficulty");

                    b.Navigation("Region");
                });
#pragma warning restore 612, 618
        }
    }
}
