﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Proje.DataAcces;

#nullable disable

namespace Proje.DataAcces.Migrations
{
    [DbContext(typeof(ProjeDbContext))]
    [Migration("20230109105253_User")]
    partial class User
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Proje.Entities.Hammadde", b =>
                {
                    b.Property<int>("HamId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("HamId"));

                    b.Property<int>("HamAdet")
                        .HasColumnType("integer");

                    b.Property<string>("HamAdi")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("HamId");

                    b.ToTable("Hammadde");
                });

            modelBuilder.Entity("Proje.Entities.Stok", b =>
                {
                    b.Property<int>("StokId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("StokId"));

                    b.Property<int>("HamId")
                        .HasColumnType("integer");

                    b.Property<int>("StokSayi")
                        .HasColumnType("integer");

                    b.Property<int>("UrunId")
                        .HasColumnType("integer");

                    b.HasKey("StokId");

                    b.HasIndex("HamId");

                    b.HasIndex("UrunId");

                    b.ToTable("Stok");
                });

            modelBuilder.Entity("Proje.Entities.Urun", b =>
                {
                    b.Property<int>("UrunId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("UrunId"));

                    b.Property<int>("UrunAdet")
                        .HasColumnType("integer");

                    b.Property<string>("UrunAdi")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("UrunId");

                    b.ToTable("Urun");
                });

            modelBuilder.Entity("Proje.Entities.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("UserId"));

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("UserId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Proje.Entities.Stok", b =>
                {
                    b.HasOne("Proje.Entities.Hammadde", "Hammadde")
                        .WithMany()
                        .HasForeignKey("HamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Proje.Entities.Urun", "Urun")
                        .WithMany()
                        .HasForeignKey("UrunId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hammadde");

                    b.Navigation("Urun");
                });
#pragma warning restore 612, 618
        }
    }
}