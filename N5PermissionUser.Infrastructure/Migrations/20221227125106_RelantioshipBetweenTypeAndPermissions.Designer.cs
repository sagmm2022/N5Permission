﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using N5PermissionUser.Infrastructure;

#nullable disable

namespace N5PermissionUser.Infrastructure.Migrations
{
    [DbContext(typeof(N5PermissionUserContext))]
    [Migration("20221227125106_RelantioshipBetweenTypeAndPermissions")]
    partial class RelantioshipBetweenTypeAndPermissions
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("N5PermissionUser.Domain.Entities.PermissionsEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("DateOfPermission")
                        .HasColumnType("datetime")
                        .HasColumnName("DateOfPermission");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasColumnName("FirstName");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasColumnName("LastName");

                    b.Property<long>("TypeId")
                        .HasColumnType("bigint")
                        .HasColumnName("TypeId");

                    b.HasKey("Id");

                    b.HasIndex("TypeId");

                    b.ToTable("Permission", "dbo");
                });

            modelBuilder.Entity("N5PermissionUser.Domain.Entities.TypeEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasColumnName("Description");

                    b.HasKey("Id");

                    b.ToTable("TypeEntity", "dbo");
                });

            modelBuilder.Entity("N5PermissionUser.Domain.Entities.PermissionsEntity", b =>
                {
                    b.HasOne("N5PermissionUser.Domain.Entities.TypeEntity", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Type");
                });
        }
    }
}
