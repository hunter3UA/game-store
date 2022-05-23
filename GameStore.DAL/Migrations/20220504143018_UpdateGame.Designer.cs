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
    [Migration("20220504143018_UpdateGame")]
    partial class UpdateGame
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
                            Name = "Oleksandr"
                        },
                        new
                        {
                            Id = 2,
                            Body = "And my too",
                            GameId = 1,
                            IsDeleted = false,
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

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("PublisherId")
                        .HasColumnType("int");

                    b.Property<short>("UnitsInStock")
                        .HasColumnType("smallint");

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
                            Description = "New part of Stalker",
                            Discontinued = false,
                            IsDeleted = false,
                            Key = "stalker-2",
                            Name = "Stalker2",
                            Price = 70m,
                            PublisherId = 2,
                            UnitsInStock = (short)10
                        },
                        new
                        {
                            Id = 2,
                            Description = "Best part",
                            Discontinued = false,
                            IsDeleted = false,
                            Key = "dying-light",
                            Name = "Dying light",
                            Price = 50m,
                            PublisherId = 1,
                            UnitsInStock = (short)0
                        },
                        new
                        {
                            Id = 3,
                            Description = "Action ",
                            Discontinued = false,
                            IsDeleted = false,
                            Key = "left-4-dead",
                            Name = "Left 4 Dead",
                            Price = 100m,
                            PublisherId = 2,
                            UnitsInStock = (short)3
                        });
                });

            modelBuilder.Entity("GameStore.DAL.Entities.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CustomerId = 1,
                            IsDeleted = false,
                            OrderDate = new DateTime(2022, 5, 4, 17, 30, 17, 749, DateTimeKind.Local).AddTicks(2379)
                        },
                        new
                        {
                            Id = 2,
                            CustomerId = 2,
                            IsDeleted = false,
                            OrderDate = new DateTime(2022, 5, 4, 17, 30, 17, 751, DateTimeKind.Local).AddTicks(9932)
                        });
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

                    b.Property<int?>("OrderId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<short>("Quantity")
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderDetails");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Discount = 10.0,
                            GameId = 1,
                            IsDeleted = false,
                            OrderId = 1,
                            Price = 100m,
                            Quantity = (short)1
                        },
                        new
                        {
                            Id = 2,
                            Discount = 10.0,
                            GameId = 2,
                            IsDeleted = false,
                            OrderId = 1,
                            Price = 70m,
                            Quantity = (short)1
                        },
                        new
                        {
                            Id = 3,
                            Discount = 10.0,
                            GameId = 2,
                            IsDeleted = false,
                            OrderId = 2,
                            Price = 70m,
                            Quantity = (short)1
                        });
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
                        });
                });

            modelBuilder.Entity("GameStore.DAL.Entities.Publisher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("ntext");

                    b.Property<string>("HomePage")
                        .IsRequired()
                        .HasMaxLength(400)
                        .HasColumnType("ntext");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

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
                        .HasForeignKey("PublisherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

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
                        .HasForeignKey("OrderId");

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
