// <auto-generated />
using System;
using Api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Api.Migrations
{
    [DbContext(typeof(QlreportContext))]
    [Migration("20220208015937_report-api")]
    partial class reportapi
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AccountGroup", b =>
                {
                    b.Property<string>("AccountId")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("GroupId")
                        .HasColumnType("int");

                    b.HasKey("AccountId", "GroupId");

                    b.HasIndex("GroupId");

                    b.ToTable("Account_Group", (string)null);
                });

            modelBuilder.Entity("Api.Models.Account", b =>
                {
                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Fullname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Email");

                    b.HasIndex("RoleId");

                    b.ToTable("Account");
                });

            modelBuilder.Entity("Api.Models.CouncilEvaluation", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Description")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("GroupId")
                        .HasColumnType("int");

                    b.Property<double>("Point")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.ToTable("CouncilEvaluation");
                });

            modelBuilder.Entity("Api.Models.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("ProjetId")
                        .HasColumnType("int");

                    b.Property<string>("Semester")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProjetId");

                    b.ToTable("Group");
                });

            modelBuilder.Entity("Api.Models.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Project");
                });

            modelBuilder.Entity("Api.Models.Report", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Report");
                });

            modelBuilder.Entity("Api.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("Api.Models.Submit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<int>("ReportId")
                        .HasColumnType("int");

                    b.Property<string>("ReportUrl")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<DateTime>("SubmitTime")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.HasIndex("ReportId");

                    b.ToTable("Submit");
                });

            modelBuilder.Entity("Api.Models.TeacherEvaluation", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Description")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<double>("Point")
                        .HasColumnType("float");

                    b.Property<int>("SubmitId")
                        .HasColumnType("int");

                    b.Property<string>("TeacherId")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("SubmitId");

                    b.HasIndex("TeacherId");

                    b.ToTable("TeacherEvaluation");
                });

            modelBuilder.Entity("AccountGroup", b =>
                {
                    b.HasOne("Api.Models.Account", null)
                        .WithMany()
                        .HasForeignKey("AccountId")
                        .IsRequired()
                        .HasConstraintName("FK_Account_Group_Account");

                    b.HasOne("Api.Models.Group", null)
                        .WithMany()
                        .HasForeignKey("GroupId")
                        .IsRequired()
                        .HasConstraintName("FK_Account_Group_Group");
                });

            modelBuilder.Entity("Api.Models.Account", b =>
                {
                    b.HasOne("Api.Models.Role", "Role")
                        .WithMany("Accounts")
                        .HasForeignKey("RoleId")
                        .IsRequired()
                        .HasConstraintName("FK_Account_Role");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Api.Models.CouncilEvaluation", b =>
                {
                    b.HasOne("Api.Models.Group", "Group")
                        .WithMany("CouncilEvaluations")
                        .HasForeignKey("GroupId")
                        .IsRequired()
                        .HasConstraintName("FK_CouncilEvaluation_Group");

                    b.Navigation("Group");
                });

            modelBuilder.Entity("Api.Models.Group", b =>
                {
                    b.HasOne("Api.Models.Project", "Projet")
                        .WithMany("Groups")
                        .HasForeignKey("ProjetId")
                        .HasConstraintName("FK_Group_Project");

                    b.Navigation("Projet");
                });

            modelBuilder.Entity("Api.Models.Submit", b =>
                {
                    b.HasOne("Api.Models.Project", "Project")
                        .WithMany("Submits")
                        .HasForeignKey("ProjectId")
                        .IsRequired()
                        .HasConstraintName("FK_Submit_Project");

                    b.HasOne("Api.Models.Report", "Report")
                        .WithMany("Submits")
                        .HasForeignKey("ReportId")
                        .IsRequired()
                        .HasConstraintName("FK_Submit_Report");

                    b.Navigation("Project");

                    b.Navigation("Report");
                });

            modelBuilder.Entity("Api.Models.TeacherEvaluation", b =>
                {
                    b.HasOne("Api.Models.Submit", "Submit")
                        .WithMany("TeacherEvaluations")
                        .HasForeignKey("SubmitId")
                        .IsRequired()
                        .HasConstraintName("FK_TeacherEvaluation_Submit");

                    b.HasOne("Api.Models.Account", "Teacher")
                        .WithMany("TeacherEvaluations")
                        .HasForeignKey("TeacherId")
                        .IsRequired()
                        .HasConstraintName("FK_TeacherEvaluation_Account");

                    b.Navigation("Submit");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("Api.Models.Account", b =>
                {
                    b.Navigation("TeacherEvaluations");
                });

            modelBuilder.Entity("Api.Models.Group", b =>
                {
                    b.Navigation("CouncilEvaluations");
                });

            modelBuilder.Entity("Api.Models.Project", b =>
                {
                    b.Navigation("Groups");

                    b.Navigation("Submits");
                });

            modelBuilder.Entity("Api.Models.Report", b =>
                {
                    b.Navigation("Submits");
                });

            modelBuilder.Entity("Api.Models.Role", b =>
                {
                    b.Navigation("Accounts");
                });

            modelBuilder.Entity("Api.Models.Submit", b =>
                {
                    b.Navigation("TeacherEvaluations");
                });
#pragma warning restore 612, 618
        }
    }
}
