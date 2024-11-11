using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WasagaRFC.Data.Migrations
{
    /// <inheritdoc />
    public partial class BuildTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    PlayerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    age = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.PlayerId);
                });

            migrationBuilder.CreateTable(
                name: "Starters",
                columns: table => new
                {
                    StarterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Prop1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prop2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Hooker = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lock1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lock2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Flanker1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Flanker2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Number8 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ScrumHalf = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FlyHalf = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Center1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Center2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Wing1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Wing2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullBack = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlayerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Starters", x => x.StarterId);
                    table.ForeignKey(
                        name: "FK_Starters_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "PlayerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Starters_PlayerId",
                table: "Starters",
                column: "PlayerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Starters");

            migrationBuilder.DropTable(
                name: "Players");
        }
    }
}
