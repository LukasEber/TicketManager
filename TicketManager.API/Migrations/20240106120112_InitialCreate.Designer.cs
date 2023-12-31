﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TicketManager.API.Persistence;

#nullable disable

namespace TicketManager.API.Migrations
{
    [DbContext(typeof(TicketManagerDbContext))]
    [Migration("20240106120112_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TicketManager.Domain.Models.Customer", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Applications")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("DeveloperID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("DeveloperID");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("TicketManager.Domain.Models.Developer", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Applications")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Developers");
                });

            modelBuilder.Entity("TicketManager.Domain.Models.Ticket", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Application")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Attachments")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("CustomerID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("DeveloperID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("CustomerID");

                    b.HasIndex("DeveloperID");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("TicketManager.Domain.Models.Customer", b =>
                {
                    b.HasOne("TicketManager.Domain.Models.Developer", null)
                        .WithMany("AssignedCustomers")
                        .HasForeignKey("DeveloperID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("TicketManager.Domain.Models.Credentials", "Credentials", b1 =>
                        {
                            b1.Property<Guid>("CustomerID")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("MailAddress")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Password")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("CustomerID");

                            b1.ToTable("Customers");

                            b1.WithOwner()
                                .HasForeignKey("CustomerID");
                        });

                    b.Navigation("Credentials")
                        .IsRequired();
                });

            modelBuilder.Entity("TicketManager.Domain.Models.Developer", b =>
                {
                    b.OwnsOne("TicketManager.Domain.Models.Credentials", "Credentials", b1 =>
                        {
                            b1.Property<Guid>("DeveloperID")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("MailAddress")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Password")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("DeveloperID");

                            b1.ToTable("Developers");

                            b1.WithOwner()
                                .HasForeignKey("DeveloperID");
                        });

                    b.Navigation("Credentials")
                        .IsRequired();
                });

            modelBuilder.Entity("TicketManager.Domain.Models.Ticket", b =>
                {
                    b.HasOne("TicketManager.Domain.Models.Customer", null)
                        .WithMany("Tickets")
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TicketManager.Domain.Models.Developer", null)
                        .WithMany("Tickets")
                        .HasForeignKey("DeveloperID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TicketManager.Domain.Models.Customer", b =>
                {
                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("TicketManager.Domain.Models.Developer", b =>
                {
                    b.Navigation("AssignedCustomers");

                    b.Navigation("Tickets");
                });
#pragma warning restore 612, 618
        }
    }
}
