using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirQualityDashboard.Migrations
{
    /// <inheritdoc />
    public partial class AddPM25AndPM10ToSensorData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "PM10",
                table: "SensorDataRecords",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "PM25",
                table: "SensorDataRecords",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.UpdateData(
                table: "SensorDataRecords",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PM10", "PM25" },
                values: new object[] { 0f, 0f });

            migrationBuilder.UpdateData(
                table: "SensorDataRecords",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PM10", "PM25" },
                values: new object[] { 0f, 0f });

            migrationBuilder.UpdateData(
                table: "SensorDataRecords",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PM10", "PM25" },
                values: new object[] { 0f, 0f });

            migrationBuilder.UpdateData(
                table: "SensorDataRecords",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "PM10", "PM25" },
                values: new object[] { 0f, 0f });

            migrationBuilder.UpdateData(
                table: "SensorDataRecords",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "PM10", "PM25" },
                values: new object[] { 0f, 0f });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PM10",
                table: "SensorDataRecords");

            migrationBuilder.DropColumn(
                name: "PM25",
                table: "SensorDataRecords");
        }
    }
}
