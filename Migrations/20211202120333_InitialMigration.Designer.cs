﻿// <auto-generated />
using MVCBasics.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MVCBasics.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20211202120333_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.12");

            modelBuilder.Entity("MVCBasics.Models.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Cities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CountryId = 1,
                            Name = "Göteborg"
                        },
                        new
                        {
                            Id = 2,
                            CountryId = 1,
                            Name = "Stockholm"
                        },
                        new
                        {
                            Id = 3,
                            CountryId = 1,
                            Name = "Malmö"
                        },
                        new
                        {
                            Id = 4,
                            CountryId = 1,
                            Name = "Kiruna"
                        },
                        new
                        {
                            Id = 5,
                            CountryId = 1,
                            Name = "Helsingborg"
                        },
                        new
                        {
                            Id = 6,
                            CountryId = 1,
                            Name = "Uppsala"
                        },
                        new
                        {
                            Id = 7,
                            CountryId = 1,
                            Name = "Karlstad"
                        });
                });

            modelBuilder.Entity("MVCBasics.Models.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Countries");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Sweden"
                        });
                });

            modelBuilder.Entity("MVCBasics.Models.Language", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Languages");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "French"
                        },
                        new
                        {
                            Id = 2,
                            Name = "German"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Swedish"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Norwegian"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Japanese"
                        },
                        new
                        {
                            Id = 6,
                            Name = "English"
                        });
                });

            modelBuilder.Entity("MVCBasics.Models.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("People");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CityId = 6,
                            Name = "Michael Sjögren",
                            PhoneNumber = "555-322-31"
                        },
                        new
                        {
                            Id = 2,
                            CityId = 5,
                            Name = "Anders",
                            PhoneNumber = "555-321-324"
                        },
                        new
                        {
                            Id = 3,
                            CityId = 7,
                            Name = "Sten",
                            PhoneNumber = "555-321-468"
                        },
                        new
                        {
                            Id = 4,
                            CityId = 7,
                            Name = "Leonard",
                            PhoneNumber = "555-897-321"
                        },
                        new
                        {
                            Id = 5,
                            CityId = 4,
                            Name = "Amir",
                            PhoneNumber = "555-893-321"
                        },
                        new
                        {
                            Id = 6,
                            CityId = 5,
                            Name = "Lena",
                            PhoneNumber = "555-893-321"
                        },
                        new
                        {
                            Id = 7,
                            CityId = 5,
                            Name = "Lisbeth",
                            PhoneNumber = "555-321-567"
                        },
                        new
                        {
                            Id = 8,
                            CityId = 4,
                            Name = "Niklas",
                            PhoneNumber = "555-321-324"
                        },
                        new
                        {
                            Id = 9,
                            CityId = 1,
                            Name = "Stefan",
                            PhoneNumber = "555-783-321"
                        },
                        new
                        {
                            Id = 10,
                            CityId = 2,
                            Name = "Lina",
                            PhoneNumber = "555-321-645"
                        },
                        new
                        {
                            Id = 11,
                            CityId = 7,
                            Name = "Eva",
                            PhoneNumber = "555-321-555"
                        },
                        new
                        {
                            Id = 12,
                            CityId = 7,
                            Name = "Hamid",
                            PhoneNumber = "555-873-321"
                        });
                });

            modelBuilder.Entity("MVCBasics.Models.PersonLanguage", b =>
                {
                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.Property<int>("LanguageId")
                        .HasColumnType("int");

                    b.HasKey("PersonId", "LanguageId");

                    b.HasIndex("LanguageId");

                    b.ToTable("PersonLanguages");

                    b.HasData(
                        new
                        {
                            PersonId = 1,
                            LanguageId = 1
                        },
                        new
                        {
                            PersonId = 1,
                            LanguageId = 3
                        },
                        new
                        {
                            PersonId = 1,
                            LanguageId = 6
                        },
                        new
                        {
                            PersonId = 2,
                            LanguageId = 3
                        },
                        new
                        {
                            PersonId = 3,
                            LanguageId = 5
                        },
                        new
                        {
                            PersonId = 4,
                            LanguageId = 1
                        },
                        new
                        {
                            PersonId = 5,
                            LanguageId = 3
                        },
                        new
                        {
                            PersonId = 6,
                            LanguageId = 5
                        },
                        new
                        {
                            PersonId = 7,
                            LanguageId = 1
                        },
                        new
                        {
                            PersonId = 8,
                            LanguageId = 4
                        },
                        new
                        {
                            PersonId = 9,
                            LanguageId = 3
                        },
                        new
                        {
                            PersonId = 10,
                            LanguageId = 1
                        },
                        new
                        {
                            PersonId = 11,
                            LanguageId = 4
                        },
                        new
                        {
                            PersonId = 12,
                            LanguageId = 2
                        },
                        new
                        {
                            PersonId = 12,
                            LanguageId = 6
                        });
                });

            modelBuilder.Entity("MVCBasics.Models.City", b =>
                {
                    b.HasOne("MVCBasics.Models.Country", "Country")
                        .WithMany("Cities")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("MVCBasics.Models.Person", b =>
                {
                    b.HasOne("MVCBasics.Models.City", "City")
                        .WithMany("People")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("MVCBasics.Models.PersonLanguage", b =>
                {
                    b.HasOne("MVCBasics.Models.Language", "Language")
                        .WithMany("PersonLanguages")
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MVCBasics.Models.Person", "Person")
                        .WithMany("PersonLanguages")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Language");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("MVCBasics.Models.City", b =>
                {
                    b.Navigation("People");
                });

            modelBuilder.Entity("MVCBasics.Models.Country", b =>
                {
                    b.Navigation("Cities");
                });

            modelBuilder.Entity("MVCBasics.Models.Language", b =>
                {
                    b.Navigation("PersonLanguages");
                });

            modelBuilder.Entity("MVCBasics.Models.Person", b =>
                {
                    b.Navigation("PersonLanguages");
                });
#pragma warning restore 612, 618
        }
    }
}