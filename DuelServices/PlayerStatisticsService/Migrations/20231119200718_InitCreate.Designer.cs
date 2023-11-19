﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PlayerStatisticsService.Configurations;

#nullable disable

namespace PlayerStatisticsService.Migrations
{
    [DbContext(typeof(PlayerStatisticDbContext))]
    [Migration("20231119200718_InitCreate")]
    partial class InitCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("PlayerStatisticsService.Entities.PlayerStatistic", b =>
                {
                    b.Property<int>("PlayerId")
                        .HasColumnType("int");

                    b.Property<int?>("AverageDuelDuration")
                        .HasColumnType("int")
                        .HasColumnName("AverageDuelDuration");

                    b.Property<DateTime?>("LastDuelPlayedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("LastDuelPlayedAt");

                    b.Property<int>("NumberOfDuelsDraw")
                        .HasColumnType("int")
                        .HasColumnName("NumberOfDuelsDraw");

                    b.Property<int>("NumberOfDuelsLost")
                        .HasColumnType("int")
                        .HasColumnName("NumberOfDuelsLost");

                    b.Property<int>("NumberOfDuelsPlayed")
                        .HasColumnType("int")
                        .HasColumnName("NumberOfDuelsPlayed");

                    b.Property<int>("NumberOfDuelsWon")
                        .HasColumnType("int")
                        .HasColumnName("NumberOfDuelsWon");

                    b.HasKey("PlayerId");

                    b.ToTable("PlayerStatistics");
                });

            modelBuilder.Entity("RegistrationService.Entities.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    b.Property<decimal>("EloRating")
                        .HasColumnType("decimal(65,30)")
                        .HasColumnName("EloRating");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.ToTable("Player");
                });

            modelBuilder.Entity("PlayerStatisticsService.Entities.PlayerStatistic", b =>
                {
                    b.HasOne("RegistrationService.Entities.Player", "Player")
                        .WithOne()
                        .HasForeignKey("PlayerStatisticsService.Entities.PlayerStatistic", "PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Player");
                });
#pragma warning restore 612, 618
        }
    }
}
