﻿// <auto-generated />
using System;
using Festispec.Api.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Festispec.Api.Migrations
{
    [DbContext(typeof(FestispecContext))]
    partial class FestispecContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.3-rtm-32065")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Festispec.Database.Models.Form", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comments");

                    b.Property<bool>("IsTemplate");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Forms");
                });

            modelBuilder.Entity("Festispec.Database.Models.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<int?>("FormId");

                    b.Property<int>("QuestionType");

                    b.Property<string>("Text");

                    b.HasKey("Id");

                    b.HasIndex("FormId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("Festispec.Database.Models.QuestionItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Body");

                    b.Property<int?>("QuestionId");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.ToTable("QuestionItems");
                });

            modelBuilder.Entity("Festispec.Database.Models.Question", b =>
                {
                    b.HasOne("Festispec.Database.Models.Form", "Form")
                        .WithMany("Question")
                        .HasForeignKey("FormId");
                });

            modelBuilder.Entity("Festispec.Database.Models.QuestionItem", b =>
                {
                    b.HasOne("Festispec.Database.Models.Question", "Question")
                        .WithMany("QuestionItem")
                        .HasForeignKey("QuestionId");
                });
#pragma warning restore 612, 618
        }
    }
}
