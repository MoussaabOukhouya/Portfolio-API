﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using portfolio.data;

#nullable disable

namespace portfolio.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20221230225925_initialCreate")]
    partial class initialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("portfolio.models.Certificat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("PersonId")
                        .HasColumnType("int");

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("link")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("certificats");
                });

            modelBuilder.Entity("portfolio.models.Experience", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("PersonId")
                        .HasColumnType("int");

                    b.Property<string>("companyImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("endDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("startDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("experiences");
                });

            modelBuilder.Entity("portfolio.models.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("biographie")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("firstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("profession")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("resume")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("persons");
                });

            modelBuilder.Entity("portfolio.models.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ExperienceId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("endDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("githubLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("methodologie")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("startDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ExperienceId");

                    b.ToTable("projects");
                });

            modelBuilder.Entity("portfolio.models.Skill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("PersonId")
                        .HasColumnType("int");

                    b.Property<int?>("ProjectId")
                        .HasColumnType("int");

                    b.Property<int?>("certificatId")
                        .HasColumnType("int");

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("level")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.HasIndex("ProjectId");

                    b.HasIndex("certificatId");

                    b.ToTable("skills");
                });

            modelBuilder.Entity("portfolio.models.SocialMedia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("PersonId")
                        .HasColumnType("int");

                    b.Property<string>("image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("link")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("socialMedias");
                });

            modelBuilder.Entity("portfolio.models.Tool", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("PersonId")
                        .HasColumnType("int");

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("link")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("tools");
                });

            modelBuilder.Entity("portfolio.models.Certificat", b =>
                {
                    b.HasOne("portfolio.models.Person", null)
                        .WithMany("certificats")
                        .HasForeignKey("PersonId");
                });

            modelBuilder.Entity("portfolio.models.Experience", b =>
                {
                    b.HasOne("portfolio.models.Person", null)
                        .WithMany("experiences")
                        .HasForeignKey("PersonId");
                });

            modelBuilder.Entity("portfolio.models.Project", b =>
                {
                    b.HasOne("portfolio.models.Experience", null)
                        .WithMany("projects")
                        .HasForeignKey("ExperienceId");
                });

            modelBuilder.Entity("portfolio.models.Skill", b =>
                {
                    b.HasOne("portfolio.models.Person", null)
                        .WithMany("skills")
                        .HasForeignKey("PersonId");

                    b.HasOne("portfolio.models.Project", null)
                        .WithMany("skills")
                        .HasForeignKey("ProjectId");

                    b.HasOne("portfolio.models.Certificat", "certificat")
                        .WithMany()
                        .HasForeignKey("certificatId");

                    b.Navigation("certificat");
                });

            modelBuilder.Entity("portfolio.models.SocialMedia", b =>
                {
                    b.HasOne("portfolio.models.Person", null)
                        .WithMany("socialMedias")
                        .HasForeignKey("PersonId");
                });

            modelBuilder.Entity("portfolio.models.Tool", b =>
                {
                    b.HasOne("portfolio.models.Person", null)
                        .WithMany("tools")
                        .HasForeignKey("PersonId");
                });

            modelBuilder.Entity("portfolio.models.Experience", b =>
                {
                    b.Navigation("projects");
                });

            modelBuilder.Entity("portfolio.models.Person", b =>
                {
                    b.Navigation("certificats");

                    b.Navigation("experiences");

                    b.Navigation("skills");

                    b.Navigation("socialMedias");

                    b.Navigation("tools");
                });

            modelBuilder.Entity("portfolio.models.Project", b =>
                {
                    b.Navigation("skills");
                });
#pragma warning restore 612, 618
        }
    }
}