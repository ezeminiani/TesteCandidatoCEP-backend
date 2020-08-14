﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TesteCandidatoCEP.Repository;

namespace TesteCandidatoCEP.Repository.Migrations
{
    [DbContext(typeof(TesteCandidatoCEPContext))]
    [Migration("20200813210646_inicio")]
    partial class inicio
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TesteCandidatoCEP.Domain.Endereco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bairro")
                        .HasColumnName("bairro")
                        .HasMaxLength(500);

                    b.Property<string>("Cep")
                        .HasColumnName("cep")
                        .HasColumnType("char(9)");

                    b.Property<string>("Complemento")
                        .HasColumnName("complemento")
                        .HasMaxLength(500);

                    b.Property<string>("Gia")
                        .HasColumnName("gia")
                        .HasMaxLength(500);

                    b.Property<int>("Ibge")
                        .HasColumnName("ibge");

                    b.Property<string>("Localidade")
                        .HasColumnName("localidade")
                        .HasMaxLength(500);

                    b.Property<string>("Logradouro")
                        .HasColumnName("logradouro")
                        .HasMaxLength(500);

                    b.Property<string>("UF")
                        .HasColumnName("uf")
                        .HasColumnType("char(9)")
                        .HasMaxLength(2);

                    b.Property<long>("Unidade")
                        .HasColumnName("unidade");

                    b.HasKey("Id");

                    b.ToTable("CEP");
                });
#pragma warning restore 612, 618
        }
    }
}
