﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Migrations.ArchiveDb
{
    [DbContext(typeof(ArchiveDbContext))]
    partial class ArchiveDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Archive.ArchivedActionLog", b =>
                {
                    b.Property<int>("StoredId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<int>("EventId")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int>("NewStateId")
                        .HasColumnType("int");

                    b.Property<int>("OldStateId")
                        .HasColumnType("int");

                    b.Property<string>("UserEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StoredId");

                    b.ToTable("CheckCenterActionLogs");

                    b.HasData(
                        new
                        {
                            StoredId = 1,
                            Created = new DateTime(2020, 1, 8, 12, 3, 3, 284, DateTimeKind.Local).AddTicks(3129),
                            EventId = 1,
                            Id = 1,
                            NewStateId = 2,
                            OldStateId = -1,
                            UserEmail = "tvw203@gmail.com"
                        },
                        new
                        {
                            StoredId = 2,
                            Created = new DateTime(2020, 1, 8, 12, 3, 3, 284, DateTimeKind.Local).AddTicks(5192),
                            EventId = 1,
                            Id = 2,
                            NewStateId = 3,
                            OldStateId = 2,
                            UserEmail = "tvw203@gmail.com"
                        });
                });

            modelBuilder.Entity("Domain.Archive.ArchivedComment", b =>
                {
                    b.Property<int>("StoredId")
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

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("UserEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StoredId");

                    b.ToTable("CheckCenterComments");

                    b.HasData(
                        new
                        {
                            StoredId = 1,
                            Content = "Recurring issue, cause known but no fix available yet",
                            Created = new DateTime(2020, 1, 8, 12, 3, 3, 284, DateTimeKind.Local).AddTicks(6429),
                            EventId = 1,
                            Id = 1,
                            UserEmail = "tvw203@gmail.com"
                        },
                        new
                        {
                            StoredId = 2,
                            Content = "Snoozed issue for 36 hours",
                            Created = new DateTime(2020, 1, 8, 12, 3, 3, 284, DateTimeKind.Local).AddTicks(6438),
                            EventId = 1,
                            Id = 2,
                            UserEmail = "tvw203@gmail.com"
                        });
                });

            modelBuilder.Entity("Domain.Archive.ArchivedEvent", b =>
                {
                    b.Property<int>("StoredId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Added")
                        .HasColumnType("datetime2");

                    b.Property<int>("CheckTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Conclusion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EventSeverity")
                        .HasColumnType("int");

                    b.Property<DateTime>("Finished")
                        .HasColumnType("datetime2");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<DateTime>("Removed")
                        .HasColumnType("datetime2");

                    b.Property<string>("Shorthand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SourceId")
                        .HasColumnType("int");

                    b.Property<int>("StateId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("datetime2");

                    b.HasKey("StoredId");

                    b.ToTable("CheckCenterFinishedEvents");

                    b.HasData(
                        new
                        {
                            StoredId = 1,
                            Added = new DateTime(2020, 1, 8, 12, 3, 3, 280, DateTimeKind.Local).AddTicks(5264),
                            CheckTypeId = 1,
                            Description = "Ods - Breda/Warn: 1 MTs missing from Oltp",
                            EventSeverity = 300,
                            Finished = new DateTime(2020, 1, 8, 12, 3, 3, 284, DateTimeKind.Local).AddTicks(715),
                            Id = 1,
                            Removed = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Shorthand = "s0sd009ds",
                            SourceId = 4,
                            StateId = 2,
                            Title = "Ods -1MTs from Oltp",
                            Updated = new DateTime(2020, 1, 8, 12, 3, 3, 284, DateTimeKind.Local).AddTicks(685)
                        });
                });

            modelBuilder.Entity("Domain.Archive.ArchivedFeedback", b =>
                {
                    b.Property<int>("StoredId")
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

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("UserEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StoredId");

                    b.ToTable("CheckCenterFeedback");

                    b.HasData(
                        new
                        {
                            StoredId = 1,
                            Content = "@gli23 you didn't mark the issue as recurring",
                            Created = new DateTime(2020, 1, 8, 12, 3, 3, 284, DateTimeKind.Local).AddTicks(5246),
                            EventId = 1,
                            Id = 1,
                            UserEmail = "tvw203@gmail.com"
                        },
                        new
                        {
                            StoredId = 2,
                            Content = "@gli23 you didn't update the state to UI",
                            Created = new DateTime(2020, 1, 8, 12, 3, 3, 284, DateTimeKind.Local).AddTicks(6395),
                            EventId = 1,
                            Id = 2,
                            UserEmail = "iemand@gmail.com"
                        });
                });

            modelBuilder.Entity("Domain.Archive.ArchivedInfo", b =>
                {
                    b.Property<int>("StoredId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EventId")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StoredId");

                    b.ToTable("CheckCenterAdditionalInfo");

                    b.HasData(
                        new
                        {
                            StoredId = 1,
                            EventId = 1,
                            Id = 1,
                            Key = "Amount of tickets",
                            Value = "0"
                        },
                        new
                        {
                            StoredId = 2,
                            EventId = 1,
                            Id = 2,
                            Key = "Location",
                            Value = "Amsterdam"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
