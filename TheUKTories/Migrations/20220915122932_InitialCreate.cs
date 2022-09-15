using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheUKTories.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    ContactId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.ContactId);
                });

            migrationBuilder.CreateTable(
                name: "CovidGovContractCompanies",
                columns: table => new
                {
                    GovPPEContractCompanyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MainPerson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Founded = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CovidGovContractCompanies", x => x.GovPPEContractCompanyId);
                });

            migrationBuilder.CreateTable(
                name: "CovidGovResponses",
                columns: table => new
                {
                    CovidGovResponseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CovidGovResponses", x => x.CovidGovResponseId);
                });

            migrationBuilder.CreateTable(
                name: "FacistTactics",
                columns: table => new
                {
                    FacistTacticId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subtitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacistTactics", x => x.FacistTacticId);
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    PersonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PoliticalParty = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CurrentTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Titles = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfileImageBlobUri = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsProfilePublic = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.PersonId);
                });

            migrationBuilder.CreateTable(
                name: "UKAusterityMeasures",
                columns: table => new
                {
                    UKAusterityMeasureId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UKAusterityMeasures", x => x.UKAusterityMeasureId);
                });

            migrationBuilder.CreateTable(
                name: "CovidGovContracts",
                columns: table => new
                {
                    GovPPEContractId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GovPPEContractCompanyId = table.Column<int>(type: "int", nullable: false),
                    Source = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Reference = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cost = table.Column<double>(type: "float", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CovidGovContracts", x => x.GovPPEContractId);
                    table.ForeignKey(
                        name: "FK_CovidGovContracts_CovidGovContractCompanies_GovPPEContractCompanyId",
                        column: x => x.GovPPEContractCompanyId,
                        principalTable: "CovidGovContractCompanies",
                        principalColumn: "GovPPEContractCompanyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CovidGovResponseSources",
                columns: table => new
                {
                    CovidGovResponseSourceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CovidGovResponseId = table.Column<int>(type: "int", nullable: false),
                    Source = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CovidGovResponseSources", x => x.CovidGovResponseSourceId);
                    table.ForeignKey(
                        name: "FK_CovidGovResponseSources_CovidGovResponses_CovidGovResponseId",
                        column: x => x.CovidGovResponseId,
                        principalTable: "CovidGovResponses",
                        principalColumn: "CovidGovResponseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PeopleGeneral",
                columns: table => new
                {
                    PersonGeneralId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubTitle = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeopleGeneral", x => x.PersonGeneralId);
                    table.ForeignKey(
                        name: "FK_PeopleGeneral_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PeopleQuotes",
                columns: table => new
                {
                    PersonQuoteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    Quote = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeopleQuotes", x => x.PersonQuoteId);
                    table.ForeignKey(
                        name: "FK_PeopleQuotes_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UKAusterityMeasuresSources",
                columns: table => new
                {
                    UKAusterityMeasureSourceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UKAusterityMeasureId = table.Column<int>(type: "int", nullable: false),
                    Source = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UKAusterityMeasuresSources", x => x.UKAusterityMeasureSourceId);
                    table.ForeignKey(
                        name: "FK_UKAusterityMeasuresSources_UKAusterityMeasures_UKAusterityMeasureId",
                        column: x => x.UKAusterityMeasureId,
                        principalTable: "UKAusterityMeasures",
                        principalColumn: "UKAusterityMeasureId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonGeneralSources",
                columns: table => new
                {
                    PersonGeneralSourceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonGeneralId = table.Column<int>(type: "int", nullable: false),
                    Source = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonGeneralSources", x => x.PersonGeneralSourceId);
                    table.ForeignKey(
                        name: "FK_PersonGeneralSources_PeopleGeneral_PersonGeneralId",
                        column: x => x.PersonGeneralId,
                        principalTable: "PeopleGeneral",
                        principalColumn: "PersonGeneralId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonQuoteSources",
                columns: table => new
                {
                    PersonQuoteSourceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonQuoteId = table.Column<int>(type: "int", nullable: false),
                    Source = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonQuoteSources", x => x.PersonQuoteSourceId);
                    table.ForeignKey(
                        name: "FK_PersonQuoteSources_PeopleQuotes_PersonQuoteId",
                        column: x => x.PersonQuoteId,
                        principalTable: "PeopleQuotes",
                        principalColumn: "PersonQuoteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CovidGovContracts_GovPPEContractCompanyId",
                table: "CovidGovContracts",
                column: "GovPPEContractCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_CovidGovResponseSources_CovidGovResponseId",
                table: "CovidGovResponseSources",
                column: "CovidGovResponseId");

            migrationBuilder.CreateIndex(
                name: "IX_PeopleGeneral_PersonId",
                table: "PeopleGeneral",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_PeopleQuotes_PersonId",
                table: "PeopleQuotes",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonGeneralSources_PersonGeneralId",
                table: "PersonGeneralSources",
                column: "PersonGeneralId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonQuoteSources_PersonQuoteId",
                table: "PersonQuoteSources",
                column: "PersonQuoteId");

            migrationBuilder.CreateIndex(
                name: "IX_UKAusterityMeasuresSources_UKAusterityMeasureId",
                table: "UKAusterityMeasuresSources",
                column: "UKAusterityMeasureId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "CovidGovContracts");

            migrationBuilder.DropTable(
                name: "CovidGovResponseSources");

            migrationBuilder.DropTable(
                name: "FacistTactics");

            migrationBuilder.DropTable(
                name: "PersonGeneralSources");

            migrationBuilder.DropTable(
                name: "PersonQuoteSources");

            migrationBuilder.DropTable(
                name: "UKAusterityMeasuresSources");

            migrationBuilder.DropTable(
                name: "CovidGovContractCompanies");

            migrationBuilder.DropTable(
                name: "CovidGovResponses");

            migrationBuilder.DropTable(
                name: "PeopleGeneral");

            migrationBuilder.DropTable(
                name: "PeopleQuotes");

            migrationBuilder.DropTable(
                name: "UKAusterityMeasures");

            migrationBuilder.DropTable(
                name: "People");
        }
    }
}
