﻿// <auto-generated />
using System;
using GameStore.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GameStore.DAL.Migrations
{
    [DbContext(typeof(StoreDbContext))]
    [Migration("20220701162918_ModTypeOfBase")]
    partial class ModTypeOfBase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.14")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GameStore.DAL.Entities.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasMaxLength(10000)
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("GameId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsQuote")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int?>("ParentCommentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.HasIndex("ParentCommentId");

                    b.ToTable("Comments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Body = "This is my favourite game",
                            GameId = 1,
                            IsDeleted = false,
                            IsQuote = false,
                            Name = "Oleksandr"
                        },
                        new
                        {
                            Id = 2,
                            Body = "And my too",
                            GameId = 1,
                            IsDeleted = false,
                            IsQuote = false,
                            Name = "Oleg",
                            ParentCommentId = 1
                        });
                });

            modelBuilder.Entity("GameStore.DAL.Entities.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AddedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(5000)
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Discontinued")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("NumberOfViews")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("PublishedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("PublisherId")
                        .HasColumnType("int");

                    b.Property<string>("QuantityPerUnit")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ReorderLevel")
                        .HasColumnType("int");

                    b.Property<int>("TypeOfBase")
                        .HasColumnType("int");

                    b.Property<short>("UnitsInStock")
                        .HasColumnType("smallint");

                    b.Property<int>("UnitsOnOrder")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Key")
                        .IsUnique();

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("PublisherId");

                    b.ToTable("Games");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AddedAt = new DateTime(2022, 7, 1, 16, 29, 17, 881, DateTimeKind.Utc).AddTicks(5109),
                            Description = "New part of Stalker",
                            Discontinued = false,
                            IsDeleted = false,
                            Key = "stalker-2",
                            Name = "Stalker2",
                            NumberOfViews = 0,
                            Price = 70m,
                            PublishedAt = new DateTime(2022, 3, 23, 16, 29, 17, 881, DateTimeKind.Utc).AddTicks(6220),
                            PublisherId = 2,
                            ReorderLevel = 0,
                            TypeOfBase = 0,
                            UnitsInStock = (short)10,
                            UnitsOnOrder = 0
                        },
                        new
                        {
                            Id = 2,
                            AddedAt = new DateTime(2022, 7, 1, 16, 29, 17, 881, DateTimeKind.Utc).AddTicks(6516),
                            Description = "Best part",
                            Discontinued = false,
                            IsDeleted = false,
                            Key = "dying-light",
                            Name = "Dying light",
                            NumberOfViews = 0,
                            Price = 50m,
                            PublishedAt = new DateTime(2022, 5, 12, 16, 29, 17, 881, DateTimeKind.Utc).AddTicks(6559),
                            PublisherId = 1,
                            ReorderLevel = 0,
                            TypeOfBase = 0,
                            UnitsInStock = (short)0,
                            UnitsOnOrder = 0
                        },
                        new
                        {
                            Id = 3,
                            AddedAt = new DateTime(2022, 7, 1, 16, 29, 17, 881, DateTimeKind.Utc).AddTicks(6569),
                            Description = "Action ",
                            Discontinued = false,
                            IsDeleted = false,
                            Key = "left-4-dead",
                            Name = "Left 4 Dead",
                            NumberOfViews = 0,
                            Price = 100m,
                            PublishedAt = new DateTime(2021, 5, 27, 16, 29, 17, 881, DateTimeKind.Utc).AddTicks(6571),
                            PublisherId = 2,
                            ReorderLevel = 0,
                            TypeOfBase = 0,
                            UnitsInStock = (short)3,
                            UnitsOnOrder = 0
                        },
                        new
                        {
                            Id = 4,
                            AddedAt = new DateTime(2022, 7, 1, 16, 29, 17, 881, DateTimeKind.Utc).AddTicks(6572),
                            Description = "Description of cmv",
                            Discontinued = false,
                            IsDeleted = false,
                            Key = "call-of-duty-mv",
                            Name = "Call of Duty:MV",
                            NumberOfViews = 0,
                            Price = 30m,
                            PublishedAt = new DateTime(2022, 6, 24, 16, 29, 17, 881, DateTimeKind.Utc).AddTicks(6574),
                            PublisherId = 3,
                            ReorderLevel = 0,
                            TypeOfBase = 0,
                            UnitsInStock = (short)5,
                            UnitsOnOrder = 0
                        },
                        new
                        {
                            Id = 5,
                            AddedAt = new DateTime(2022, 7, 1, 16, 29, 17, 881, DateTimeKind.Utc).AddTicks(6575),
                            Description = "Description of civ",
                            Discontinued = false,
                            IsDeleted = false,
                            Key = "civiization-VI",
                            Name = "Sid Meier`s Civilization VI",
                            NumberOfViews = 0,
                            Price = 60m,
                            PublishedAt = new DateTime(2022, 6, 1, 16, 29, 17, 881, DateTimeKind.Utc).AddTicks(6576),
                            PublisherId = 4,
                            ReorderLevel = 0,
                            TypeOfBase = 0,
                            UnitsInStock = (short)5,
                            UnitsOnOrder = 0
                        },
                        new
                        {
                            Id = 6,
                            AddedAt = new DateTime(2022, 7, 1, 16, 29, 17, 881, DateTimeKind.Utc).AddTicks(6577),
                            Description = "Description of arma",
                            Discontinued = false,
                            IsDeleted = false,
                            Key = "arma-3",
                            Name = "Arma 3",
                            NumberOfViews = 0,
                            Price = 80m,
                            PublishedAt = new DateTime(2022, 5, 2, 16, 29, 17, 881, DateTimeKind.Utc).AddTicks(6578),
                            PublisherId = 5,
                            ReorderLevel = 0,
                            TypeOfBase = 0,
                            UnitsInStock = (short)5,
                            UnitsOnOrder = 0
                        },
                        new
                        {
                            Id = 7,
                            AddedAt = new DateTime(2022, 7, 1, 16, 29, 17, 881, DateTimeKind.Utc).AddTicks(6579),
                            Description = "Description of nfs",
                            Discontinued = false,
                            IsDeleted = false,
                            Key = "nfs",
                            Name = "Need for speed",
                            NumberOfViews = 0,
                            Price = 100m,
                            PublishedAt = new DateTime(2022, 5, 12, 16, 29, 17, 881, DateTimeKind.Utc).AddTicks(6580),
                            PublisherId = 2,
                            ReorderLevel = 0,
                            TypeOfBase = 0,
                            UnitsInStock = (short)5,
                            UnitsOnOrder = 0
                        },
                        new
                        {
                            Id = 8,
                            AddedAt = new DateTime(2022, 7, 1, 16, 29, 17, 881, DateTimeKind.Utc).AddTicks(6581),
                            Description = "Description of Sam",
                            Discontinued = false,
                            IsDeleted = false,
                            Key = "serious-sam-4",
                            Name = "Serious Sam 4",
                            NumberOfViews = 0,
                            Price = 45m,
                            PublishedAt = new DateTime(2022, 6, 16, 16, 29, 17, 881, DateTimeKind.Utc).AddTicks(6582),
                            PublisherId = 3,
                            ReorderLevel = 0,
                            TypeOfBase = 0,
                            UnitsInStock = (short)5,
                            UnitsOnOrder = 0
                        },
                        new
                        {
                            Id = 9,
                            AddedAt = new DateTime(2022, 7, 1, 16, 29, 17, 881, DateTimeKind.Utc).AddTicks(6583),
                            Description = "Description of Sea",
                            Discontinued = false,
                            IsDeleted = false,
                            Key = "sea-of-thieves",
                            Name = "Sea of Thieves",
                            NumberOfViews = 0,
                            Price = 90m,
                            PublishedAt = new DateTime(2022, 5, 12, 16, 29, 17, 881, DateTimeKind.Utc).AddTicks(6585),
                            PublisherId = 2,
                            ReorderLevel = 0,
                            TypeOfBase = 0,
                            UnitsInStock = (short)5,
                            UnitsOnOrder = 0
                        },
                        new
                        {
                            Id = 10,
                            AddedAt = new DateTime(2022, 7, 1, 16, 29, 17, 881, DateTimeKind.Utc).AddTicks(6585),
                            Description = "Description of Battlefield",
                            Discontinued = false,
                            IsDeleted = false,
                            Key = "battlefield-4",
                            Name = "Battlefield 4",
                            NumberOfViews = 0,
                            Price = 100m,
                            PublishedAt = new DateTime(2022, 6, 1, 16, 29, 17, 881, DateTimeKind.Utc).AddTicks(6587),
                            PublisherId = 4,
                            ReorderLevel = 0,
                            TypeOfBase = 0,
                            UnitsInStock = (short)5,
                            UnitsOnOrder = 0
                        },
                        new
                        {
                            Id = 11,
                            AddedAt = new DateTime(2022, 7, 1, 16, 29, 17, 881, DateTimeKind.Utc).AddTicks(6587),
                            Description = "Description of Mass effect 1",
                            Discontinued = false,
                            IsDeleted = false,
                            Key = "mass-effect-1",
                            Name = "Mass effect 1",
                            NumberOfViews = 0,
                            Price = 50m,
                            PublishedAt = new DateTime(2022, 6, 11, 16, 29, 17, 881, DateTimeKind.Utc).AddTicks(6589),
                            PublisherId = 1,
                            ReorderLevel = 0,
                            TypeOfBase = 0,
                            UnitsInStock = (short)5,
                            UnitsOnOrder = 0
                        },
                        new
                        {
                            Id = 12,
                            AddedAt = new DateTime(2022, 7, 1, 16, 29, 17, 881, DateTimeKind.Utc).AddTicks(6590),
                            Description = "Description of Command and conqurer",
                            Discontinued = false,
                            IsDeleted = false,
                            Key = "command-and-conqurer",
                            Name = "Command and conqurer",
                            NumberOfViews = 0,
                            Price = 150m,
                            PublishedAt = new DateTime(2022, 5, 2, 16, 29, 17, 881, DateTimeKind.Utc).AddTicks(6591),
                            PublisherId = 3,
                            ReorderLevel = 0,
                            TypeOfBase = 0,
                            UnitsInStock = (short)5,
                            UnitsOnOrder = 0
                        });
                });

            modelBuilder.Entity("GameStore.DAL.Entities.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int?>("ParentGenreId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("ParentGenreId");

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsDeleted = false,
                            Name = "Strategy"
                        },
                        new
                        {
                            Id = 2,
                            IsDeleted = false,
                            Name = "RTS",
                            ParentGenreId = 1
                        },
                        new
                        {
                            Id = 3,
                            IsDeleted = false,
                            Name = "TBS",
                            ParentGenreId = 1
                        },
                        new
                        {
                            Id = 4,
                            IsDeleted = false,
                            Name = "RPG"
                        },
                        new
                        {
                            Id = 5,
                            IsDeleted = false,
                            Name = "Sports"
                        },
                        new
                        {
                            Id = 6,
                            IsDeleted = false,
                            Name = "Races"
                        },
                        new
                        {
                            Id = 7,
                            IsDeleted = false,
                            Name = "Rally",
                            ParentGenreId = 6
                        },
                        new
                        {
                            Id = 8,
                            IsDeleted = false,
                            Name = "Arcade",
                            ParentGenreId = 6
                        },
                        new
                        {
                            Id = 9,
                            IsDeleted = false,
                            Name = "Formula",
                            ParentGenreId = 6
                        },
                        new
                        {
                            Id = 10,
                            IsDeleted = false,
                            Name = "Off-road",
                            ParentGenreId = 6
                        },
                        new
                        {
                            Id = 11,
                            IsDeleted = false,
                            Name = "Action"
                        },
                        new
                        {
                            Id = 12,
                            IsDeleted = false,
                            Name = "FPS",
                            ParentGenreId = 11
                        },
                        new
                        {
                            Id = 13,
                            IsDeleted = false,
                            Name = "TPS",
                            ParentGenreId = 11
                        },
                        new
                        {
                            Id = 14,
                            IsDeleted = false,
                            Name = "Adventure"
                        },
                        new
                        {
                            Id = 15,
                            IsDeleted = false,
                            Name = "Puzzle & Skill"
                        },
                        new
                        {
                            Id = 16,
                            IsDeleted = false,
                            Name = "Misc"
                        });
                });

            modelBuilder.Entity("GameStore.DAL.Entities.GenresInGames", b =>
                {
                    b.Property<int>("GenreId")
                        .HasColumnType("int");

                    b.Property<int>("GameId")
                        .HasColumnType("int");

                    b.HasKey("GenreId", "GameId");

                    b.HasIndex("GameId");

                    b.ToTable("GenresInGames");

                    b.HasData(
                        new
                        {
                            GenreId = 1,
                            GameId = 1
                        },
                        new
                        {
                            GenreId = 3,
                            GameId = 2
                        },
                        new
                        {
                            GenreId = 5,
                            GameId = 3
                        },
                        new
                        {
                            GenreId = 11,
                            GameId = 4
                        },
                        new
                        {
                            GenreId = 3,
                            GameId = 5
                        },
                        new
                        {
                            GenreId = 11,
                            GameId = 6
                        },
                        new
                        {
                            GenreId = 6,
                            GameId = 7
                        },
                        new
                        {
                            GenreId = 12,
                            GameId = 8
                        },
                        new
                        {
                            GenreId = 14,
                            GameId = 9
                        },
                        new
                        {
                            GenreId = 7,
                            GameId = 10
                        },
                        new
                        {
                            GenreId = 8,
                            GameId = 11
                        },
                        new
                        {
                            GenreId = 8,
                            GameId = 12
                        });
                });

            modelBuilder.Entity("GameStore.DAL.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Expiration")
                        .HasColumnType("datetime2");

                    b.Property<double?>("Freight")
                        .HasColumnType("float");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("RequiredDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ShipAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShipCity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShipCountry")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShipName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ShipPostalCode")
                        .HasColumnType("int");

                    b.Property<string>("ShipRegion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ShipVia")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ShippedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("GameStore.DAL.Entities.OrderDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Discount")
                        .HasColumnType("float");

                    b.Property<int>("GameId")
                        .HasColumnType("int")
                        .HasColumnName("ProductId");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<short>("Quantity")
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("GameStore.DAL.Entities.PlatformType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("Type")
                        .IsUnique();

                    b.ToTable("PlatformTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsDeleted = false,
                            Type = "Mobile"
                        },
                        new
                        {
                            Id = 2,
                            IsDeleted = false,
                            Type = "Browser"
                        },
                        new
                        {
                            Id = 3,
                            IsDeleted = false,
                            Type = "Desktop"
                        },
                        new
                        {
                            Id = 4,
                            IsDeleted = false,
                            Type = "Console"
                        });
                });

            modelBuilder.Entity("GameStore.DAL.Entities.PlatformsInGames", b =>
                {
                    b.Property<int>("PlatformTypeId")
                        .HasColumnType("int");

                    b.Property<int>("GameId")
                        .HasColumnType("int");

                    b.HasKey("PlatformTypeId", "GameId");

                    b.HasIndex("GameId");

                    b.ToTable("PlatformsInGames");

                    b.HasData(
                        new
                        {
                            PlatformTypeId = 1,
                            GameId = 1
                        },
                        new
                        {
                            PlatformTypeId = 2,
                            GameId = 1
                        },
                        new
                        {
                            PlatformTypeId = 2,
                            GameId = 2
                        },
                        new
                        {
                            PlatformTypeId = 4,
                            GameId = 3
                        },
                        new
                        {
                            PlatformTypeId = 3,
                            GameId = 4
                        },
                        new
                        {
                            PlatformTypeId = 3,
                            GameId = 5
                        },
                        new
                        {
                            PlatformTypeId = 3,
                            GameId = 6
                        },
                        new
                        {
                            PlatformTypeId = 1,
                            GameId = 7
                        },
                        new
                        {
                            PlatformTypeId = 4,
                            GameId = 8
                        },
                        new
                        {
                            PlatformTypeId = 4,
                            GameId = 9
                        },
                        new
                        {
                            PlatformTypeId = 2,
                            GameId = 10
                        },
                        new
                        {
                            PlatformTypeId = 1,
                            GameId = 11
                        },
                        new
                        {
                            PlatformTypeId = 2,
                            GameId = 12
                        });
                });

            modelBuilder.Entity("GameStore.DAL.Entities.Publisher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("ContactName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasMaxLength(1000)
                        .HasColumnType("ntext");

                    b.Property<string>("Fax")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HomePage")
                        .IsRequired()
                        .HasMaxLength(400)
                        .HasColumnType("ntext");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CompanyName")
                        .IsUnique();

                    b.ToTable("Publishers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CompanyName = "DeepSiler",
                            Description = "Desc of Publisher 1 ",
                            HomePage = "Home",
                            IsDeleted = false
                        },
                        new
                        {
                            Id = 2,
                            CompanyName = "GSC",
                            Description = "Desc of Publisher 2 ",
                            HomePage = "Home2",
                            IsDeleted = false
                        },
                        new
                        {
                            Id = 3,
                            CompanyName = "Activision",
                            Description = "Desc of Activision",
                            HomePage = "Activision page",
                            IsDeleted = false
                        },
                        new
                        {
                            Id = 4,
                            CompanyName = "Firaxis",
                            Description = "Desc of Firaxis",
                            HomePage = "Firaxis page",
                            IsDeleted = false
                        },
                        new
                        {
                            Id = 5,
                            CompanyName = "Bohemia Interactive",
                            Description = "Desc of bohemia",
                            HomePage = "Bohemia page",
                            IsDeleted = false
                        });
                });

            modelBuilder.Entity("GameStore.DAL.Entities.Comment", b =>
                {
                    b.HasOne("GameStore.DAL.Entities.Game", "Game")
                        .WithMany("Comments")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GameStore.DAL.Entities.Comment", null)
                        .WithMany("Answers")
                        .HasForeignKey("ParentCommentId");

                    b.Navigation("Game");
                });

            modelBuilder.Entity("GameStore.DAL.Entities.Game", b =>
                {
                    b.HasOne("GameStore.DAL.Entities.Publisher", "Publisher")
                        .WithMany("Games")
                        .HasForeignKey("PublisherId");

                    b.Navigation("Publisher");
                });

            modelBuilder.Entity("GameStore.DAL.Entities.Genre", b =>
                {
                    b.HasOne("GameStore.DAL.Entities.Genre", null)
                        .WithMany("SubGenres")
                        .HasForeignKey("ParentGenreId");
                });

            modelBuilder.Entity("GameStore.DAL.Entities.GenresInGames", b =>
                {
                    b.HasOne("GameStore.DAL.Entities.Game", "Game")
                        .WithMany()
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GameStore.DAL.Entities.Genre", "Genre")
                        .WithMany()
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Game");

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("GameStore.DAL.Entities.OrderDetails", b =>
                {
                    b.HasOne("GameStore.DAL.Entities.Game", "Game")
                        .WithMany("OrderDetails")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GameStore.DAL.Entities.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Game");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("GameStore.DAL.Entities.PlatformsInGames", b =>
                {
                    b.HasOne("GameStore.DAL.Entities.Game", "Game")
                        .WithMany()
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GameStore.DAL.Entities.PlatformType", "PlatformType")
                        .WithMany()
                        .HasForeignKey("PlatformTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Game");

                    b.Navigation("PlatformType");
                });

            modelBuilder.Entity("GameStore.DAL.Entities.Comment", b =>
                {
                    b.Navigation("Answers");
                });

            modelBuilder.Entity("GameStore.DAL.Entities.Game", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("GameStore.DAL.Entities.Genre", b =>
                {
                    b.Navigation("SubGenres");
                });

            modelBuilder.Entity("GameStore.DAL.Entities.Order", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("GameStore.DAL.Entities.Publisher", b =>
                {
                    b.Navigation("Games");
                });
#pragma warning restore 612, 618
        }
    }
}
