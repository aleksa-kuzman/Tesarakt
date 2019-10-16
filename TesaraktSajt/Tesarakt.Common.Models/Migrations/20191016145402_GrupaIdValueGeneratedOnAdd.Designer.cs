﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Tesarakt.Common.Models.Domain;

namespace Tesarakt.Common.Models.Migrations
{
    [DbContext(typeof(TesaraktContext))]
    [Migration("20191016145402_GrupaIdValueGeneratedOnAdd")]
    partial class GrupaIdValueGeneratedOnAdd
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Tesarakt.Common.Models.Domain.GrupaProizvoda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("GrupaId");

                    b.Property<bool>("Active");

                    b.Property<int>("ModifiedByUserId");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<string>("NazivGrupe")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("GrupaProizvoda");
                });

            modelBuilder.Entity("Tesarakt.Common.Models.Domain.Proizvod", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ProizvodId");

                    b.Property<bool>("Active");

                    b.Property<double?>("CenaProizvoda");

                    b.Property<int?>("GrupaId");

                    b.Property<int>("ModifiedByUserId");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<string>("NazivProizvoda")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Proizvod");
                });
#pragma warning restore 612, 618
        }
    }
}
