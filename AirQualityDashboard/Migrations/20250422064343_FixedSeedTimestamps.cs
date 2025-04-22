using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirQualityDashboard.Migrations
{
    /// <inheritdoc />
    public partial class FixedSeedTimestamps : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "SensorDataRecords",
                keyColumn: "Id",
                keyValue: 1,
                column: "Timestamp",
                value: new DateTime(2024, 4, 21, 3, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "SensorDataRecords",
                keyColumn: "Id",
                keyValue: 2,
                column: "Timestamp",
                value: new DateTime(2024, 4, 21, 4, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "SensorDataRecords",
                keyColumn: "Id",
                keyValue: 3,
                column: "Timestamp",
                value: new DateTime(2024, 4, 21, 5, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "SensorDataRecords",
                keyColumn: "Id",
                keyValue: 4,
                column: "Timestamp",
                value: new DateTime(2024, 4, 21, 6, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "SensorDataRecords",
                keyColumn: "Id",
                keyValue: 5,
                column: "Timestamp",
                value: new DateTime(2024, 4, 21, 7, 0, 0, 0, DateTimeKind.Utc));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "SensorDataRecords",
                keyColumn: "Id",
                keyValue: 1,
                column: "Timestamp",
                value: new DateTime(2025, 4, 22, 0, 4, 1, 189, DateTimeKind.Utc).AddTicks(327));

            migrationBuilder.UpdateData(
                table: "SensorDataRecords",
                keyColumn: "Id",
                keyValue: 2,
                column: "Timestamp",
                value: new DateTime(2025, 4, 22, 1, 4, 1, 189, DateTimeKind.Utc).AddTicks(541));

            migrationBuilder.UpdateData(
                table: "SensorDataRecords",
                keyColumn: "Id",
                keyValue: 3,
                column: "Timestamp",
                value: new DateTime(2025, 4, 22, 2, 4, 1, 189, DateTimeKind.Utc).AddTicks(545));

            migrationBuilder.UpdateData(
                table: "SensorDataRecords",
                keyColumn: "Id",
                keyValue: 4,
                column: "Timestamp",
                value: new DateTime(2025, 4, 22, 3, 4, 1, 189, DateTimeKind.Utc).AddTicks(546));

            migrationBuilder.UpdateData(
                table: "SensorDataRecords",
                keyColumn: "Id",
                keyValue: 5,
                column: "Timestamp",
                value: new DateTime(2025, 4, 22, 4, 4, 1, 189, DateTimeKind.Utc).AddTicks(547));
        }
    }
}
