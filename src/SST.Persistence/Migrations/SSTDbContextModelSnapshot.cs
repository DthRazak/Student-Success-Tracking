﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SST.Persistence;

namespace SST.Persistence.Migrations
{
    [DbContext(typeof(SSTDbContext))]
    partial class SSTDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SST.Domain.Entities.Grade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("JournalColumnRef")
                        .HasColumnType("int");

                    b.Property<int>("Mark")
                        .HasColumnType("int");

                    b.Property<int>("StudentRef")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("JournalColumnRef");

                    b.HasIndex("StudentRef");

                    b.ToTable("Grades");
                });

            modelBuilder.Entity("SST.Domain.Entities.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Faculty")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsMain")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("SST.Domain.Entities.GroupSubject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("GroupRef")
                        .HasColumnType("int");

                    b.Property<int>("SubjectRef")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GroupRef");

                    b.HasIndex("SubjectRef");

                    b.ToTable("GroupSubjects");
                });

            modelBuilder.Entity("SST.Domain.Entities.JournalColumn", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("GroupSubjectRef")
                        .HasColumnType("int");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GroupSubjectRef");

                    b.ToTable("JournalColumns");
                });

            modelBuilder.Entity("SST.Domain.Entities.Lector", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AcademicStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserRef")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserRef")
                        .IsUnique()
                        .HasFilter("[UserRef] IS NOT NULL");

                    b.ToTable("Lectors");
                });

            modelBuilder.Entity("SST.Domain.Entities.Request", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("IsApproved")
                        .HasColumnType("bit");

                    b.Property<string>("UserRef")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserRef")
                        .IsUnique();

                    b.ToTable("Requests");
                });

            modelBuilder.Entity("SST.Domain.Entities.SecondaryGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("GroupRef")
                        .HasColumnType("int");

                    b.Property<int>("StudentRef")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GroupRef");

                    b.HasIndex("StudentRef");

                    b.ToTable("SecondaryGroups");
                });

            modelBuilder.Entity("SST.Domain.Entities.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("GroupRef")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserRef")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("GroupRef");

                    b.HasIndex("UserRef")
                        .IsUnique()
                        .HasFilter("[UserRef] IS NOT NULL");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("SST.Domain.Entities.Subject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("LectorRef")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LectorRef");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("SST.Domain.Entities.User", b =>
                {
                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varchar(256)");

                    b.HasKey("Email");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SST.Domain.Entities.Grade", b =>
                {
                    b.HasOne("SST.Domain.Entities.JournalColumn", "JournalColumn")
                        .WithMany("Grades")
                        .HasForeignKey("JournalColumnRef")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SST.Domain.Entities.Student", "Student")
                        .WithMany("Grades")
                        .HasForeignKey("StudentRef")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SST.Domain.Entities.GroupSubject", b =>
                {
                    b.HasOne("SST.Domain.Entities.Group", "Group")
                        .WithMany("GroupSubjects")
                        .HasForeignKey("GroupRef")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SST.Domain.Entities.Subject", "Subject")
                        .WithMany("GroupSubjects")
                        .HasForeignKey("SubjectRef")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SST.Domain.Entities.JournalColumn", b =>
                {
                    b.HasOne("SST.Domain.Entities.GroupSubject", "GroupSubject")
                        .WithMany("Journal")
                        .HasForeignKey("GroupSubjectRef")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SST.Domain.Entities.Lector", b =>
                {
                    b.HasOne("SST.Domain.Entities.User", "User")
                        .WithOne("Lector")
                        .HasForeignKey("SST.Domain.Entities.Lector", "UserRef")
                        .OnDelete(DeleteBehavior.SetNull);
                });

            modelBuilder.Entity("SST.Domain.Entities.Request", b =>
                {
                    b.HasOne("SST.Domain.Entities.User", "User")
                        .WithOne("Request")
                        .HasForeignKey("SST.Domain.Entities.Request", "UserRef")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SST.Domain.Entities.SecondaryGroup", b =>
                {
                    b.HasOne("SST.Domain.Entities.Group", "Group")
                        .WithMany("SecondaryGroups")
                        .HasForeignKey("GroupRef")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SST.Domain.Entities.Student", "Student")
                        .WithMany("SecondaryGroups")
                        .HasForeignKey("StudentRef")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SST.Domain.Entities.Student", b =>
                {
                    b.HasOne("SST.Domain.Entities.Group", "Group")
                        .WithMany("Students")
                        .HasForeignKey("GroupRef")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("SST.Domain.Entities.User", "User")
                        .WithOne("Student")
                        .HasForeignKey("SST.Domain.Entities.Student", "UserRef")
                        .OnDelete(DeleteBehavior.SetNull);
                });

            modelBuilder.Entity("SST.Domain.Entities.Subject", b =>
                {
                    b.HasOne("SST.Domain.Entities.Lector", "Lector")
                        .WithMany("Subjects")
                        .HasForeignKey("LectorRef")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
