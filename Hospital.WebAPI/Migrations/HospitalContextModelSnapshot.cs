﻿// <auto-generated />
using System;
using Hospital.WebAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Hospital.WebAPI.Migrations
{
    [DbContext(typeof(HospitalContext))]
    partial class HospitalContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Hospital.Shared.Area", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AreaNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Areas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AreaNumber = 13
                        },
                        new
                        {
                            Id = 2,
                            AreaNumber = 4
                        },
                        new
                        {
                            Id = 3,
                            AreaNumber = 46
                        },
                        new
                        {
                            Id = 4,
                            AreaNumber = 8
                        });
                });

            modelBuilder.Entity("Hospital.Shared.Cabinet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CabNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Cabinets");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CabNumber = 4
                        },
                        new
                        {
                            Id = 2,
                            CabNumber = 7
                        },
                        new
                        {
                            Id = 3,
                            CabNumber = 12
                        },
                        new
                        {
                            Id = 4,
                            CabNumber = 6
                        },
                        new
                        {
                            Id = 5,
                            CabNumber = 8
                        },
                        new
                        {
                            Id = 6,
                            CabNumber = 10
                        });
                });

            modelBuilder.Entity("Hospital.Shared.Doctor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("AreaId")
                        .HasColumnType("int");

                    b.Property<int>("CabinetId")
                        .HasColumnType("int");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SpecializationId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AreaId");

                    b.HasIndex("CabinetId");

                    b.HasIndex("SpecializationId");

                    b.ToTable("Doctors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CabinetId = 2,
                            FullName = "Попов Даниил Викторович",
                            SpecializationId = 3
                        },
                        new
                        {
                            Id = 2,
                            CabinetId = 3,
                            FullName = "Соколов Виктор Петрович",
                            SpecializationId = 2
                        },
                        new
                        {
                            Id = 3,
                            AreaId = 2,
                            CabinetId = 1,
                            FullName = "Михайлов Игорь Львович",
                            SpecializationId = 1
                        },
                        new
                        {
                            Id = 4,
                            CabinetId = 6,
                            FullName = "Федоров Богдан Антонович",
                            SpecializationId = 4
                        });
                });

            modelBuilder.Entity("Hospital.Shared.Patient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("AreaId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("date");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sex")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AreaId");

                    b.ToTable("Patients");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "улица Степная, дом 130",
                            AreaId = 4,
                            Birthday = new DateTime(1980, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Денис",
                            MiddleName = "Евгеньевич",
                            Sex = "М",
                            Surname = "Петров"
                        },
                        new
                        {
                            Id = 2,
                            Address = "улица Калинина, дом 6",
                            AreaId = 2,
                            Birthday = new DateTime(1994, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Олег",
                            MiddleName = "Сергеевич",
                            Sex = "М",
                            Surname = "Иванов"
                        },
                        new
                        {
                            Id = 3,
                            Address = "улица Гоголя, дом 12, квартира 8",
                            AreaId = 2,
                            Birthday = new DateTime(2000, 2, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Сергей",
                            MiddleName = "Иванович",
                            Sex = "М",
                            Surname = "Смирнов"
                        },
                        new
                        {
                            Id = 4,
                            Address = "улица Красная, дом 5",
                            AreaId = 3,
                            Birthday = new DateTime(1988, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Анастасия",
                            MiddleName = "Николаевна",
                            Sex = "м",
                            Surname = "Жукова"
                        },
                        new
                        {
                            Id = 5,
                            Address = "улица Мира, дом 64",
                            AreaId = 1,
                            Birthday = new DateTime(2007, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Алексей",
                            MiddleName = "Сергеевич",
                            Sex = "ж",
                            Surname = "Ульянов"
                        });
                });

            modelBuilder.Entity("Hospital.Shared.Specialization", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("SpecName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Specializations");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            SpecName = "Педиатрия"
                        },
                        new
                        {
                            Id = 2,
                            SpecName = "Хирургия"
                        },
                        new
                        {
                            Id = 3,
                            SpecName = "Флебология"
                        },
                        new
                        {
                            Id = 4,
                            SpecName = "Колопроктология"
                        });
                });

            modelBuilder.Entity("Hospital.Shared.Doctor", b =>
                {
                    b.HasOne("Hospital.Shared.Area", "Area")
                        .WithMany()
                        .HasForeignKey("AreaId");

                    b.HasOne("Hospital.Shared.Cabinet", "Cabinet")
                        .WithMany()
                        .HasForeignKey("CabinetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Hospital.Shared.Specialization", "Specialization")
                        .WithMany()
                        .HasForeignKey("SpecializationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Area");

                    b.Navigation("Cabinet");

                    b.Navigation("Specialization");
                });

            modelBuilder.Entity("Hospital.Shared.Patient", b =>
                {
                    b.HasOne("Hospital.Shared.Area", "Area")
                        .WithMany()
                        .HasForeignKey("AreaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Area");
                });
#pragma warning restore 612, 618
        }
    }
}
