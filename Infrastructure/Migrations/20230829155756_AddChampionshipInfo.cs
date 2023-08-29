using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddChampionshipInfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ChampionshipId",
                table: "Matches",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Championship",
                columns: table => new
                {
                    ChampionshipId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Championship", x => x.ChampionshipId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ChampionshipContestant",
                columns: table => new
                {
                    ChampionshipsChampionshipId = table.Column<int>(type: "int", nullable: false),
                    ContestantsContestantId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChampionshipContestant", x => new { x.ChampionshipsChampionshipId, x.ContestantsContestantId });
                    table.ForeignKey(
                        name: "FK_ChampionshipContestant_Championship_ChampionshipsChampionshi~",
                        column: x => x.ChampionshipsChampionshipId,
                        principalTable: "Championship",
                        principalColumn: "ChampionshipId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChampionshipContestant_Contestants_ContestantsContestantId",
                        column: x => x.ContestantsContestantId,
                        principalTable: "Contestants",
                        principalColumn: "ContestantId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_ChampionshipId",
                table: "Matches",
                column: "ChampionshipId");

            migrationBuilder.CreateIndex(
                name: "IX_ChampionshipContestant_ContestantsContestantId",
                table: "ChampionshipContestant",
                column: "ContestantsContestantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Championship_ChampionshipId",
                table: "Matches",
                column: "ChampionshipId",
                principalTable: "Championship",
                principalColumn: "ChampionshipId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Championship_ChampionshipId",
                table: "Matches");

            migrationBuilder.DropTable(
                name: "ChampionshipContestant");

            migrationBuilder.DropTable(
                name: "Championship");

            migrationBuilder.DropIndex(
                name: "IX_Matches_ChampionshipId",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "ChampionshipId",
                table: "Matches");
        }
    }
}
