﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Migrations
{
    [DbContext(typeof(ProductionDbContext))]
    [Migration("20200106115801_UpdateState")]
    partial class UpdateState
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.ActionLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<int>("EventId")
                        .HasColumnType("int");

                    b.Property<int>("NewStateId")
                        .HasColumnType("int");

                    b.Property<int?>("OldStateId")
                        .HasColumnType("int");

                    b.Property<string>("UserEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.HasIndex("NewStateId");

                    b.HasIndex("OldStateId");

                    b.ToTable("CheckCenterActionLogs");

                    b.HasData(
                        new
                        {
                            Id = 6,
                            Created = new DateTime(2020, 1, 6, 12, 58, 0, 490, DateTimeKind.Local).AddTicks(1791),
                            EventId = 5,
                            NewStateId = 2,
                            UserEmail = "tvw203@gmail.com"
                        },
                        new
                        {
                            Id = 7,
                            Created = new DateTime(2020, 1, 6, 12, 58, 0, 490, DateTimeKind.Local).AddTicks(4047),
                            EventId = 5,
                            NewStateId = 3,
                            OldStateId = 2,
                            UserEmail = "tvw203@gmail.com"
                        });
                });

            modelBuilder.Entity("Domain.AdditionalInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EventId")
                        .HasColumnType("int");

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.ToTable("CheckCenterAdditionalInfo");

                    b.HasData(
                        new
                        {
                            Id = 12,
                            EventId = 5,
                            Key = "Amount of tickets",
                            Value = "0"
                        },
                        new
                        {
                            Id = 13,
                            EventId = 5,
                            Key = "Location",
                            Value = "Amsterdam"
                        });
                });

            modelBuilder.Entity("Domain.CheckType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CheckCenterCheckTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "An AX instance type",
                            Title = "AXInstance"
                        });
                });

            modelBuilder.Entity("Domain.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<int>("EventId")
                        .HasColumnType("int");

                    b.Property<string>("UserEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.ToTable("CheckCenterComments");

                    b.HasData(
                        new
                        {
                            Id = 10,
                            Content = "Recurring issue, cause known but no fix available yet",
                            Created = new DateTime(2020, 1, 6, 12, 58, 0, 490, DateTimeKind.Local).AddTicks(6337),
                            EventId = 5,
                            UserEmail = "tvw203@gmail.com"
                        },
                        new
                        {
                            Id = 11,
                            Content = "Snoozed issue for 36 hours",
                            Created = new DateTime(2020, 1, 6, 12, 58, 0, 490, DateTimeKind.Local).AddTicks(6346),
                            EventId = 5,
                            UserEmail = "tvw203@gmail.com"
                        });
                });

            modelBuilder.Entity("Domain.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Added")
                        .HasColumnType("datetime2");

                    b.Property<int>("CheckTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<int>("EventSeverity")
                        .HasColumnType("int");

                    b.Property<string>("Shorthand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SourceId")
                        .HasColumnType("int");

                    b.Property<int>("StateId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)")
                        .HasMaxLength(150);

                    b.Property<DateTime>("Updated")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CheckTypeId");

                    b.HasIndex("SourceId");

                    b.HasIndex("StateId");

                    b.ToTable("CheckCenterEvents");

                    b.HasData(
                        new
                        {
                            Id = 5,
                            Added = new DateTime(2020, 1, 6, 12, 58, 0, 485, DateTimeKind.Local).AddTicks(7043),
                            CheckTypeId = 1,
                            Description = "Ods - Breda/Warn: 1 MTs missing from Oltp",
                            EventSeverity = 300,
                            Shorthand = "s0sd009ds",
                            SourceId = 4,
                            StateId = 2,
                            Title = "Ods -1MTs from Oltp",
                            Updated = new DateTime(2020, 1, 6, 12, 58, 0, 489, DateTimeKind.Local).AddTicks(8849)
                        });
                });

            modelBuilder.Entity("Domain.Feedback", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<int>("EventId")
                        .HasColumnType("int");

                    b.Property<string>("UserEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.ToTable("CheckCenterFeedback");

                    b.HasData(
                        new
                        {
                            Id = 8,
                            Content = "@gli23 you didn't mark the issue as recurring",
                            Created = new DateTime(2020, 1, 6, 12, 58, 0, 490, DateTimeKind.Local).AddTicks(5230),
                            EventId = 5,
                            UserEmail = "tvw203@gmail.com"
                        },
                        new
                        {
                            Id = 9,
                            Content = "@gli23 you didn't update the state to UI",
                            Created = new DateTime(2020, 1, 6, 12, 58, 0, 490, DateTimeKind.Local).AddTicks(6302),
                            EventId = 5,
                            UserEmail = "iemand@gmail.com"
                        });
                });

            modelBuilder.Entity("Domain.Source", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<int>("CheckCenterServiceId")
                        .HasColumnType("int");

                    b.Property<int>("CheckTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ComebackDelay")
                        .HasColumnType("int");

                    b.Property<string>("ConnectionString")
                        .HasColumnType("nvarchar(1000)")
                        .HasMaxLength(1000);

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<bool>("IsCustomerSource")
                        .HasColumnType("bit");

                    b.Property<bool>("IsStacked")
                        .HasColumnType("bit");

                    b.Property<bool>("LogActionMandatory")
                        .HasColumnType("bit");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<int>("SourceSeverity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CheckTypeId");

                    b.ToTable("CheckCenterSources");

                    b.HasData(
                        new
                        {
                            Id = 4,
                            Active = true,
                            CheckCenterServiceId = 110,
                            CheckTypeId = 1,
                            Color = "Yellow",
                            ComebackDelay = 5000,
                            ConnectionString = "msssql://sample",
                            DisplayName = "AX Amsterdam",
                            IsCustomerSource = true,
                            IsStacked = true,
                            LogActionMandatory = false,
                            Order = 550,
                            SourceSeverity = 500
                        });
                });

            modelBuilder.Entity("Domain.State", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SourceId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("SourceId");

                    b.ToTable("CheckCenterStates");

                    b.HasData(
                        new
                        {
                            Id = 2,
                            Description = "Issue is under investigation",
                            SourceId = 4,
                            Title = "Under investigation"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Issue has been resolved",
                            SourceId = 4,
                            Title = "Resolved"
                        });
                });

            modelBuilder.Entity("Domain.ActionLog", b =>
                {
                    b.HasOne("Domain.Event", "Event")
                        .WithMany()
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Domain.State", "NewState")
                        .WithMany()
                        .HasForeignKey("NewStateId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Domain.State", "OldState")
                        .WithMany()
                        .HasForeignKey("OldStateId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Domain.AdditionalInfo", b =>
                {
                    b.HasOne("Domain.Event", "Event")
                        .WithMany()
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Comment", b =>
                {
                    b.HasOne("Domain.Event", "Event")
                        .WithMany()
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Event", b =>
                {
                    b.HasOne("Domain.CheckType", "CheckType")
                        .WithMany()
                        .HasForeignKey("CheckTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Domain.Source", "Source")
                        .WithMany()
                        .HasForeignKey("SourceId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Domain.State", "State")
                        .WithMany()
                        .HasForeignKey("StateId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Feedback", b =>
                {
                    b.HasOne("Domain.Event", "Event")
                        .WithMany()
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Source", b =>
                {
                    b.HasOne("Domain.CheckType", "CheckType")
                        .WithMany()
                        .HasForeignKey("CheckTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.State", b =>
                {
                    b.HasOne("Domain.Source", null)
                        .WithMany("States")
                        .HasForeignKey("SourceId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
