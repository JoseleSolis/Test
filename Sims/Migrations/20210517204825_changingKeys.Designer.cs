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
    [Migration("20210517204825_changingKeys")]
    partial class changingKeys
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

            modelBuilder.Entity("Sims.Models.DomesticUnit", b =>
                {
                    b.Property<Guid>("DomesticUnitID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("BathroomNumber")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(127)
                        .HasColumnType("nvarchar(127)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(127)
                        .HasColumnType("nvarchar(127)");

                    b.Property<int>("RoomNumber")
                        .HasColumnType("int");

                    b.HasKey("DomesticUnitID");

                    b.ToTable("DomesticUnits");
                });

            modelBuilder.Entity("Sims.Models.Neighborhood", b =>
                {
                    b.Property<Guid>("NeighborhoodID")
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

                    b.HasKey("NeighborhoodID");

                    b.ToTable("Neighborhoods");
                });

            modelBuilder.Entity("Sims.Models.Pet", b =>
                {
                    b.Property<Guid>("PetID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(127)
                        .HasColumnType("nvarchar(127)");

                    b.Property<Guid?>("TypeID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TypeName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PetID");

                    b.HasIndex("TypeID");

                    b.ToTable("Pets");
                });

            modelBuilder.Entity("Sims.Models.PetType", b =>
                {
                    b.Property<Guid>("TypeID")
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

                    b.HasKey("TypeID");

                    b.ToTable("PetTypes");
                });

            modelBuilder.Entity("Sims.Models.Place", b =>
                {
                    b.Property<Guid>("PlaceID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Cost")
                        .HasColumnType("float");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(127)
                        .HasColumnType("nvarchar(127)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(127)
                        .HasColumnType("nvarchar(127)");

                    b.HasKey("PlaceID");

                    b.ToTable("Places");
                });

            modelBuilder.Entity("Sims.Models.Profession", b =>
                {
                    b.Property<Guid>("ProfessionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("BasicSalary")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(127)
                        .HasColumnType("nvarchar(127)");

                    b.HasKey("ProfessionID");

                    b.ToTable("Professions");
                });

            modelBuilder.Entity("Sims.Models.Quest", b =>
                {
                    b.Property<Guid>("QuestID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Cost")
                        .HasColumnType("float");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(127)
                        .HasColumnType("nvarchar(127)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(127)
                        .HasColumnType("nvarchar(127)");

                    b.Property<double>("Reward")
                        .HasColumnType("float");

                    b.HasKey("QuestID");

                    b.ToTable("Quests");
                });

            modelBuilder.Entity("Sims.Models.Relations.ActivityImprovesSkill", b =>
                {
                    b.Property<Guid>("ActivityID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SkillID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ActivityID");

                    b.HasIndex("SkillID");

                    b.ToTable("ActivityImprovesSkill");
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

            modelBuilder.Entity("Sims.Models.Relations.Exercise", b =>
                {
                    b.Property<Guid>("SimID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<Guid>("ProfessionID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("SimID");

                    b.HasIndex("ProfessionID");

                    b.ToTable("Exercises");
                });

            modelBuilder.Entity("Sims.Models.Relations.Involve", b =>
                {
                    b.Property<Guid>("SimID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("QuestID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("WorldID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Success")
                        .HasColumnType("bit");

                    b.HasKey("SimID", "Date", "QuestID", "WorldID");

                    b.HasIndex("QuestID");

                    b.HasIndex("SimID", "WorldID", "Date");

                    b.ToTable("Involvements");
                });

            modelBuilder.Entity("Sims.Models.Relations.NeighborhoodDomesticUnits", b =>
                {
                    b.Property<Guid>("DomesticUnitID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("NeighborhoodID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("DomesticUnitID");

                    b.HasIndex("NeighborhoodID");

                    b.ToTable("NeighborhoodDomesticUnits");
                });

            modelBuilder.Entity("Sims.Models.Relations.NeighborhoodPlaces", b =>
                {
                    b.Property<Guid>("PlaceID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("NeighborhoodID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("PlaceID");

                    b.HasIndex("NeighborhoodID");

                    b.ToTable("NeighborhoodPlaces");
                });

            modelBuilder.Entity("Sims.Models.Relations.NeighborhoodUpgradesSkill", b =>
                {
                    b.Property<Guid>("NeighborhoodID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SkillID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("NeighborhoodID");

                    b.HasIndex("SkillID");

                    b.ToTable("NeighborhoodUpgradesSkill");
                });

            modelBuilder.Entity("Sims.Models.Relations.Perform", b =>
                {
                    b.Property<Guid>("SimID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ActivityID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("LastPerform")
                        .HasColumnType("datetime2");

                    b.HasKey("SimID", "ActivityID");

                    b.HasIndex("ActivityID");

                    b.ToTable("Performances");
                });

            modelBuilder.Entity("Sims.Models.Relations.PetLives", b =>
                {
                    b.Property<Guid>("PetID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DomesticUnitID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("PetID");

                    b.HasIndex("DomesticUnitID");

                    b.ToTable("PetLives");
                });

            modelBuilder.Entity("Sims.Models.Relations.ProfessionUpgradesSkill", b =>
                {
                    b.Property<Guid>("ProfessionID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SkillID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ProfessionID");

                    b.HasIndex("SkillID");

                    b.ToTable("ProfessionUpgradesSkill");
                });

            modelBuilder.Entity("Sims.Models.Relations.QuestRequiresSkill", b =>
                {
                    b.Property<Guid>("SkillID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("QuestID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("RequiredPoints")
                        .HasColumnType("int");

                    b.HasKey("SkillID", "QuestID");

                    b.HasIndex("QuestID");

                    b.ToTable("QuestRequiresSkill");
                });

            modelBuilder.Entity("Sims.Models.Relations.QuestWorld", b =>
                {
                    b.Property<Guid>("QuestID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("WorldID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("QuestID");

                    b.HasIndex("WorldID");

                    b.ToTable("QuestWorld");
                });

            modelBuilder.Entity("Sims.Models.Relations.SimLives", b =>
                {
                    b.Property<Guid>("SimID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DomesticUnitID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("SimID");

                    b.HasIndex("DomesticUnitID");

                    b.ToTable("SimLives");
                });

            modelBuilder.Entity("Sims.Models.Relations.SimSkills", b =>
                {
                    b.Property<Guid>("SimID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SkillID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Points")
                        .HasColumnType("int");

                    b.HasKey("SimID", "SkillID");

                    b.HasIndex("SkillID");

                    b.ToTable("SimSkills");
                });

            modelBuilder.Entity("Sims.Models.Relations.Travel", b =>
                {
                    b.Property<Guid>("SimID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("WorldID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.HasKey("SimID", "WorldID", "Date");

                    b.HasIndex("WorldID");

                    b.ToTable("Travels");
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

            modelBuilder.Entity("Sims.Models.World", b =>
                {
                    b.Property<Guid>("WorldID")
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

                    b.HasKey("WorldID");

                    b.ToTable("Worlds");
                });

            modelBuilder.Entity("Sims.Models.Pet", b =>
                {
                    b.HasOne("Sims.Models.PetType", "Type")
                        .WithMany()
                        .HasForeignKey("TypeID");

                    b.Navigation("Type");
                });

            modelBuilder.Entity("Sims.Models.Relations.ActivityImprovesSkill", b =>
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

            modelBuilder.Entity("Sims.Models.Relations.Exercise", b =>
                {
                    b.HasOne("Sims.Models.Profession", "Profession")
                        .WithMany()
                        .HasForeignKey("ProfessionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sims.Models.Sim", "Sim")
                        .WithMany()
                        .HasForeignKey("SimID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Profession");

                    b.Navigation("Sim");
                });

            modelBuilder.Entity("Sims.Models.Relations.Involve", b =>
                {
                    b.HasOne("Sims.Models.Quest", "Quest")
                        .WithMany()
                        .HasForeignKey("QuestID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sims.Models.Relations.Travel", "Travel")
                        .WithMany()
                        .HasForeignKey("SimID", "WorldID", "Date")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Quest");

                    b.Navigation("Travel");
                });

            modelBuilder.Entity("Sims.Models.Relations.NeighborhoodDomesticUnits", b =>
                {
                    b.HasOne("Sims.Models.DomesticUnit", "DomesticUnit")
                        .WithMany()
                        .HasForeignKey("DomesticUnitID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sims.Models.Neighborhood", "Neighborhood")
                        .WithMany()
                        .HasForeignKey("NeighborhoodID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DomesticUnit");

                    b.Navigation("Neighborhood");
                });

            modelBuilder.Entity("Sims.Models.Relations.NeighborhoodPlaces", b =>
                {
                    b.HasOne("Sims.Models.Neighborhood", "Neighborhood")
                        .WithMany()
                        .HasForeignKey("NeighborhoodID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sims.Models.Place", "Place")
                        .WithMany()
                        .HasForeignKey("PlaceID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Neighborhood");

                    b.Navigation("Place");
                });

            modelBuilder.Entity("Sims.Models.Relations.NeighborhoodUpgradesSkill", b =>
                {
                    b.HasOne("Sims.Models.Neighborhood", "Neighborhood")
                        .WithMany()
                        .HasForeignKey("NeighborhoodID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sims.Models.Skill", "Skill")
                        .WithMany()
                        .HasForeignKey("SkillID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Neighborhood");

                    b.Navigation("Skill");
                });

            modelBuilder.Entity("Sims.Models.Relations.Perform", b =>
                {
                    b.HasOne("Sims.Models.Activity", "Activity")
                        .WithMany()
                        .HasForeignKey("ActivityID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sims.Models.Sim", "Sim")
                        .WithMany()
                        .HasForeignKey("SimID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Activity");

                    b.Navigation("Sim");
                });

            modelBuilder.Entity("Sims.Models.Relations.PetLives", b =>
                {
                    b.HasOne("Sims.Models.DomesticUnit", "DomesticUnit")
                        .WithMany()
                        .HasForeignKey("DomesticUnitID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sims.Models.Pet", "Pet")
                        .WithMany()
                        .HasForeignKey("PetID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DomesticUnit");

                    b.Navigation("Pet");
                });

            modelBuilder.Entity("Sims.Models.Relations.ProfessionUpgradesSkill", b =>
                {
                    b.HasOne("Sims.Models.Profession", "Profession")
                        .WithMany()
                        .HasForeignKey("ProfessionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sims.Models.Skill", "Skill")
                        .WithMany()
                        .HasForeignKey("SkillID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Profession");

                    b.Navigation("Skill");
                });

            modelBuilder.Entity("Sims.Models.Relations.QuestRequiresSkill", b =>
                {
                    b.HasOne("Sims.Models.Quest", "Quest")
                        .WithMany()
                        .HasForeignKey("QuestID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sims.Models.Skill", "Skill")
                        .WithMany()
                        .HasForeignKey("SkillID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Quest");

                    b.Navigation("Skill");
                });

            modelBuilder.Entity("Sims.Models.Relations.QuestWorld", b =>
                {
                    b.HasOne("Sims.Models.Quest", "Quest")
                        .WithMany()
                        .HasForeignKey("QuestID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sims.Models.World", "World")
                        .WithMany()
                        .HasForeignKey("WorldID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Quest");

                    b.Navigation("World");
                });

            modelBuilder.Entity("Sims.Models.Relations.SimLives", b =>
                {
                    b.HasOne("Sims.Models.DomesticUnit", "DomesticUnit")
                        .WithMany()
                        .HasForeignKey("DomesticUnitID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sims.Models.Sim", "Sim")
                        .WithMany()
                        .HasForeignKey("SimID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DomesticUnit");

                    b.Navigation("Sim");
                });

            modelBuilder.Entity("Sims.Models.Relations.SimSkills", b =>
                {
                    b.HasOne("Sims.Models.Sim", "Sim")
                        .WithMany()
                        .HasForeignKey("SimID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sims.Models.Skill", "Skill")
                        .WithMany()
                        .HasForeignKey("SkillID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sim");

                    b.Navigation("Skill");
                });

            modelBuilder.Entity("Sims.Models.Relations.Travel", b =>
                {
                    b.HasOne("Sims.Models.Sim", "Sim")
                        .WithMany()
                        .HasForeignKey("SimID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sims.Models.World", "World")
                        .WithMany()
                        .HasForeignKey("WorldID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sim");

                    b.Navigation("World");
                });
#pragma warning restore 612, 618
        }
    }
}
