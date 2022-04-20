﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StrShop.Data;

namespace StrShop.Migrations
{
    [DbContext(typeof(DBconnection))]
    [Migration("20220406164459_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("StrShop.Data.Models.Category", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryName");

                    b.HasKey("id");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("StrShop.Data.Models.Item", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId");

                    b.Property<string>("Description");

                    b.Property<string>("ItemName");

                    b.Property<int>("ProducerId");

                    b.Property<int>("StorageId");

                    b.Property<string>("img");

                    b.Property<int>("price");

                    b.HasKey("id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ProducerId");

                    b.HasIndex("StorageId");

                    b.ToTable("Item");
                });

            modelBuilder.Entity("StrShop.Data.Models.Producer", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ProducerDesc");

                    b.Property<string>("ProducerName");

                    b.HasKey("id");

                    b.ToTable("Producer");
                });

            modelBuilder.Entity("StrShop.Data.Models.Storage", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Delivery");

                    b.Property<string>("StorageAddress");

                    b.HasKey("id");

                    b.ToTable("Storage");
                });

            modelBuilder.Entity("StrShop.Data.Models.Item", b =>
                {
                    b.HasOne("StrShop.Data.Models.Category", "Category")
                        .WithMany("Items")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("StrShop.Data.Models.Producer", "Producer")
                        .WithMany("Items")
                        .HasForeignKey("ProducerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("StrShop.Data.Models.Storage", "Storage")
                        .WithMany("Items")
                        .HasForeignKey("StorageId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
