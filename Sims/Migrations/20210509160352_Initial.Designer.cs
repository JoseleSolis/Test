﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Sims.Models.Data;

namespace Sims.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210509160352_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Sims.Models.Activity", b =>
                {
                    b.Property<Guid>("ActivityID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(127)
                        .HasColumnType("nvarchar(127)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(127)
                        .HasColumnType("nvarchar(127)");

                    b.HasKey("ActivityID");

                    b.ToTable("Activities");
                });

            modelBuilder.Entity("Sims.Models.Relations.ActivityRequiresSkill", b =>
                {
                    b.Property<Guid>("SkillID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ActivityID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("RequiredPoints")
                        .HasColumnType("int");

                    b.HasKey("SkillID", "ActivityID");

                    b.HasIndex("ActivityID");

                    b.ToTable("ActivityRequiresSkill");
                });

            modelBuilder.Entity("Sims.Models.Sim", b =>
                {
                    b.Property<Guid>("SimID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(127)
                        .HasColumnType("nvarchar(127)");

                    b.Property<string>("LifeStage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Money")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(127)
                        .HasColumnType("nvarchar(127)");

                    b.HasKey("SimID");

                    b.ToTable("Sims");
                });

            modelBuilder.Entity("Sims.Models.Skill", b =>
                {
                    b.Property<Guid>("SkillID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(127)
                        .HasColumnType("nvarchar(127)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(127)
                        .HasColumnType("nvarchar(127)");

                    b.HasKey("SkillID");

                    b.ToTable("Skills");
                });

            modelBuilder.Entity("Sims.Models.Relations.ActivityRequiresSkill", b =>
                {
                    b.HasOne("Sims.Models.Activity", "Activity")
                        .WithMany()
                        .HasForeignKey("ActivityID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sims.Models.Skill", "Skill")
                        .WithMany()
                        .HasForeignKey("SkillID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Activity");

                    b.Navigation("Skill");
                });
#pragma warning restore 612, 618
        }
    }
}
