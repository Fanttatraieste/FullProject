﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RetroBack.Persistence;

#nullable disable

namespace RetroBack.Persistence.Migrations
{
    [DbContext(typeof(RetroFootballDbContext))]
    [Migration("20231026174121_UEFASuperCupTable")]
    partial class UEFASuperCupTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FootballIconsCAPI.Entities.ChampionsCup", b =>
                {
                    b.Property<Guid>("ChampionsCupID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Confederation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Place")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RunnerUpTeamId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("WinnerTeamId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("ChampionsCupID");

                    b.HasIndex("RunnerUpTeamId");

                    b.HasIndex("WinnerTeamId");

                    b.ToTable("ChampionsCupInfo");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("RetroBack.Domain.Entities.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDisabledByAdmin")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("RetroBack.Domain.Entities.Role", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("RetroBack.Domain.Entities.Team", b =>
                {
                    b.Property<Guid>("TeamID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TeamCountry")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TeamName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TeamID");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("RetroBack.Domain.Entities.TeamDomesticCup", b =>
                {
                    b.Property<Guid>("DomesticCupID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("WinnerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("DomesticCupID");

                    b.HasIndex("WinnerId");

                    b.ToTable("DomesticCupInfo");
                });

            modelBuilder.Entity("RetroBack.Domain.Entities.TeamDomesticLeague", b =>
                {
                    b.Property<Guid>("DomesticLeagueID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RunnerUpId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("WinnerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("DomesticLeagueID");

                    b.HasIndex("RunnerUpId");

                    b.HasIndex("WinnerId");

                    b.ToTable("DomesticLeagueInfo");
                });

            modelBuilder.Entity("RetroBack.Domain.Entities.TeamDomesticSuperCup", b =>
                {
                    b.Property<Guid>("DomesticSuperCupID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("WinnerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("DomesticSuperCupID");

                    b.HasIndex("WinnerId");

                    b.ToTable("DomesticSuperCupInfo");
                });

            modelBuilder.Entity("RetroBack.Domain.Entities.TeamUEFACup", b =>
                {
                    b.Property<Guid>("UEFACupID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Confederation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Place")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UefaCupRunnerUpId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UefaCupWinnerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("UEFACupID");

                    b.HasIndex("UefaCupRunnerUpId");

                    b.HasIndex("UefaCupWinnerId");

                    b.ToTable("UEFACupInfo");
                });

            modelBuilder.Entity("RetroBack.Domain.Entities.TeamUefaSuperCup", b =>
                {
                    b.Property<Guid>("UEFASuperCupID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Confederation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Place")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UefaSuperCupWinnerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("UEFASuperCupID");

                    b.HasIndex("UefaSuperCupWinnerId");

                    b.ToTable("UEFASuperCupInfo");
                });

            modelBuilder.Entity("RetroBack.Domain.Entities.UserRole", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("FootballIconsCAPI.Entities.ChampionsCup", b =>
                {
                    b.HasOne("RetroBack.Domain.Entities.Team", "RunnerUp")
                        .WithMany("ChampionsCupRunnerUps")
                        .HasForeignKey("RunnerUpTeamId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("FK_ChampionsCupRunnerUps_Team");

                    b.HasOne("RetroBack.Domain.Entities.Team", "Winner")
                        .WithMany("ChampionsCups")
                        .HasForeignKey("WinnerTeamId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("FK_ChampionsCup_Team");

                    b.Navigation("RunnerUp");

                    b.Navigation("Winner");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("RetroBack.Domain.Entities.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("RetroBack.Domain.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("RetroBack.Domain.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("RetroBack.Domain.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RetroBack.Domain.Entities.TeamDomesticCup", b =>
                {
                    b.HasOne("RetroBack.Domain.Entities.Team", "WinnerTeam")
                        .WithMany("DomesticCups")
                        .HasForeignKey("WinnerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("FK_DomesticCup_Team");

                    b.Navigation("WinnerTeam");
                });

            modelBuilder.Entity("RetroBack.Domain.Entities.TeamDomesticLeague", b =>
                {
                    b.HasOne("RetroBack.Domain.Entities.Team", "RunnerUpTeam")
                        .WithMany("DomesticLeagueRunnerUps")
                        .HasForeignKey("RunnerUpId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("FK_DomesticLeagueRunnerUp_Team");

                    b.HasOne("RetroBack.Domain.Entities.Team", "WinnerTeam")
                        .WithMany("DomesticLeagues")
                        .HasForeignKey("WinnerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("FK_DomesticLeagueWinner_Team");

                    b.Navigation("RunnerUpTeam");

                    b.Navigation("WinnerTeam");
                });

            modelBuilder.Entity("RetroBack.Domain.Entities.TeamDomesticSuperCup", b =>
                {
                    b.HasOne("RetroBack.Domain.Entities.Team", "Winner")
                        .WithMany("DomesticSuperCups")
                        .HasForeignKey("WinnerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("FK_DomesticSuperCupWinner_Team");

                    b.Navigation("Winner");
                });

            modelBuilder.Entity("RetroBack.Domain.Entities.TeamUEFACup", b =>
                {
                    b.HasOne("RetroBack.Domain.Entities.Team", "RunnerUpTeam")
                        .WithMany("UefaCupsRunnerUps")
                        .HasForeignKey("UefaCupRunnerUpId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("FK_UEFACupRunnerUp_Team");

                    b.HasOne("RetroBack.Domain.Entities.Team", "WinnerTeam")
                        .WithMany("UefaCups")
                        .HasForeignKey("UefaCupWinnerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("FK_UEFACupWinner_Team");

                    b.Navigation("RunnerUpTeam");

                    b.Navigation("WinnerTeam");
                });

            modelBuilder.Entity("RetroBack.Domain.Entities.TeamUefaSuperCup", b =>
                {
                    b.HasOne("RetroBack.Domain.Entities.Team", "WinnerTeam")
                        .WithMany("UefaSuperCups")
                        .HasForeignKey("UefaSuperCupWinnerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("FK_UEFASuperCupRunnerUp_Team");

                    b.Navigation("WinnerTeam");
                });

            modelBuilder.Entity("RetroBack.Domain.Entities.UserRole", b =>
                {
                    b.HasOne("RetroBack.Domain.Entities.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RetroBack.Domain.Entities.ApplicationUser", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("RetroBack.Domain.Entities.ApplicationUser", b =>
                {
                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("RetroBack.Domain.Entities.Role", b =>
                {
                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("RetroBack.Domain.Entities.Team", b =>
                {
                    b.Navigation("ChampionsCupRunnerUps");

                    b.Navigation("ChampionsCups");

                    b.Navigation("DomesticCups");

                    b.Navigation("DomesticLeagueRunnerUps");

                    b.Navigation("DomesticLeagues");

                    b.Navigation("DomesticSuperCups");

                    b.Navigation("UefaCups");

                    b.Navigation("UefaCupsRunnerUps");

                    b.Navigation("UefaSuperCups");
                });
#pragma warning restore 612, 618
        }
    }
}
