﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using codenow_park.Infra.Context;

#nullable disable

namespace codenowpark.Mvc.Migrations
{
    [DbContext(typeof(ParkContext))]
    [Migration("20221119030706_AjustaVagas")]
    partial class AjustaVagas
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("codenow_park.Dominio.Models.Estacionamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("PrecoHora")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("PrecoInicial")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("VagasTotais")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Estacionamentos");
                });

            modelBuilder.Entity("codenow_park.Dominio.Models.Vaga", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Entrada")
                        .HasColumnType("datetime2");

                    b.Property<int>("EstacionamentoId")
                        .HasColumnType("int");

                    b.Property<bool>("Ocupado")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("Saida")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("TempoEstacionado")
                        .HasColumnType("datetime2");

                    b.Property<int>("VeiculoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EstacionamentoId");

                    b.HasIndex("VeiculoId");

                    b.ToTable("Vagas");
                });

            modelBuilder.Entity("codenow_park.Dominio.Models.Veiculo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Placa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Veiculos");
                });

            modelBuilder.Entity("codenow_park.Dominio.Models.Vaga", b =>
                {
                    b.HasOne("codenow_park.Dominio.Models.Estacionamento", "Estacionamento")
                        .WithMany("Vagas")
                        .HasForeignKey("EstacionamentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("codenow_park.Dominio.Models.Veiculo", "Veiculo")
                        .WithMany("Vagas")
                        .HasForeignKey("VeiculoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Estacionamento");

                    b.Navigation("Veiculo");
                });

            modelBuilder.Entity("codenow_park.Dominio.Models.Estacionamento", b =>
                {
                    b.Navigation("Vagas");
                });

            modelBuilder.Entity("codenow_park.Dominio.Models.Veiculo", b =>
                {
                    b.Navigation("Vagas");
                });
#pragma warning restore 612, 618
        }
    }
}
