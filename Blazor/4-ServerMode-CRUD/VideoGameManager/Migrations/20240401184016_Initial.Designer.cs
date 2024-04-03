﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VideoGameManager.Data;

#nullable disable

namespace VideoGameManager.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240401184016_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("VideoGameManager.Entities.VideoGame", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Publisher")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ReleaseYear")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("VideoGames");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Publisher = "Rockstar Games",
                            ReleaseYear = 2013,
                            Title = "Grand Theft Auto 5"
                        },
                        new
                        {
                            Id = 2,
                            Publisher = "Rockstar Games",
                            ReleaseYear = 2018,
                            Title = "Red Dead Redemption 2"
                        },
                        new
                        {
                            Id = 3,
                            Publisher = "Rockstar Games",
                            ReleaseYear = 2025,
                            Title = "Grand Theft Auto 6"
                        },
                        new
                        {
                            Id = 4,
                            Publisher = "Mojang",
                            ReleaseYear = 2011,
                            Title = "Minecraft"
                        },
                        new
                        {
                            Id = 5,
                            Publisher = "CD Project",
                            ReleaseYear = 2020,
                            Title = "Cyberpunk 2077"
                        },
                        new
                        {
                            Id = 6,
                            Publisher = "Quantic Dream",
                            ReleaseYear = 2018,
                            Title = "Detroit: Become Human"
                        },
                        new
                        {
                            Id = 7,
                            Publisher = "Santa Monica Studio",
                            ReleaseYear = 2022,
                            Title = "God of War Ragnarök"
                        },
                        new
                        {
                            Id = 8,
                            Publisher = "CD Project",
                            ReleaseYear = 2015,
                            Title = "The Witcher 3"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
