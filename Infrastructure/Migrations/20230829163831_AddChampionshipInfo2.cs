using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddChampionshipInfo2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChampionshipContestant_Championship_ChampionshipsChampionshi~",
                table: "ChampionshipContestant");

            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Championship_ChampionshipId",
                table: "Matches");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Championship",
                table: "Championship");

            migrationBuilder.RenameTable(
                name: "Championship",
                newName: "Championships");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Championships",
                table: "Championships",
                column: "ChampionshipId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChampionshipContestant_Championships_ChampionshipsChampionsh~",
                table: "ChampionshipContestant",
                column: "ChampionshipsChampionshipId",
                principalTable: "Championships",
                principalColumn: "ChampionshipId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Championships_ChampionshipId",
                table: "Matches",
                column: "ChampionshipId",
                principalTable: "Championships",
                principalColumn: "ChampionshipId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChampionshipContestant_Championships_ChampionshipsChampionsh~",
                table: "ChampionshipContestant");

            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Championships_ChampionshipId",
                table: "Matches");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Championships",
                table: "Championships");

            migrationBuilder.RenameTable(
                name: "Championships",
                newName: "Championship");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Championship",
                table: "Championship",
                column: "ChampionshipId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChampionshipContestant_Championship_ChampionshipsChampionshi~",
                table: "ChampionshipContestant",
                column: "ChampionshipsChampionshipId",
                principalTable: "Championship",
                principalColumn: "ChampionshipId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Championship_ChampionshipId",
                table: "Matches",
                column: "ChampionshipId",
                principalTable: "Championship",
                principalColumn: "ChampionshipId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
