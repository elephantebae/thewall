﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using thewall.Models;

namespace thewall.Migrations
{
    [DbContext(typeof(WallContext))]
    [Migration("20181213194543_first")]
    partial class first
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("thewall.Models.Comment", b =>
                {
                    b.Property<int>("CommentId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Cmt");

                    b.Property<int>("MessageId");

                    b.Property<int>("UserId");

                    b.Property<DateTime>("created_at");

                    b.Property<DateTime>("updated_at");

                    b.HasKey("CommentId");

                    b.HasIndex("UserId");

                    b.ToTable("comments");
                });

            modelBuilder.Entity("thewall.Models.Message", b =>
                {
                    b.Property<int>("MessageId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Msg");

                    b.Property<int>("UserId");

                    b.Property<DateTime>("created_at");

                    b.Property<DateTime>("updatedat");

                    b.HasKey("MessageId");

                    b.HasIndex("UserId");

                    b.ToTable("messages");
                });

            modelBuilder.Entity("thewall.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("UserId");

                    b.ToTable("users");
                });

            modelBuilder.Entity("thewall.Models.Comment", b =>
                {
                    b.HasOne("thewall.Models.User")
                        .WithMany("Comments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("thewall.Models.Message", b =>
                {
                    b.HasOne("thewall.Models.User")
                        .WithMany("Messages")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
