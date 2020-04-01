﻿// <auto-generated />
using System;
using Memory.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Memory.Migrations
{
    [DbContext(typeof(MemoryContext))]
    [Migration("20200401131911_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Memory.Models.Carte", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FindBy");

                    b.Property<string>("Image");

                    b.Property<int>("PartieId");

                    b.Property<int>("Position");

                    b.HasKey("ID");

                    b.ToTable("Carte");
                });

            modelBuilder.Entity("Memory.Models.Partie", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateAt");

                    b.Property<int>("NumberCards");

                    b.Property<string>("StateGame");

                    b.Property<string>("TournToPlay");

                    b.HasKey("ID");

                    b.ToTable("Partie");
                });

            modelBuilder.Entity("Memory.Models.ScorePartie", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PartieId");

                    b.Property<string>("Player1");

                    b.Property<string>("Player2");

                    b.Property<int>("ScorePlayer1");

                    b.Property<int>("ScorePlayer2");

                    b.Property<string>("Winner");

                    b.HasKey("ID");

                    b.ToTable("ScorePartie");
                });
#pragma warning restore 612, 618
        }
    }
}