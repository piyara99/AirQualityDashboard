using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AirQualityDashboard.Migrations
{
    /// <inheritdoc />
    public partial class SeedSensorData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Value",
                table: "SensorDataRecords");

            migrationBuilder.DropColumn(
                name: "AQILevel",
                table: "AlertThresholds");

            migrationBuilder.DropColumn(
                name: "AlertThresholdId",
                table: "AlertThresholds");

            migrationBuilder.DropColumn(
                name: "Color",
                table: "AlertThresholds");

            migrationBuilder.RenameColumn(
                name: "MinValue",
                table: "AlertThresholds",
                newName: "MinAQI");

            migrationBuilder.RenameColumn(
                name: "Message",
                table: "AlertThresholds",
                newName: "ColorHex");

            migrationBuilder.RenameColumn(
                name: "MaxValue",
                table: "AlertThresholds",
                newName: "MaxAQI");

            migrationBuilder.RenameColumn(
                name: "Level",
                table: "AlertThresholds",
                newName: "CategoryName");

            migrationBuilder.InsertData(
                table: "SensorDataRecords",
                columns: new[] { "Id", "AQI", "SensorId", "Timestamp" },
                values: new object[,]
                {
                    { 1, 42, -1, new DateTime(2025, 4, 22, 0, 4, 1, 189, DateTimeKind.Utc).AddTicks(327) },
                    { 2, 55, -1, new DateTime(2025, 4, 22, 1, 4, 1, 189, DateTimeKind.Utc).AddTicks(541) },
                    { 3, 65, -1, new DateTime(2025, 4, 22, 2, 4, 1, 189, DateTimeKind.Utc).AddTicks(545) },
                    { 4, 75, -1, new DateTime(2025, 4, 22, 3, 4, 1, 189, DateTimeKind.Utc).AddTicks(546) },
                    { 5, 68, -1, new DateTime(2025, 4, 22, 4, 4, 1, 189, DateTimeKind.Utc).AddTicks(547) }
                });

            migrationBuilder.InsertData(
                table: "SimulationConfigs",
                columns: new[] { "Id", "BaseAQI", "FrequencyInSeconds", "IsRunning", "VariationRange" },
                values: new object[] { 1, 100, 60, true, 20 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SensorDataRecords",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SensorDataRecords",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SensorDataRecords",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "SensorDataRecords",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "SensorDataRecords",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "SimulationConfigs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.RenameColumn(
                name: "MinAQI",
                table: "AlertThresholds",
                newName: "MinValue");

            migrationBuilder.RenameColumn(
                name: "MaxAQI",
                table: "AlertThresholds",
                newName: "MaxValue");

            migrationBuilder.RenameColumn(
                name: "ColorHex",
                table: "AlertThresholds",
                newName: "Message");

            migrationBuilder.RenameColumn(
                name: "CategoryName",
                table: "AlertThresholds",
                newName: "Level");

            migrationBuilder.AddColumn<double>(
                name: "Value",
                table: "SensorDataRecords",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "AQILevel",
                table: "AlertThresholds",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "AlertThresholdId",
                table: "AlertThresholds",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "AlertThresholds",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
