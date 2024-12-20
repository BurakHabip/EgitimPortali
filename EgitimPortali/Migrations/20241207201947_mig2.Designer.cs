﻿// <auto-generated />
using EgitimPortali.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EgitimPortali.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241207201947_mig2")]
    partial class mig2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EgitimPortali.Models.Education", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("LessonId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LessonId");

                    b.ToTable("Educations");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Eğitim",
                            IsActive = true,
                            LessonId = 0,
                            Name = "Eğitim1"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Eğitim açıklama",
                            IsActive = true,
                            LessonId = 0,
                            Name = "Eğitim2"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Eğitim açıklama",
                            IsActive = false,
                            LessonId = 0,
                            Name = "Eğitim3"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Eğitim açıklama",
                            IsActive = false,
                            LessonId = 0,
                            Name = "Eğitim4"
                        },
                        new
                        {
                            Id = 5,
                            Description = "Eğitim açıklama",
                            IsActive = false,
                            LessonId = 0,
                            Name = "Eğitim5"
                        });
                });

            modelBuilder.Entity("EgitimPortali.Models.Lesson", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Lessons");
                });

            modelBuilder.Entity("EgitimPortali.Models.Education", b =>
                {
                    b.HasOne("EgitimPortali.Models.Lesson", "Lesson")
                        .WithMany()
                        .HasForeignKey("LessonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lesson");
                });
#pragma warning restore 612, 618
        }
    }
}
