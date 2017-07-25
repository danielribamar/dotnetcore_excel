using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using VolvoCleaner.Web.Frontend.Data;

namespace VolvoCleaner.Web.Frontend.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20170712230941_InitialCreate")]
    partial class InitialCreate
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

                    b.HasKey("Id");

                    b.ToTable("cleaner_files");
                });
        }
    }
}
