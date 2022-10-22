using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgeOfDarknessContext.Migrations
{
    public partial class M2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TownAssets",
                columns: table => new
                {
                    TownId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KingdomId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TownAssets", x => x.TownId);
                    table.ForeignKey(
                        name: "FK_TownAssets_KingdomAssets_KingdomId",
                        column: x => x.KingdomId,
                        principalTable: "KingdomAssets",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TownAssets_KingdomId",
                table: "TownAssets",
                column: "KingdomId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TownAssets");
        }
    }
}
