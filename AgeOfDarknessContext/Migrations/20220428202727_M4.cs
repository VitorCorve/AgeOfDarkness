using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgeOfDarknessContext.Migrations
{
    public partial class M4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StreetAsset_TownAssets_TownId",
                table: "StreetAsset");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StreetAsset",
                table: "StreetAsset");

            migrationBuilder.RenameTable(
                name: "StreetAsset",
                newName: "StreetAssets");

            migrationBuilder.RenameIndex(
                name: "IX_StreetAsset_TownId",
                table: "StreetAssets",
                newName: "IX_StreetAssets_TownId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StreetAssets",
                table: "StreetAssets",
                column: "StreetId");

            migrationBuilder.AddForeignKey(
                name: "FK_StreetAssets_TownAssets_TownId",
                table: "StreetAssets",
                column: "TownId",
                principalTable: "TownAssets",
                principalColumn: "TownId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StreetAssets_TownAssets_TownId",
                table: "StreetAssets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StreetAssets",
                table: "StreetAssets");

            migrationBuilder.RenameTable(
                name: "StreetAssets",
                newName: "StreetAsset");

            migrationBuilder.RenameIndex(
                name: "IX_StreetAssets_TownId",
                table: "StreetAsset",
                newName: "IX_StreetAsset_TownId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StreetAsset",
                table: "StreetAsset",
                column: "StreetId");

            migrationBuilder.AddForeignKey(
                name: "FK_StreetAsset_TownAssets_TownId",
                table: "StreetAsset",
                column: "TownId",
                principalTable: "TownAssets",
                principalColumn: "TownId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
