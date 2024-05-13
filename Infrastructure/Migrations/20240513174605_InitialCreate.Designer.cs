﻿// <auto-generated />
using System;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240513174605_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Domain.Todos.Todo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Categoria")
                        .IsRequired()
                        .HasMaxLength(400)
                        .HasColumnType("character varying(400)")
                        .HasColumnName("categoria");

                    b.Property<bool>("Completada")
                        .HasColumnType("boolean")
                        .HasColumnName("completada");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(400)
                        .HasColumnType("character varying(400)")
                        .HasColumnName("descripcion");

                    b.Property<DateTime>("FechaActualizacion")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("fecha_actualizacion");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("fecha_creacion");

                    b.Property<DateTime>("FechaVencimiento")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("fecha_vencimiento");

                    b.Property<Guid>("IdUsuario")
                        .HasColumnType("uuid")
                        .HasColumnName("id_usuario");

                    b.Property<int>("Prioridad")
                        .HasColumnType("integer")
                        .HasColumnName("prioridad");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)")
                        .HasColumnName("titulo");

                    b.HasKey("Id")
                        .HasName("pk_todos");

                    b.ToTable("todos", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}