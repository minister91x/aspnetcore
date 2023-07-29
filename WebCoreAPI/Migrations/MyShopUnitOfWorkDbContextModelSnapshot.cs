﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebCoreAPI.EntitiesFrameWork.Dbcontext;

#nullable disable

namespace WebCoreAPI.Migrations
{
    [DbContext(typeof(MyShopUnitOfWorkDbContext))]
    partial class MyShopUnitOfWorkDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("WebCoreAPI.EntitiesFrameWork.Entities.Product", b =>
                {
                    b.Property<string>("MaSP")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("DonGia")
                        .HasColumnType("int");

                    b.Property<string>("DonViTinh")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenSP")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaSP");

                    b.ToTable("sanpham");
                });
#pragma warning restore 612, 618
        }
    }
}