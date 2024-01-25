﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Test.Data;

#nullable disable

namespace Test.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240125123919_InitalCreate")]
    partial class InitalCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Test.Model.Join", b =>
                {
                    b.Property<int>("ProfesorId")
                        .HasColumnType("int");

                    b.Property<int>("MaterieId")
                        .HasColumnType("int");

                    b.HasKey("ProfesorId", "MaterieId");

                    b.HasIndex("MaterieId");

                    b.ToTable("Join");
                });

            modelBuilder.Entity("Test.Model.Materii", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Materii");
                });

            modelBuilder.Entity("Test.Model.Profesori", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.HasKey("Id");

                    b.ToTable("Profesori");
                });

            modelBuilder.Entity("Test.Model.Join", b =>
                {
                    b.HasOne("Test.Model.Materii", "Materie")
                        .WithMany("Join")
                        .HasForeignKey("MaterieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Test.Model.Profesori", "Profesori")
                        .WithMany("Join")
                        .HasForeignKey("ProfesorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Materie");

                    b.Navigation("Profesori");
                });

            modelBuilder.Entity("Test.Model.Materii", b =>
                {
                    b.Navigation("Join");
                });

            modelBuilder.Entity("Test.Model.Profesori", b =>
                {
                    b.Navigation("Join");
                });
#pragma warning restore 612, 618
        }
    }
}
