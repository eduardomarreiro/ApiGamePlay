﻿// <auto-generated />
using ApiGamePlay.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ApiGamePlay.Data.Migrations
{
    [DbContext(typeof(GamePlayContext))]
    partial class GamePlayContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ApiGamePlay.Domain.Models.Equipamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Dano")
                        .HasColumnType("int");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PlayerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PlayerId");

                    b.ToTable("Equipamentos");
                });

            modelBuilder.Entity("ApiGamePlay.Domain.Models.Ogro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Dano")
                        .HasColumnType("int");

                    b.Property<int>("Defesa")
                        .HasColumnType("int");

                    b.Property<int>("Vida")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Ogros");
                });

            modelBuilder.Entity("ApiGamePlay.Domain.Models.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Vida")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("ApiGamePlay.Domain.Models.Equipamento", b =>
                {
                    b.HasOne("ApiGamePlay.Domain.Models.Player", "Player")
                        .WithMany("Equipamento")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Player");
                });

            modelBuilder.Entity("ApiGamePlay.Domain.Models.Player", b =>
                {
                    b.Navigation("Equipamento");
                });
#pragma warning restore 612, 618
        }
    }
}
