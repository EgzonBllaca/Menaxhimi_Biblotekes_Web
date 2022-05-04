﻿// <auto-generated />
using System;
using Menaxhimi_Biblotekes_Web.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Menaxhimi_Biblotekes_Web.Migrations
{
    [DbContext(typeof(BiblotekaDbContext))]
    [Migration("20220503184309_Kerkesat2")]
    partial class Kerkesat2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.16")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Menaxhimi_Biblotekes.Models.Autori", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CreatedByUserID")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Emri")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("LastUpdatedByUserID")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastUpdatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Mbiemri")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Autori");
                });

            modelBuilder.Entity("Menaxhimi_Biblotekes.Models.Huazimi", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AfatiKthimit")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatedByUserID")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataHuazimit")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataKthimit")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("LastUpdatedByUserID")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastUpdatedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("LibriId")
                        .HasColumnType("int");

                    b.Property<int>("PjesemarresiId")
                        .HasColumnType("int");

                    b.Property<string>("Verejtje")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LibriId");

                    b.HasIndex("PjesemarresiId");

                    b.ToTable("Huazimi");
                });

            modelBuilder.Entity("Menaxhimi_Biblotekes.Models.Pjesemarresi", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CreatedByUserID")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Emri")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Fjalekalimi")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("LastUpdatedByUserID")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastUpdatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Mbiemri")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Perdoruesi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoliId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoliId");

                    b.ToTable("Pjesemarresi");
                });

            modelBuilder.Entity("Menaxhimi_Biblotekes.Models.Roli", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CreatedByUserID")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("LastUpdatedByUserID")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastUpdatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Pershkrimi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roli");
                });

            modelBuilder.Entity("Menaxhimi_Biblotekes_Web.Models.AutoriLibri", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AutoriId")
                        .HasColumnType("int");

                    b.Property<int>("LibriId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AutoriId");

                    b.HasIndex("LibriId");

                    b.ToTable("AutoriLibri");
                });

            modelBuilder.Entity("Menaxhimi_Biblotekes_Web.Models.Kategoria", b =>
                {
                    b.Property<int>("KategoriaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CreatedByUserID")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("LastUpdatedByUserID")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastUpdatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("KategoriaID");

                    b.ToTable("Kategoria");
                });

            modelBuilder.Entity("Menaxhimi_Biblotekes_Web.Models.KerkesatPerHuazim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CreatedByUserID")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataKerkeses")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("LastUpdatedByUserID")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastUpdatedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("LibriId")
                        .HasColumnType("int");

                    b.Property<int>("PjesemarresiId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LibriId");

                    b.HasIndex("PjesemarresiId");

                    b.ToTable("KerkesatPerHuazim");
                });

            modelBuilder.Entity("Menaxhimi_Biblotekes_Web.Models.Libri", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CreatedByUserID")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("ISBN")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("KategoriaId")
                        .HasColumnType("int");

                    b.Property<int>("LastUpdatedByUserID")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastUpdatedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("NrKopjeve")
                        .HasColumnType("int");

                    b.Property<string>("Pershkrimi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShtepiaBotuese")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Titulli")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VitiBotimit")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("KategoriaId");

                    b.ToTable("Libri");
                });

            modelBuilder.Entity("Menaxhimi_Biblotekes.Models.Huazimi", b =>
                {
                    b.HasOne("Menaxhimi_Biblotekes_Web.Models.Libri", "Libri")
                        .WithMany("Huazimi")
                        .HasForeignKey("LibriId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Menaxhimi_Biblotekes.Models.Pjesemarresi", "Pjesemarresi")
                        .WithMany("Huazimi")
                        .HasForeignKey("PjesemarresiId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Libri");

                    b.Navigation("Pjesemarresi");
                });

            modelBuilder.Entity("Menaxhimi_Biblotekes.Models.Pjesemarresi", b =>
                {
                    b.HasOne("Menaxhimi_Biblotekes.Models.Roli", "Roli")
                        .WithMany("Pjesemarresi")
                        .HasForeignKey("RoliId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Roli");
                });

            modelBuilder.Entity("Menaxhimi_Biblotekes_Web.Models.AutoriLibri", b =>
                {
                    b.HasOne("Menaxhimi_Biblotekes.Models.Autori", "Autori")
                        .WithMany("AutoriLibri")
                        .HasForeignKey("AutoriId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Menaxhimi_Biblotekes_Web.Models.Libri", "Libri")
                        .WithMany("AutoriLibri")
                        .HasForeignKey("LibriId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Autori");

                    b.Navigation("Libri");
                });

            modelBuilder.Entity("Menaxhimi_Biblotekes_Web.Models.KerkesatPerHuazim", b =>
                {
                    b.HasOne("Menaxhimi_Biblotekes_Web.Models.Libri", "Libri")
                        .WithMany()
                        .HasForeignKey("LibriId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Menaxhimi_Biblotekes.Models.Pjesemarresi", "Pjesemarresi")
                        .WithMany()
                        .HasForeignKey("PjesemarresiId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Libri");

                    b.Navigation("Pjesemarresi");
                });

            modelBuilder.Entity("Menaxhimi_Biblotekes_Web.Models.Libri", b =>
                {
                    b.HasOne("Menaxhimi_Biblotekes_Web.Models.Kategoria", "Kategoria")
                        .WithMany("Librat")
                        .HasForeignKey("KategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Kategoria");
                });

            modelBuilder.Entity("Menaxhimi_Biblotekes.Models.Autori", b =>
                {
                    b.Navigation("AutoriLibri");
                });

            modelBuilder.Entity("Menaxhimi_Biblotekes.Models.Pjesemarresi", b =>
                {
                    b.Navigation("Huazimi");
                });

            modelBuilder.Entity("Menaxhimi_Biblotekes.Models.Roli", b =>
                {
                    b.Navigation("Pjesemarresi");
                });

            modelBuilder.Entity("Menaxhimi_Biblotekes_Web.Models.Kategoria", b =>
                {
                    b.Navigation("Librat");
                });

            modelBuilder.Entity("Menaxhimi_Biblotekes_Web.Models.Libri", b =>
                {
                    b.Navigation("AutoriLibri");

                    b.Navigation("Huazimi");
                });
#pragma warning restore 612, 618
        }
    }
}
