﻿// <auto-generated />
using System;
using GameStore.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GameStore.DAL.Migrations
{
    [DbContext(typeof(StoreDbContext))]
    [Migration("20220222080536_Creating")]
    partial class Creating
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<Guid>("AnswerTo")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("GameId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("fk_GameId");

                    b.Property<bool>("IsAnsweread")
                        .HasColumnType("bit");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CommentId");

                    b.HasIndex("GameId");

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

                    b.HasKey("GenreId");

                    b.HasIndex("Name")
                        .IsUnique();

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
                            Name = "Sports"
                        },
                        new
                        {
                            GenreId = 3,
                            Name = "Races"
                        },
                        new
                        {
                            GenreId = 4,
                            Name = "Action"
                        },
                        new
                        {
                            GenreId = 5,
                            Name = "RPG"
                        },
                        new
                        {
                            GenreId = 6,
                            Name = "Adventure"
                        },
                        new
                        {
                            GenreId = 7,
                            Name = "Puzzle & Skill"
                        },
                        new
                        {
                            GenreId = 8,
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
                            PlatformTypeId = new Guid("e18dc0f8-8abc-46d7-a01b-12f273c4be63"),
                            Type = "Mobile"
                        },
                        new
                        {
                            PlatformTypeId = new Guid("8dab9097-6e14-414f-8f13-a21f85ce0508"),
                            Type = "Browser"
                        },
                        new
                        {
                            PlatformTypeId = new Guid("6419d2b5-0618-4994-b806-f513e816ba69"),
                            Type = "Desktop"
                        },
                        new
                        {
                            PlatformTypeId = new Guid("726a9430-cd7f-4a04-b0c2-9a9fce1d2170"),
                            Type = "Console"
                        });
                });

            modelBuilder.Entity("GameStore.DAL.Models.SubGenre", b =>
                {
                    b.Property<Guid>("SubGenreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("GenreId")
                        .HasColumnType("int")
                        .HasColumnName("fk_GenreId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SubGenreId");

                    b.HasIndex("GenreId");

                    b.ToTable("SubGenres");

                    b.HasData(
                        new
                        {
                            SubGenreId = new Guid("39559fed-4aeb-4ddc-a5a1-6b29d746da15"),
                            GenreId = 1,
                            Name = "RTS"
                        },
                        new
                        {
                            SubGenreId = new Guid("c6286a1e-7e90-4c0f-96f7-b40cab1f284b"),
                            GenreId = 1,
                            Name = "TBS"
                        },
                        new
                        {
                            SubGenreId = new Guid("6afa17d0-8813-4368-b31b-54c1fffed5e4"),
                            GenreId = 3,
                            Name = "Rally"
                        },
                        new
                        {
                            SubGenreId = new Guid("f869bbb9-8b03-4661-b838-d1bbedd0e6be"),
                            GenreId = 3,
                            Name = "Arcade"
                        },
                        new
                        {
                            SubGenreId = new Guid("c4f0c6d2-edfb-4a49-b0af-f1a3a8a7ccaa"),
                            GenreId = 3,
                            Name = "Formula"
                        },
                        new
                        {
                            SubGenreId = new Guid("76cf924c-feda-4284-b927-d661986cf8b2"),
                            GenreId = 3,
                            Name = "Off-road"
                        },
                        new
                        {
                            SubGenreId = new Guid("790b7ca4-2d54-4e02-a073-8cf9753a1d04"),
                            GenreId = 4,
                            Name = "FPS"
                        },
                        new
                        {
                            SubGenreId = new Guid("4faad84a-170e-4cbe-b78d-07d912d017eb"),
                            GenreId = 4,
                            Name = "TPS"
                        },
                        new
                        {
                            SubGenreId = new Guid("11b9888d-cfcf-45f0-ac55-65b5729e69cd"),
                            GenreId = 4,
                            Name = "Misc"
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

                    b.Navigation("Game");
                });

            modelBuilder.Entity("GameStore.DAL.Models.SubGenre", b =>
                {
                    b.HasOne("GameStore.DAL.Models.Genre", "Genre")
                        .WithMany("SubGenres")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genre");
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
