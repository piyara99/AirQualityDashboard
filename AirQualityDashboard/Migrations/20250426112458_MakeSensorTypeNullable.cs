using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirQualityDashboard.Migrations
{
    /// <inheritdoc />
    public partial class MakeSensorTypeNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Sensors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Sensors",
                keyColumn: "Id",
                keyValue: -3,
                column: "Type",
                value: null);

            migrationBuilder.UpdateData(
                table: "Sensors",
                keyColumn: "Id",
                keyValue: -2,
                column: "Type",
                value: null);

            migrationBuilder.UpdateData(
                table: "Sensors",
                keyColumn: "Id",
                keyValue: -1,
                column: "Type",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Sensors");
        }
    }
}
