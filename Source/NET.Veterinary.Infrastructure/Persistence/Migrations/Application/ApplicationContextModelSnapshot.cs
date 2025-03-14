﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NET.Veterinary.Infrastructure.Persistence.Context;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace NET.Veterinary.Infrastructure.Persistence.Migrations.Application
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("NET.Veterinary.Domain.AggregateRoots.Appointment.Appointment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id")
                        .HasColumnOrder(0);

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<int>("Id"));

                    b.Property<bool>("DidAssist")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("BOOLEAN")
                        .HasDefaultValue(false)
                        .HasColumnName("did_assist")
                        .HasColumnOrder(4);

                    b.HasKey("Id");

                    b.ToTable("Appointments", (string)null);
                });

            modelBuilder.Entity("NET.Veterinary.Domain.AggregateRoots.Appointment.Appointment", b =>
                {
                    b.OwnsOne("NET.Veterinary.Domain.ObjectValues.CompleteName", "CompleteName", b1 =>
                        {
                            b1.Property<int>("AppointmentId")
                                .HasColumnType("INTEGER");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(255)
                                .HasColumnType("VARCHAR")
                                .HasColumnName("patient_name")
                                .HasColumnOrder(3);

                            b1.HasKey("AppointmentId");

                            b1.ToTable("Appointments");

                            b1.WithOwner()
                                .HasForeignKey("AppointmentId");
                        });

                    b.OwnsOne("NET.Veterinary.Domain.ObjectValues.Identification", "Identification", b1 =>
                        {
                            b1.Property<int>("AppointmentId")
                                .HasColumnType("INTEGER");

                            b1.Property<int>("Value")
                                .HasColumnType("INTEGER")
                                .HasColumnName("identification")
                                .HasColumnOrder(2);

                            b1.HasKey("AppointmentId");

                            b1.ToTable("Appointments");

                            b1.WithOwner()
                                .HasForeignKey("AppointmentId");
                        });

                    b.OwnsOne("NET.Veterinary.Domain.ObjectValues.TimestampNoTimeZone", "DateSelect", b1 =>
                        {
                            b1.Property<int>("AppointmentId")
                                .HasColumnType("INTEGER");

                            b1.Property<DateTime>("Value")
                                .HasColumnType("TIMESTAMP WITHOUT TIME ZONE")
                                .HasColumnName("date_selected")
                                .HasColumnOrder(1);

                            b1.HasKey("AppointmentId");

                            b1.ToTable("Appointments");

                            b1.WithOwner()
                                .HasForeignKey("AppointmentId");
                        });

                    b.Navigation("CompleteName")
                        .IsRequired();

                    b.Navigation("DateSelect")
                        .IsRequired();

                    b.Navigation("Identification")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
