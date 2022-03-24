﻿// <auto-generated />
using System;
using GameStore.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GameStore.DAL.Migrations
{
    [DbContext(typeof(StoreDbContext))]
    partial class StoreDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.14")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GameGenre", b =>
                {
                    b.Property<Guid>("GamesGameId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("GenresGenreId")
                        .HasColumnType("int");

                    b.HasKey("GamesGameId", "GenresGenreId");

                    b.HasIndex("GenresGenreId");

                    b.ToTable("GameGenres");
                });

            modelBuilder.Entity("GamePlatformType", b =>
                {
                    b.Property<Guid>("GamesGameId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PlatformTypesPlatformTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("GamesGameId", "PlatformTypesPlatformTypeId");

                    b.HasIndex("PlatformTypesPlatformTypeId");

                    b.ToTable("GamePlatforms");
                });

            modelBuilder.Entity("GameStore.DAL.Models.Comment", b =>
                {
                    b.Property<Guid>("CommentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("GameId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("fk_GameId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ParentCommentId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("fk_ParentId");

                    b.HasKey("CommentId");

                    b.HasIndex("GameId");

                    b.HasIndex("ParentCommentId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("GameStore.DAL.Models.Game", b =>
                {
                    b.Property<Guid>("GameId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("GameId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Games");
                });

            modelBuilder.Entity("GameStore.DAL.Models.Genre", b =>
                {
                    b.Property<int>("GenreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("ParentGenreId")
                        .HasColumnType("int")
                        .HasColumnName("fk_ParentId");

                    b.HasKey("GenreId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("ParentGenreId");

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            GenreId = 1,
                            Name = "Strategy"
                        },
                        new
                        {
                            GenreId = 2,
                            Name = "RTS",
                            ParentGenreId = 1
                        },
                        new
                        {
                            GenreId = 3,
                            Name = "TBS",
                            ParentGenreId = 1
                        },
                        new
                        {
                            GenreId = 4,
                            Name = "RPG"
                        },
                        new
                        {
                            GenreId = 5,
                            Name = "Sports"
                        },
                        new
                        {
                            GenreId = 6,
                            Name = "Races"
                        },
                        new
                        {
                            GenreId = 7,
                            Name = "Rally",
                            ParentGenreId = 6
                        },
                        new
                        {
                            GenreId = 8,
                            Name = "Arcade",
                            ParentGenreId = 6
                        },
                        new
                        {
                            GenreId = 9,
                            Name = "Formula",
                            ParentGenreId = 6
                        },
                        new
                        {
                            GenreId = 10,
                            Name = "Off-road",
                            ParentGenreId = 6
                        },
                        new
                        {
                            GenreId = 11,
                            Name = "Action"
                        },
                        new
                        {
                            GenreId = 12,
                            Name = "FPS",
                            ParentGenreId = 11
                        },
                        new
                        {
                            GenreId = 13,
                            Name = "TPS",
                            ParentGenreId = 11
                        },
                        new
                        {
                            GenreId = 14,
                            Name = "Adventure"
                        },
                        new
                        {
                            GenreId = 15,
                            Name = "Puzzle & Skill"
                        },
                        new
                        {
                            GenreId = 16,
                            Name = "Misc"
                        });
                });

            modelBuilder.Entity("GameStore.DAL.Models.PlatformType", b =>
                {
                    b.Property<Guid>("PlatformTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("PlatformTypeId");

                    b.HasIndex("Type")
                        .IsUnique();

                    b.ToTable("PlatformTypes");

                    b.HasData(
                        new
                        {
                            PlatformTypeId = new Guid("6296ed25-ddb8-43fa-8e52-c81e73eb4d3f"),
                            Type = "Mobile"
                        },
                        new
                        {
                            PlatformTypeId = new Guid("d3badeee-0a8c-4069-801a-b1c1020bc00b"),
                            Type = "Browser"
                        },
                        new
                        {
                            PlatformTypeId = new Guid("10e48462-d5c0-4686-8fdc-94f39beed2cb"),
                            Type = "Desktop"
                        },
                        new
                        {
                            PlatformTypeId = new Guid("27754cdf-3662-4437-a9e5-daa31a700b98"),
                            Type = "Console"
                        });
                });

            modelBuilder.Entity("GameGenre", b =>
                {
                    b.HasOne("GameStore.DAL.Models.Game", null)
                        .WithMany()
                        .HasForeignKey("GamesGameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GameStore.DAL.Models.Genre", null)
                        .WithMany()
                        .HasForeignKey("GenresGenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GamePlatformType", b =>
                {
                    b.HasOne("GameStore.DAL.Models.Game", null)
                        .WithMany()
                        .HasForeignKey("GamesGameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GameStore.DAL.Models.PlatformType", null)
                        .WithMany()
                        .HasForeignKey("PlatformTypesPlatformTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GameStore.DAL.Models.Comment", b =>
                {
                    b.HasOne("GameStore.DAL.Models.Game", "Game")
                        .WithMany("Comments")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GameStore.DAL.Models.Comment", null)
                        .WithMany("Answers")
                        .HasForeignKey("ParentCommentId");

                    b.Navigation("Game");
                });

            modelBuilder.Entity("GameStore.DAL.Models.Genre", b =>
                {
                    b.HasOne("GameStore.DAL.Models.Genre", null)
                        .WithMany("SubGenres")
                        .HasForeignKey("ParentGenreId");
                });

            modelBuilder.Entity("GameStore.DAL.Models.Comment", b =>
                {
                    b.Navigation("Answers");
                });

            modelBuilder.Entity("GameStore.DAL.Models.Game", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("GameStore.DAL.Models.Genre", b =>
                {
                    b.Navigation("SubGenres");
                });
#pragma warning restore 612, 618
        }
    }
}
