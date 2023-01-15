using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LightPi.Data.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Lights",
                columns: table => new
                {
                    LightID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Route = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsRGB = table.Column<bool>(type: "bit", nullable: false),
                    IsCCT = table.Column<bool>(type: "bit", nullable: false),
                    MinColorTemp = table.Column<int>(type: "int", nullable: true),
                    MaxColorTemp = table.Column<int>(type: "int", nullable: true),
                    IsDimmable = table.Column<bool>(type: "bit", nullable: false),
                    MinBrightness = table.Column<int>(type: "int", nullable: true),
                    MaxBrightness = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lights", x => x.LightID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lights");
        }
    }
}
