﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using opapProject.Data;
using System;

namespace opapProject.Data.Migrations
{
    [DbContext(typeof(OpapDbContext))]
    partial class OpapDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("opapProject.Models.Draw", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DrawDate");

                    b.Property<int>("DrawNumber");

                    b.Property<bool>("Jackpot");

                    b.Property<int>("Joker");

                    b.Property<int>("Number1");

                    b.Property<int>("Number2");

                    b.Property<int>("Number3");

                    b.Property<int>("Number4");

                    b.Property<int>("Number5");

                    b.HasKey("Id");

                    b.ToTable("Draw");
                });
#pragma warning restore 612, 618
        }
    }
}
