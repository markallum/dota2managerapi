﻿// <auto-generated />
using Dota2ManagerAPI.Web.DAL;
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
    [Migration("20180605133149_TeamTables")]
    partial class TeamTables
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

                    b.Property<int>("Awareness");

                    b.Property<int>("Efficiency");

                    b.Property<int>("HeroID");

                    b.Property<string>("Name");

                    b.Property<int>("Poise");

                    b.Property<int>("Positioning");

                    b.Property<int>("Speed");

                    b.Property<string>("Type");

                    b.Property<bool>("isMelee");

                    b.HasKey("id");

                    b.ToTable("Heroes");
                });

            modelBuilder.Entity("Dota2ManagerAPI.Models.Player", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Age");

                    b.Property<int>("Awareness");

                    b.Property<DateTime>("Birthday");

                    b.Property<int>("Efficiency");

                    b.Property<bool>("HasTeam");

                    b.Property<string>("Name");

                    b.Property<int>("Poise");

                    b.Property<int>("Positioning");

                    b.Property<int>("Speed");

                    b.Property<int>("TeamID");

                    b.HasKey("id");

                    b.HasIndex("TeamID");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("Dota2ManagerAPI.Models.Team", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("id");

                    b.ToTable("Teams");
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

            modelBuilder.Entity("Dota2ManagerAPI.Models.Player", b =>
                {
                    b.HasOne("Dota2ManagerAPI.Models.Team")
                        .WithMany("Players")
                        .HasForeignKey("TeamID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
