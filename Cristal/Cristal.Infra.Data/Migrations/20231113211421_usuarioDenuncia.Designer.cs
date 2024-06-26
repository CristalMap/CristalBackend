﻿// <auto-generated />
using System;
using Cristal.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Cristal.Infra.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20231113211421_usuarioDenuncia")]
    partial class usuarioDenuncia
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Cristal.Domain.Models.Denuncia", b =>
                {
                    b.Property<Guid?>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("GUID");

                    b.Property<DateTime>("DataHoraCriacao")
                        .HasColumnType("datetime2")
                        .HasColumnName("DATAHORACRIACAO");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(700)
                        .HasColumnType("nvarchar(700)")
                        .HasColumnName("DESCRICAO");

                    b.Property<string>("FotoBase64")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("FOTO");

                    b.Property<Guid?>("GuidEndereco")
                        .IsRequired()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("GUIDENDERECO");

                    b.Property<Guid?>("GuidUsuario")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("QuantidadeAves")
                        .HasColumnType("int")
                        .HasColumnName("QUANTIDADEAVES");

                    b.Property<int>("QuantidadeMamiferos")
                        .HasColumnType("int")
                        .HasColumnName("QUANTIDADEMAMIFERO");

                    b.Property<int>("QuantidadePeixes")
                        .HasColumnType("int")
                        .HasColumnName("QUANTIDADEANFIBIOS");

                    b.Property<int>("QuantidadeRepteis")
                        .HasColumnType("int")
                        .HasColumnName("QUANTIDADEREPTEIS");

                    b.Property<int>("Status")
                        .HasColumnType("int")
                        .HasColumnName("STATUS");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)")
                        .HasColumnName("TITULO");

                    b.HasKey("Guid");

                    b.HasIndex("GuidEndereco");

                    b.HasIndex("GuidUsuario");

                    b.ToTable("DENUNCIA", (string)null);
                });

            modelBuilder.Entity("Cristal.Domain.Models.Endereco", b =>
                {
                    b.Property<Guid?>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("GUID");

                    b.Property<double>("Latitude")
                        .HasColumnType("float")
                        .HasColumnName("LATITUDE");

                    b.Property<double>("Longitude")
                        .HasColumnType("float")
                        .HasColumnName("LONGITUDE");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("NOME");

                    b.HasKey("Guid");

                    b.ToTable("ENDERECO", (string)null);
                });

            modelBuilder.Entity("Cristal.Domain.Models.Usuario", b =>
                {
                    b.Property<Guid?>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("GUID");

                    b.Property<bool>("Administrador")
                        .HasColumnType("bit")
                        .HasColumnName("ADMINISTRADOR");

                    b.Property<DateTime>("DatahoraCriacao")
                        .HasColumnType("datetime2")
                        .HasColumnName("DATAHORACRIACAO");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("EMAIL");

                    b.Property<string>("Foto")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("FOTO");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)")
                        .HasColumnName("NOME");

                    b.Property<int>("Pontos")
                        .HasColumnType("int")
                        .HasColumnName("PONTO");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("SENHA");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)")
                        .HasColumnName("TELEFONE");

                    b.HasKey("Guid");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("USUARIO", (string)null);
                });

            modelBuilder.Entity("Cristal.Domain.Models.Denuncia", b =>
                {
                    b.HasOne("Cristal.Domain.Models.Endereco", "Endereco")
                        .WithMany("Denuncias")
                        .HasForeignKey("GuidEndereco")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cristal.Domain.Models.Usuario", "Usuario")
                        .WithMany("Denuncias")
                        .HasForeignKey("GuidUsuario");

                    b.Navigation("Endereco");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Cristal.Domain.Models.Endereco", b =>
                {
                    b.Navigation("Denuncias");
                });

            modelBuilder.Entity("Cristal.Domain.Models.Usuario", b =>
                {
                    b.Navigation("Denuncias");
                });
#pragma warning restore 612, 618
        }
    }
}
