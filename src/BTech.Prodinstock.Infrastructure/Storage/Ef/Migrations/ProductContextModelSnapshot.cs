﻿// <auto-generated />
using System;
using BTech.Prodinstock.Infrastructure.Storage.Ef;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BTech.Prodinstock.Infrastructure.Migrations
{
    [DbContext(typeof(ProductContext))]
    partial class ProductContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("product")
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BTech.Prodinstock.Products.Domain.Entities.AccountingAccount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<short>("Number")
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.ToTable("AccountingAccount", "product");
                });

            modelBuilder.Entity("BTech.Prodinstock.Products.Domain.Entities.Category", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Category", "product");
                });

            modelBuilder.Entity("BTech.Prodinstock.Products.Domain.Entities.Invoice", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("BuyerFullName")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Number")
                        .HasColumnType("text");

                    b.Property<int>("State")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Invoice", "product");
                });

            modelBuilder.Entity("BTech.Prodinstock.Products.Domain.Entities.InvoiceStateHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("InvoiceId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("OperationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("State")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("InvoiceId");

                    b.ToTable("InvoiceStateHistory", "product");
                });

            modelBuilder.Entity("BTech.Prodinstock.Products.Domain.Entities.OrderProduct", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("InvoiceId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<string>("ProductId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("InvoiceId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderProduct", "product");
                });

            modelBuilder.Entity("BTech.Prodinstock.Products.Domain.Entities.Product", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int?>("AccountingAccountId")
                        .HasColumnType("integer");

                    b.Property<decimal>("BuyingPrice")
                        .HasColumnType("numeric");

                    b.Property<string>("CategoryId")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<short>("NumberInStock")
                        .HasColumnType("smallint");

                    b.Property<decimal>("SalePrice")
                        .HasColumnType("numeric");

                    b.Property<string>("SupplierId")
                        .HasColumnType("text");

                    b.Property<decimal>("VATRate")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("AccountingAccountId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("SupplierId");

                    b.ToTable("Products", "product");
                });

            modelBuilder.Entity("BTech.Prodinstock.Products.Domain.Entities.Supplier", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Supplier", "product");
                });

            modelBuilder.Entity("BTech.Prodinstock.Products.Domain.Entities.Invoice", b =>
                {
                    b.OwnsOne("BTech.Prodinstock.Products.Domain.PostalAddress", "BuyerPostalAddress", b1 =>
                        {
                            b1.Property<string>("InvoiceId")
                                .HasColumnType("text");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<string>("PostalCode")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<string>("Street")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.HasKey("InvoiceId");

                            b1.ToTable("Invoice", "product");

                            b1.WithOwner()
                                .HasForeignKey("InvoiceId");
                        });

                    b.Navigation("BuyerPostalAddress");
                });

            modelBuilder.Entity("BTech.Prodinstock.Products.Domain.Entities.InvoiceStateHistory", b =>
                {
                    b.HasOne("BTech.Prodinstock.Products.Domain.Entities.Invoice", null)
                        .WithMany("InvoiceStateHistories")
                        .HasForeignKey("InvoiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BTech.Prodinstock.Products.Domain.Entities.OrderProduct", b =>
                {
                    b.HasOne("BTech.Prodinstock.Products.Domain.Entities.Invoice", null)
                        .WithMany("OrderProducts")
                        .HasForeignKey("InvoiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BTech.Prodinstock.Products.Domain.Entities.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BTech.Prodinstock.Products.Domain.Entities.Product", b =>
                {
                    b.HasOne("BTech.Prodinstock.Products.Domain.Entities.AccountingAccount", null)
                        .WithMany()
                        .HasForeignKey("AccountingAccountId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("BTech.Prodinstock.Products.Domain.Entities.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("BTech.Prodinstock.Products.Domain.Entities.Supplier", "Supplier")
                        .WithMany("Products")
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Category");

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("BTech.Prodinstock.Products.Domain.Entities.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("BTech.Prodinstock.Products.Domain.Entities.Invoice", b =>
                {
                    b.Navigation("InvoiceStateHistories");

                    b.Navigation("OrderProducts");
                });

            modelBuilder.Entity("BTech.Prodinstock.Products.Domain.Entities.Supplier", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
