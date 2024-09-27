﻿// <auto-generated />
using System;
using Application;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Application.Migrations
{
    [DbContext(typeof(BarDbContext))]
    partial class BarDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.33");

            modelBuilder.Entity("Application.Models.Article", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ArticleGroupId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ArticleGroupId");

                    b.ToTable("Articles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ArticleGroupId = 1,
                            Name = "Beer",
                            Price = 3.50m
                        },
                        new
                        {
                            Id = 2,
                            ArticleGroupId = 1,
                            Name = "Wine",
                            Price = 4.50m
                        },
                        new
                        {
                            Id = 3,
                            ArticleGroupId = 1,
                            Name = "Soda",
                            Price = 2.00m
                        },
                        new
                        {
                            Id = 4,
                            ArticleGroupId = 2,
                            Name = "Pizza",
                            Price = 8.50m
                        },
                        new
                        {
                            Id = 5,
                            ArticleGroupId = 2,
                            Name = "Burger",
                            Price = 7.50m
                        },
                        new
                        {
                            Id = 6,
                            ArticleGroupId = 2,
                            Name = "Fries",
                            Price = 3.50m
                        },
                        new
                        {
                            Id = 7,
                            ArticleGroupId = 3,
                            Name = "Ice Cream",
                            Price = 4.50m
                        },
                        new
                        {
                            Id = 8,
                            ArticleGroupId = 3,
                            Name = "Cake",
                            Price = 5.50m
                        });
                });

            modelBuilder.Entity("Application.Models.ArticleGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("ArticleGroups");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Drinks"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Food"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Desserts"
                        });
                });

            modelBuilder.Entity("Application.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TableId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("TableId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Application.Models.OrderArticle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Amount")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ArticleId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("INTEGER");

                    b.Property<int>("OrderId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ArticleId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderArticles");
                });

            modelBuilder.Entity("Application.Models.Table", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("X")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Y")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Tables");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Table 1",
                            X = 0,
                            Y = 0
                        },
                        new
                        {
                            Id = 2,
                            Name = "Table 2",
                            X = 100,
                            Y = 150
                        },
                        new
                        {
                            Id = 3,
                            Name = "Table 3",
                            X = 200,
                            Y = 300
                        },
                        new
                        {
                            Id = 4,
                            Name = "Table 4",
                            X = 300,
                            Y = 450
                        },
                        new
                        {
                            Id = 5,
                            Name = "Table 5",
                            X = 400,
                            Y = 600
                        },
                        new
                        {
                            Id = 6,
                            Name = "Table 6",
                            X = 500,
                            Y = 750
                        },
                        new
                        {
                            Id = 7,
                            Name = "Table 7",
                            X = 600,
                            Y = 900
                        },
                        new
                        {
                            Id = 8,
                            Name = "Table 8",
                            X = 700,
                            Y = 1050
                        });
                });

            modelBuilder.Entity("Application.Models.Article", b =>
                {
                    b.HasOne("Application.Models.ArticleGroup", "ArticleGroup")
                        .WithMany("Articles")
                        .HasForeignKey("ArticleGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ArticleGroup");
                });

            modelBuilder.Entity("Application.Models.Order", b =>
                {
                    b.HasOne("Application.Models.Table", "Table")
                        .WithMany()
                        .HasForeignKey("TableId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Table");
                });

            modelBuilder.Entity("Application.Models.OrderArticle", b =>
                {
                    b.HasOne("Application.Models.Article", "Article")
                        .WithMany()
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Application.Models.Order", "Order")
                        .WithMany("OrderArticles")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Article");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("Application.Models.ArticleGroup", b =>
                {
                    b.Navigation("Articles");
                });

            modelBuilder.Entity("Application.Models.Order", b =>
                {
                    b.Navigation("OrderArticles");
                });
#pragma warning restore 612, 618
        }
    }
}
