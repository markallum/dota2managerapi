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
    [Migration("20180602163738_initial")]
    partial class initial
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

                    b.Property<string>("attack_type");

                    b.Property<string>("localized_name");

                    b.Property<string>("primary_attr");

                    b.HasKey("id");

                    b.ToTable("Heroes");
                });
#pragma warning restore 612, 618
        }
    }
}
