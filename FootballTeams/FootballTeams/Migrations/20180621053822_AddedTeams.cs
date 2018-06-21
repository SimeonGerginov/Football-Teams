using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FootballTeams.Migrations
{
    public partial class AddedTeams : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TeamId",
                table: "FootballPlayers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TeamId",
                table: "FootballManagers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Alias = table.Column<string>(maxLength: 30, nullable: false),
                    Captain = table.Column<string>(maxLength: 30, nullable: false),
                    CityId = table.Column<int>(nullable: true),
                    CountryId = table.Column<int>(nullable: true),
                    Division = table.Column<string>(maxLength: 15, nullable: false),
                    Established = table.Column<int>(nullable: false),
                    FootballPresidentId = table.Column<int>(nullable: true),
                    LostMatches = table.Column<int>(nullable: true),
                    Name = table.Column<string>(maxLength: 30, nullable: false),
                    PlayedMatches = table.Column<int>(nullable: true),
                    Region = table.Column<string>(maxLength: 20, nullable: false),
                    StadiumId = table.Column<int>(nullable: true),
                    Trophies = table.Column<int>(nullable: true),
                    WonMatches = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teams_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Teams_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Teams_FootballPresidents_FootballPresidentId",
                        column: x => x.FootballPresidentId,
                        principalTable: "FootballPresidents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Teams_Stadiums_StadiumId",
                        column: x => x.StadiumId,
                        principalTable: "Stadiums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FootballPlayers_TeamId",
                table: "FootballPlayers",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_FootballManagers_TeamId",
                table: "FootballManagers",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_CityId",
                table: "Teams",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_CountryId",
                table: "Teams",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_FootballPresidentId",
                table: "Teams",
                column: "FootballPresidentId");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_StadiumId",
                table: "Teams",
                column: "StadiumId");

            migrationBuilder.AddForeignKey(
                name: "FK_FootballManagers_Teams_TeamId",
                table: "FootballManagers",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FootballPlayers_Teams_TeamId",
                table: "FootballPlayers",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FootballManagers_Teams_TeamId",
                table: "FootballManagers");

            migrationBuilder.DropForeignKey(
                name: "FK_FootballPlayers_Teams_TeamId",
                table: "FootballPlayers");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_FootballPlayers_TeamId",
                table: "FootballPlayers");

            migrationBuilder.DropIndex(
                name: "IX_FootballManagers_TeamId",
                table: "FootballManagers");

            migrationBuilder.DropColumn(
                name: "TeamId",
                table: "FootballPlayers");

            migrationBuilder.DropColumn(
                name: "TeamId",
                table: "FootballManagers");
        }
    }
}
