﻿// <auto-generated />
using Dota2ManagerAPI.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace Dota2ManagerAPI.Migrations
{
    [DbContext(typeof(DbService))]
    [Migration("20180604072557_WinRatesVersus-Table")]
    partial class WinRatesVersusTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Dota2ManagerAPI.Models.Hero", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("HeroID");

                    b.Property<string>("Name");

                    b.Property<string>("Type");

                    b.Property<string>("isMelee");

                    b.HasKey("id");

                    b.ToTable("Heroes");
                });

            modelBuilder.Entity("Dota2ManagerAPI.Models.WinRatesVersus", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BaseHeroID");

                    b.Property<double>("Disadvantage");

                    b.Property<int>("TargetHeroID");

                    b.HasKey("id");

                    b.ToTable("WinRatesVersus");
                });
#pragma warning restore 612, 618
        }
    }
}
