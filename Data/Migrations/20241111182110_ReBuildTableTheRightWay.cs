using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WasagaRFC.Data.Migrations
{
    /// <inheritdoc />
    public partial class ReBuildTableTheRightWay : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "age",
                table: "Players",
                newName: "Age");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Age",
                table: "Players",
                newName: "age");
        }
    }
}
