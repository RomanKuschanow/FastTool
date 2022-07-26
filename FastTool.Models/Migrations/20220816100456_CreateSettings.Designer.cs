﻿// <auto-generated />
using FastTool.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FastTool.Models.Migrations
{
    [DbContext(typeof(DBContext))]
    [Migration("20220816100456_CreateSettings")]
    partial class CreateSettings
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity("FastTool.Models.CalculatorResultsHistory", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("expression");

                    b.Property<float>("result");

                    b.HasKey("id");

                    b.ToTable("calcHistory");
                });

            modelBuilder.Entity("FastTool.Models.Settings", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("inUse");

                    b.Property<string>("name");

                    b.Property<string>("settingsString");

                    b.HasKey("id");

                    b.ToTable("settings");
                });
#pragma warning restore 612, 618
        }
    }
}
