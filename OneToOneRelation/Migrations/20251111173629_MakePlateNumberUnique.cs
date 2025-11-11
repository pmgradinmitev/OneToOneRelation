using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OneToOneRelation.Migrations
{
    /// <inheritdoc />
    public partial class MakePlateNumberUnique : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PlateNumber",
                table: "CarRegistrations",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_CarRegistrations_PlateNumber",
                table: "CarRegistrations",
                column: "PlateNumber",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CarRegistrations_PlateNumber",
                table: "CarRegistrations");

            migrationBuilder.AlterColumn<string>(
                name: "PlateNumber",
                table: "CarRegistrations",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
