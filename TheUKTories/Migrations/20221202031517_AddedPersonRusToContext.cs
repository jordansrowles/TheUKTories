using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheUKTories.Migrations
{
    public partial class AddedPersonRusToContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PersonRusCxn",
                columns: table => new
                {
                    PersonRusCxnId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonRusCxn", x => x.PersonRusCxnId);
                    table.ForeignKey(
                        name: "FK_PersonRusCxn_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonRusCxnSource",
                columns: table => new
                {
                    PersonRusCxnSourceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonRusCxnId = table.Column<int>(type: "int", nullable: false),
                    Source = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonRusCxnSource", x => x.PersonRusCxnSourceId);
                    table.ForeignKey(
                        name: "FK_PersonRusCxnSource_PersonRusCxn_PersonRusCxnId",
                        column: x => x.PersonRusCxnId,
                        principalTable: "PersonRusCxn",
                        principalColumn: "PersonRusCxnId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonRusCxn_PersonId",
                table: "PersonRusCxn",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonRusCxnSource_PersonRusCxnId",
                table: "PersonRusCxnSource",
                column: "PersonRusCxnId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonRusCxnSource");

            migrationBuilder.DropTable(
                name: "PersonRusCxn");
        }
    }
}
