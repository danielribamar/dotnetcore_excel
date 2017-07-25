using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using VolvoCleaner.Web.Frontend.Data;

namespace VolvoCleaner.Web.Frontend.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20170714192216_filetype")]
    partial class filetype
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("VolvoCleaner.Web.Frontend.Models.FileModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("LogUrl");

                    b.Property<string>("Name");

                    b.Property<string>("OriginalUrl");

                    b.Property<string>("ProcessedUrl");

                    b.Property<int>("TypeId");

                    b.HasKey("Id");

                    b.HasIndex("TypeId");

                    b.ToTable("cleaner_files");
                });

            modelBuilder.Entity("VolvoCleaner.Web.Frontend.Models.FileTypeModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("cleaner_filetypes");
                });

            modelBuilder.Entity("VolvoCleaner.Web.Frontend.Models.FileModel", b =>
                {
                    b.HasOne("VolvoCleaner.Web.Frontend.Models.FileTypeModel", "Type")
                        .WithMany("Files")
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
