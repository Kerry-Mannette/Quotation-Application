﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QuotationApplication.Data;

#nullable disable

namespace QuotationApplication.Migrations.Quotation
{
    [DbContext(typeof(QuotationContext))]
    partial class QuotationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.0");

            modelBuilder.Entity("QuotationApplication.Models.Quotation", b =>
                {
                    b.Property<int>("QuotationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Amount")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ExpireON")
                        .HasColumnType("TEXT");

                    b.Property<string>("Price")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Quantity")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Service")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Tax")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("QuotationId");

                    b.ToTable("Quotation");
                });
#pragma warning restore 612, 618
        }
    }
}
