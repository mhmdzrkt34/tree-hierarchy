﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using binaryTree.data;

#nullable disable

namespace binaryTree.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240611173901_add-migratin start")]
    partial class addmigratinstart
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("binaryTree.models.Category", b =>
                {
                    b.Property<string>("id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("parent_id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("time")
                        .HasColumnType("datetime2");

                    b.HasKey("id");

                    b.HasIndex("parent_id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("binaryTree.models.Category", b =>
                {
                    b.HasOne("binaryTree.models.Category", "parentCategory")
                        .WithMany("subCategories")
                        .HasForeignKey("parent_id")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("parentCategory");
                });

            modelBuilder.Entity("binaryTree.models.Category", b =>
                {
                    b.Navigation("subCategories");
                });
#pragma warning restore 612, 618
        }
    }
}
