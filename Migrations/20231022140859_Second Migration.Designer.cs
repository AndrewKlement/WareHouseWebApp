﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MiniProject_IT_DIV.DB;

#nullable disable

namespace MiniProject_IT_DIV.Migrations
{
    [DbContext(typeof(Db_Cntx))]
    [Migration("20231022140859_Second Migration")]
    partial class SecondMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MiniProject_IT_DIV.Models.DBmodels.Category", b =>
                {
                    b.Property<int>("Category_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Category_Id"));

                    b.Property<string>("Category_Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Category_Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("MiniProject_IT_DIV.Models.DBmodels.Person", b =>
                {
                    b.Property<int>("User_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("User_Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("User_Id");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("MiniProject_IT_DIV.Models.DBmodels.PersonCategory", b =>
                {
                    b.Property<int>("PersonCategory_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PersonCategory_Id"));

                    b.Property<int>("Category_Id")
                        .HasColumnType("int");

                    b.Property<int>("User_Id")
                        .HasColumnType("int");

                    b.HasKey("PersonCategory_Id");

                    b.HasIndex("Category_Id");

                    b.HasIndex("User_Id");

                    b.ToTable("PersonCategories");
                });

            modelBuilder.Entity("MiniProject_IT_DIV.Models.DBmodels.PersonCategory", b =>
                {
                    b.HasOne("MiniProject_IT_DIV.Models.DBmodels.Category", "Category")
                        .WithMany("PersonCategories")
                        .HasForeignKey("Category_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MiniProject_IT_DIV.Models.DBmodels.Person", "Person")
                        .WithMany("PersonCategories")
                        .HasForeignKey("User_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("MiniProject_IT_DIV.Models.DBmodels.Category", b =>
                {
                    b.Navigation("PersonCategories");
                });

            modelBuilder.Entity("MiniProject_IT_DIV.Models.DBmodels.Person", b =>
                {
                    b.Navigation("PersonCategories");
                });
#pragma warning restore 612, 618
        }
    }
}
