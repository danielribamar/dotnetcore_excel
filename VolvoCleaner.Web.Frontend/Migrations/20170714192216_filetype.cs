using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace VolvoCleaner.Web.Frontend.Migrations
{
    public partial class filetype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TypeId",
                table: "cleaner_files",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "cleaner_filetypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cleaner_filetypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_cleaner_files_TypeId",
                table: "cleaner_files",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_cleaner_files_cleaner_filetypes_TypeId",
                table: "cleaner_files",
                column: "TypeId",
                principalTable: "cleaner_filetypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cleaner_files_cleaner_filetypes_TypeId",
                table: "cleaner_files");

            migrationBuilder.DropTable(
                name: "cleaner_filetypes");

            migrationBuilder.DropIndex(
                name: "IX_cleaner_files_TypeId",
                table: "cleaner_files");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "cleaner_files");
        }
    }
}
