﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WebApi.Db;

#nullable disable

namespace WebApi.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Common.Models.Character", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ArmorClass")
                        .HasColumnType("integer");

                    b.Property<int>("AttackModifier")
                        .HasColumnType("integer");

                    b.Property<int>("AttackNumberPerRound")
                        .HasColumnType("integer");

                    b.Property<int>("CubeDamageMultiplier")
                        .HasColumnType("integer");

                    b.Property<int>("DamageModifier")
                        .HasColumnType("integer");

                    b.Property<int>("HitPoints")
                        .HasColumnType("integer");

                    b.Property<int>("MaxCubeDamage")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Monsters");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ArmorClass = 15,
                            AttackModifier = 1,
                            AttackNumberPerRound = 1,
                            CubeDamageMultiplier = 1,
                            DamageModifier = -1,
                            HitPoints = 7,
                            MaxCubeDamage = 6,
                            Name = "Гоблин"
                        },
                        new
                        {
                            Id = 2,
                            ArmorClass = 12,
                            AttackModifier = 3,
                            AttackNumberPerRound = 1,
                            CubeDamageMultiplier = 1,
                            DamageModifier = 1,
                            HitPoints = 32,
                            MaxCubeDamage = 8,
                            Name = "Ледяная Жаба"
                        },
                        new
                        {
                            Id = 3,
                            ArmorClass = 13,
                            AttackModifier = 5,
                            AttackNumberPerRound = 1,
                            CubeDamageMultiplier = 1,
                            DamageModifier = 3,
                            HitPoints = 15,
                            MaxCubeDamage = 12,
                            Name = "Орк"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
