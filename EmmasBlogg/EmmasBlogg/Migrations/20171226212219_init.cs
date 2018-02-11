using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace EmmasBlogg.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Användare",
                columns: table => new
                {
                    AnvändarID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Efternamn = table.Column<string>(nullable: true),
                    Epostadress = table.Column<string>(nullable: true),
                    Namn = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnvändarID", x => x.AnvändarID);
                });

            migrationBuilder.CreateTable(
                name: "Kategori",
                columns: table => new
                {
                    KategoriID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Namn = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KategoriID", x => x.KategoriID);
                });

            migrationBuilder.CreateTable(
                name: "Poster",
                columns: table => new
                {
                    InläggsID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AnvändareAnvändarID = table.Column<int>(nullable: true),
                    Datum = table.Column<DateTime>(nullable: false),
                    KategoriID = table.Column<int>(nullable: true),
                    Text = table.Column<string>(nullable: true),
                    Titel = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InläggsID", x => x.InläggsID);
                    table.ForeignKey(
                        name: "FK_Poster_Användare_AnvändareAnvändarID",
                        column: x => x.AnvändareAnvändarID,
                        principalTable: "Användare",
                        principalColumn: "AnvändarID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Poster_Kategori_KategoriID",
                        column: x => x.KategoriID,
                        principalTable: "Kategori",
                        principalColumn: "KategoriID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Poster_AnvändareAnvändarID",
                table: "Poster",
                column: "AnvändareAnvändarID");

            migrationBuilder.CreateIndex(
                name: "IX_Poster_KategoriID",
                table: "Poster",
                column: "KategoriID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Poster");

            migrationBuilder.DropTable(
                name: "Användare");

            migrationBuilder.DropTable(
                name: "Kategori");
        }
    }
}
