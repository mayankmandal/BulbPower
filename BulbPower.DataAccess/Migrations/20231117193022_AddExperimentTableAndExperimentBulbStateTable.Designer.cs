﻿// <auto-generated />
using System;
using BulbPower.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BulbPower.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231117193022_AddExperimentTableAndExperimentBulbStateTable")]
    partial class AddExperimentTableAndExperimentBulbStateTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BulbPower.Models.Experiment", b =>
                {
                    b.Property<int>("ExperimentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ExperimentId"));

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("ExperimentName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ExperimentStatus")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastExitedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("LastExitedPersonNumber")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfBulbs")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfPeople")
                        .HasColumnType("int");

                    b.HasKey("ExperimentId");

                    b.ToTable("Experiments");
                });

            modelBuilder.Entity("BulbPower.Models.ExperimentBulbState", b =>
                {
                    b.Property<int>("ExperimentBulbStateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ExperimentBulbStateId"));

                    b.Property<int>("BulbNumber")
                        .HasColumnType("int");

                    b.Property<bool>("BulbState")
                        .HasColumnType("bit");

                    b.Property<int>("ExperimentId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ToggledOnDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("ExperimentBulbStateId");

                    b.HasIndex("ExperimentId");

                    b.ToTable("ExperimentBulbStates");
                });

            modelBuilder.Entity("BulbPower.Models.ExperimentBulbState", b =>
                {
                    b.HasOne("BulbPower.Models.Experiment", "Experiments")
                        .WithMany()
                        .HasForeignKey("ExperimentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Experiments");
                });
#pragma warning restore 612, 618
        }
    }
}
