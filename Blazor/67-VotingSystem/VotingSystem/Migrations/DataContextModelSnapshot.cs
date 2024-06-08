﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VotingSystem.Data;

#nullable disable

namespace VotingSystem.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("VotingSystem.Models.Vote", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("VotedOn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VotedOnParty")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Voter")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Votes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            VotedOn = "Bob",
                            VotedOnParty = "Green",
                            Voter = "Philip"
                        },
                        new
                        {
                            Id = 2,
                            VotedOn = "Charlie",
                            VotedOnParty = "Red",
                            Voter = "Peter"
                        },
                        new
                        {
                            Id = 3,
                            VotedOn = "Alice",
                            VotedOnParty = "Blue",
                            Voter = "Sune"
                        },
                        new
                        {
                            Id = 4,
                            VotedOn = "Thomas",
                            VotedOnParty = "Yellow",
                            Voter = "Max"
                        },
                        new
                        {
                            Id = 5,
                            VotedOn = "Dutch",
                            VotedOnParty = "Purple",
                            Voter = "Lucas"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}