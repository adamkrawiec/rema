﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using rema.Data;

#nullable disable

namespace rema.Migrations
{
    [DbContext(typeof(RemaContext))]
    partial class RemaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("rema.Models.EstateUnit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("RealEstateId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("RealEstateId");

                    b.ToTable("EstateUnits");
                });

            modelBuilder.Entity("rema.Models.RealEstate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("RealEstates");
                });

            modelBuilder.Entity("rema.Models.EstateUnit", b =>
                {
                    b.HasOne("rema.Models.RealEstate", "RealEstate")
                        .WithMany("EstateUnits")
                        .HasForeignKey("RealEstateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RealEstate");
                });

            modelBuilder.Entity("rema.Models.RealEstate", b =>
                {
                    b.Navigation("EstateUnits");
                });
#pragma warning restore 612, 618
        }
    }
}
