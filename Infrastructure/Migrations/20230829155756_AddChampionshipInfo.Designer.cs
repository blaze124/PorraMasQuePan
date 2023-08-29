﻿// <auto-generated />
using System;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230829155756_AddChampionshipInfo")]
    partial class AddChampionshipInfo
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ChampionshipContestant", b =>
                {
                    b.Property<int>("ChampionshipsChampionshipId")
                        .HasColumnType("int");

                    b.Property<Guid>("ContestantsContestantId")
                        .HasColumnType("char(36)");

                    b.HasKey("ChampionshipsChampionshipId", "ContestantsContestantId");

                    b.HasIndex("ContestantsContestantId");

                    b.ToTable("ChampionshipContestant");
                });

            modelBuilder.Entity("Domain.Entities.Championship", b =>
                {
                    b.Property<int>("ChampionshipId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("ChampionshipId");

                    b.ToTable("Championship");
                });

            modelBuilder.Entity("Domain.Entities.Contestant", b =>
                {
                    b.Property<Guid>("ContestantId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("ContestantId");

                    b.ToTable("Contestants");
                });

            modelBuilder.Entity("Domain.Entities.Match", b =>
                {
                    b.Property<int>("MatchId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ChampionshipId")
                        .HasColumnType("int");

                    b.Property<string>("LocalTeam")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Result")
                        .HasColumnType("int");

                    b.Property<string>("VisitorTeam")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("MatchId");

                    b.HasIndex("ChampionshipId");

                    b.ToTable("Matches");
                });

            modelBuilder.Entity("Domain.Entities.Result", b =>
                {
                    b.Property<int>("ResultId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<Guid>("ContestantId")
                        .HasColumnType("char(36)");

                    b.Property<int>("FinalResult")
                        .HasColumnType("int");

                    b.Property<int>("MatchId")
                        .HasColumnType("int");

                    b.HasKey("ResultId");

                    b.HasIndex("ContestantId");

                    b.HasIndex("MatchId");

                    b.ToTable("Results");
                });

            modelBuilder.Entity("ChampionshipContestant", b =>
                {
                    b.HasOne("Domain.Entities.Championship", null)
                        .WithMany()
                        .HasForeignKey("ChampionshipsChampionshipId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Contestant", null)
                        .WithMany()
                        .HasForeignKey("ContestantsContestantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.Match", b =>
                {
                    b.HasOne("Domain.Entities.Championship", "Championship")
                        .WithMany("Matches")
                        .HasForeignKey("ChampionshipId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Championship");
                });

            modelBuilder.Entity("Domain.Entities.Result", b =>
                {
                    b.HasOne("Domain.Entities.Contestant", "Contestant")
                        .WithMany()
                        .HasForeignKey("ContestantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Match", "Match")
                        .WithMany()
                        .HasForeignKey("MatchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contestant");

                    b.Navigation("Match");
                });

            modelBuilder.Entity("Domain.Entities.Championship", b =>
                {
                    b.Navigation("Matches");
                });
#pragma warning restore 612, 618
        }
    }
}
