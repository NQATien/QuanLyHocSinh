﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QuanLyHocSinh.Models;

#nullable disable

namespace QuanLyHocSinh.Migrations
{
    [DbContext(typeof(StudentDbContext))]
    [Migration("20230727045825_initcr")]
    partial class initcr
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("QuanLyHocSinh.Models.BoMon", b =>
                {
                    b.Property<int>("BoMonID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BoMonID"));

                    b.Property<string>("BoMonName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BoMonID");

                    b.ToTable("BoMons");
                });

            modelBuilder.Entity("QuanLyHocSinh.Models.Diem", b =>
                {
                    b.Property<int>("DiemID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DiemID"));

                    b.Property<string>("DiemName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HocSinhName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MonName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DiemID");

                    b.ToTable("Diems");
                });

            modelBuilder.Entity("QuanLyHocSinh.Models.GiaoVien", b =>
                {
                    b.Property<int>("GiaoVienID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GiaoVienID"));

                    b.Property<string>("GiaoVienName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GioiTinh")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LopID")
                        .HasColumnType("int");

                    b.Property<string>("LopName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GiaoVienID");

                    b.HasIndex("LopID");

                    b.ToTable("GiaoViens");
                });

            modelBuilder.Entity("QuanLyHocSinh.Models.HocKy", b =>
                {
                    b.Property<int>("HocKyID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HocKyID"));

                    b.Property<string>("HocKyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NamHocID")
                        .HasColumnType("int");

                    b.Property<string>("NamHocName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("HocKyID");

                    b.HasIndex("NamHocID");

                    b.ToTable("HocKys");
                });

            modelBuilder.Entity("QuanLyHocSinh.Models.HocSinh", b =>
                {
                    b.Property<int>("HocSinhID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HocSinhID"));

                    b.Property<string>("GioiTinh")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HocSinhName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LopID")
                        .HasColumnType("int");

                    b.Property<string>("LopName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("HocSinhID");

                    b.HasIndex("LopID");

                    b.ToTable("HocSinhs");
                });

            modelBuilder.Entity("QuanLyHocSinh.Models.Khoi", b =>
                {
                    b.Property<int>("KhoiID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("KhoiID"));

                    b.Property<string>("KhoiName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SoLuongHS")
                        .HasColumnType("int");

                    b.HasKey("KhoiID");

                    b.ToTable("Khois");
                });

            modelBuilder.Entity("QuanLyHocSinh.Models.Lop", b =>
                {
                    b.Property<int>("LopID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LopID"));

                    b.Property<int>("KhoiID")
                        .HasColumnType("int");

                    b.Property<string>("KhoiName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LopName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SiSo")
                        .HasColumnType("int");

                    b.HasKey("LopID");

                    b.HasIndex("KhoiID");

                    b.ToTable("Lops");
                });

            modelBuilder.Entity("QuanLyHocSinh.Models.Mon", b =>
                {
                    b.Property<int>("MonID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MonID"));

                    b.Property<int>("BoMonID")
                        .HasColumnType("int");

                    b.Property<string>("BoMonName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GiaoVienID")
                        .HasColumnType("int");

                    b.Property<string>("GiaoVienName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MonName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MonID");

                    b.HasIndex("BoMonID");

                    b.HasIndex("GiaoVienID");

                    b.ToTable("Mons");
                });

            modelBuilder.Entity("QuanLyHocSinh.Models.NamHoc", b =>
                {
                    b.Property<int>("NamHocID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NamHocID"));

                    b.Property<string>("NamHocName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("NamHocID");

                    b.ToTable("NamHocs");
                });

            modelBuilder.Entity("QuanLyHocSinh.Models.GiaoVien", b =>
                {
                    b.HasOne("QuanLyHocSinh.Models.Lop", "Lop")
                        .WithMany()
                        .HasForeignKey("LopID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lop");
                });

            modelBuilder.Entity("QuanLyHocSinh.Models.HocKy", b =>
                {
                    b.HasOne("QuanLyHocSinh.Models.NamHoc", "NamHoc")
                        .WithMany()
                        .HasForeignKey("NamHocID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("NamHoc");
                });

            modelBuilder.Entity("QuanLyHocSinh.Models.HocSinh", b =>
                {
                    b.HasOne("QuanLyHocSinh.Models.Lop", "Lop")
                        .WithMany()
                        .HasForeignKey("LopID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lop");
                });

            modelBuilder.Entity("QuanLyHocSinh.Models.Lop", b =>
                {
                    b.HasOne("QuanLyHocSinh.Models.Khoi", "Khoi")
                        .WithMany()
                        .HasForeignKey("KhoiID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Khoi");
                });

            modelBuilder.Entity("QuanLyHocSinh.Models.Mon", b =>
                {
                    b.HasOne("QuanLyHocSinh.Models.BoMon", "BoMon")
                        .WithMany()
                        .HasForeignKey("BoMonID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QuanLyHocSinh.Models.GiaoVien", "GiaoVien")
                        .WithMany()
                        .HasForeignKey("GiaoVienID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BoMon");

                    b.Navigation("GiaoVien");
                });
#pragma warning restore 612, 618
        }
    }
}
