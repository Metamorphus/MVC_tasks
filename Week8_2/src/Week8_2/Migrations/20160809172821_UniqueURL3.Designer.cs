using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Week8_2.Models;

namespace Week8_2.Migrations
{
    [DbContext(typeof(CmsContext))]
    [Migration("20160809172821_UniqueURL3")]
    partial class UniqueURL3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431");

            modelBuilder.Entity("Week8_2.Models.NavLink", b =>
                {
                    b.Property<int>("NavLinkId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("PageId");

                    b.Property<int>("ParentPageId");

                    b.Property<int>("Position");

                    b.Property<string>("Title");

                    b.HasKey("NavLinkId");

                    b.HasIndex("PageId");

                    b.HasIndex("ParentPageId");

                    b.ToTable("Links");
                });

            modelBuilder.Entity("Week8_2.Models.Page", b =>
                {
                    b.Property<int>("PageId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("AddedDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("DATE()");

                    b.Property<string>("Content")
                        .IsRequired();

                    b.Property<string>("Description");

                    b.Property<string>("Title");

                    b.Property<string>("UrlName")
                        .IsRequired();

                    b.HasKey("PageId");

                    b.ToTable("Pages");
                });

            modelBuilder.Entity("Week8_2.Models.RelatedPage", b =>
                {
                    b.Property<int>("RelationId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("FirstPageId");

                    b.Property<int>("SecondPageId");

                    b.HasKey("RelationId");

                    b.HasIndex("FirstPageId");

                    b.HasIndex("SecondPageId");

                    b.ToTable("RelatedPages");
                });

            modelBuilder.Entity("Week8_2.Models.NavLink", b =>
                {
                    b.HasOne("Week8_2.Models.Page", "Page")
                        .WithMany("IncomingLinks")
                        .HasForeignKey("PageId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Week8_2.Models.Page", "ParentPage")
                        .WithMany("OutcomingLinks")
                        .HasForeignKey("ParentPageId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Week8_2.Models.RelatedPage", b =>
                {
                    b.HasOne("Week8_2.Models.Page", "FirstPage")
                        .WithMany("OutcomingRelations")
                        .HasForeignKey("FirstPageId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Week8_2.Models.Page", "SecondPage")
                        .WithMany("IncomingRelations")
                        .HasForeignKey("SecondPageId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
