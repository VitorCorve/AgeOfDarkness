using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgeOfDarknessContext.Migrations
{
    public partial class M3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StreetAsset",
                columns: table => new
                {
                    StreetId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TownId = table.Column<int>(type: "int", nullable: false),
                    KingdomId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StreetAsset", x => x.StreetId);
                    table.ForeignKey(
                        name: "FK_StreetAsset_TownAssets_TownId",
                        column: x => x.TownId,
                        principalTable: "TownAssets",
                        principalColumn: "TownId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StreetAsset_TownId",
                table: "StreetAsset",
                column: "TownId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StreetAsset");
        }
    }
}
