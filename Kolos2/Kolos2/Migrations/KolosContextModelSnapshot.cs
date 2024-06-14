﻿// <auto-generated />
using System;
using Kolos2.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Kolos2.Migrations
{
    [DbContext(typeof(KolosContext))]
    partial class KolosContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Kolos2.Models.Backpacks", b =>
                {
                    b.Property<int>("CharacterId")
                        .HasColumnType("int");

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.HasKey("CharacterId", "ItemId");

                    b.HasIndex("ItemId");

                    b.ToTable("backpacks");
                });

            modelBuilder.Entity("Kolos2.Models.Character_Titles", b =>
                {
                    b.Property<int>("CharacterId")
                        .HasColumnType("int");

                    b.Property<int>("TitleId")
                        .HasColumnType("int");

                    b.Property<DateTime>("AcquiredAt")
                        .HasColumnType("datetime2");

                    b.HasKey("CharacterId", "TitleId");

                    b.HasIndex("TitleId");

                    b.ToTable("character_titles");

                    b.HasData(
                        new
                        {
                            CharacterId = 1,
                            TitleId = 1,
                            AcquiredAt = new DateTime(2024, 6, 14, 14, 35, 0, 151, DateTimeKind.Local).AddTicks(5709)
                        },
                        new
                        {
                            CharacterId = 2,
                            TitleId = 4,
                            AcquiredAt = new DateTime(2024, 6, 14, 14, 35, 0, 151, DateTimeKind.Local).AddTicks(5771)
                        },
                        new
                        {
                            CharacterId = 3,
                            TitleId = 2,
                            AcquiredAt = new DateTime(2024, 6, 14, 14, 35, 0, 151, DateTimeKind.Local).AddTicks(5773)
                        },
                        new
                        {
                            CharacterId = 4,
                            TitleId = 2,
                            AcquiredAt = new DateTime(2024, 6, 14, 14, 35, 0, 151, DateTimeKind.Local).AddTicks(5775)
                        },
                        new
                        {
                            CharacterId = 5,
                            TitleId = 3,
                            AcquiredAt = new DateTime(2024, 6, 14, 14, 35, 0, 151, DateTimeKind.Local).AddTicks(5777)
                        },
                        new
                        {
                            CharacterId = 1,
                            TitleId = 7,
                            AcquiredAt = new DateTime(2024, 6, 14, 14, 35, 0, 151, DateTimeKind.Local).AddTicks(5779)
                        });
                });

            modelBuilder.Entity("Kolos2.Models.Characters", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CurrentWeight")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.Property<int>("MaxWeight")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("characters");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CurrentWeight = 0,
                            FirstName = "Geralt",
                            LastName = "From Rivia",
                            MaxWeight = 300
                        },
                        new
                        {
                            Id = 2,
                            CurrentWeight = 0,
                            FirstName = "Ciri",
                            LastName = "From Cintra",
                            MaxWeight = 60
                        },
                        new
                        {
                            Id = 3,
                            CurrentWeight = 0,
                            FirstName = "Yennefer",
                            LastName = "From Vengerberg",
                            MaxWeight = 70
                        },
                        new
                        {
                            Id = 4,
                            CurrentWeight = 0,
                            FirstName = "Triss",
                            LastName = "Merigold",
                            MaxWeight = 50
                        },
                        new
                        {
                            Id = 5,
                            CurrentWeight = 0,
                            FirstName = "Jaskier",
                            LastName = "The Bard",
                            MaxWeight = 30
                        });
                });

            modelBuilder.Entity("Kolos2.Models.Items", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Weight")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("items");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Sword",
                            Weight = 10
                        },
                        new
                        {
                            Id = 2,
                            Name = "Shield",
                            Weight = 15
                        },
                        new
                        {
                            Id = 3,
                            Name = "Bow",
                            Weight = 5
                        });
                });

            modelBuilder.Entity("Kolos2.Models.Titles", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("titles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Witcher"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Sorceress"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Bard"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Queen"
                        },
                        new
                        {
                            Id = 5,
                            Name = "King"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Prince"
                        },
                        new
                        {
                            Id = 7,
                            Name = "White Wolf"
                        });
                });

            modelBuilder.Entity("Kolos2.Models.Backpacks", b =>
                {
                    b.HasOne("Kolos2.Models.Characters", "Character")
                        .WithMany("BackpacksNav")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Kolos2.Models.Items", "Item")
                        .WithMany("BackpacksNav")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Character");

                    b.Navigation("Item");
                });

            modelBuilder.Entity("Kolos2.Models.Character_Titles", b =>
                {
                    b.HasOne("Kolos2.Models.Characters", "Character")
                        .WithMany("Character_TitlesNav")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Kolos2.Models.Titles", "Title")
                        .WithMany("Character_TitlesNav")
                        .HasForeignKey("TitleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Character");

                    b.Navigation("Title");
                });

            modelBuilder.Entity("Kolos2.Models.Characters", b =>
                {
                    b.Navigation("BackpacksNav");

                    b.Navigation("Character_TitlesNav");
                });

            modelBuilder.Entity("Kolos2.Models.Items", b =>
                {
                    b.Navigation("BackpacksNav");
                });

            modelBuilder.Entity("Kolos2.Models.Titles", b =>
                {
                    b.Navigation("Character_TitlesNav");
                });
#pragma warning restore 612, 618
        }
    }
}
