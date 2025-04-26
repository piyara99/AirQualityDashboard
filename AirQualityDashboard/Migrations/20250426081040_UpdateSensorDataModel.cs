using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AirQualityDashboard.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSensorDataModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "SensorDataRecords",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AQI", "PM10", "PM25", "Timestamp" },
                values: new object[] { 45, 22.1f, 12.3f, new DateTime(2024, 4, 21, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "SensorDataRecords",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AQI", "PM10", "PM25", "Timestamp" },
                values: new object[] { 48, 23.4f, 13.1f, new DateTime(2024, 4, 21, 1, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "SensorDataRecords",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AQI", "PM10", "PM25", "Timestamp" },
                values: new object[] { 52, 25.9f, 14.8f, new DateTime(2024, 4, 21, 2, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "SensorDataRecords",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AQI", "PM10", "PM25", "Timestamp" },
                values: new object[] { 55, 28.4f, 16f, new DateTime(2024, 4, 21, 3, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "SensorDataRecords",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AQI", "PM10", "PM25", "Timestamp" },
                values: new object[] { 60, 30.2f, 17.3f, new DateTime(2024, 4, 21, 4, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.InsertData(
                table: "SensorDataRecords",
                columns: new[] { "Id", "AQI", "PM10", "PM25", "SensorId", "Timestamp" },
                values: new object[,]
                {
                    { 6, 63, 31.7f, 18.5f, -1, new DateTime(2024, 4, 21, 5, 0, 0, 0, DateTimeKind.Utc) },
                    { 7, 67, 32.5f, 19.2f, -1, new DateTime(2024, 4, 21, 6, 0, 0, 0, DateTimeKind.Utc) },
                    { 8, 70, 34.1f, 20f, -1, new DateTime(2024, 4, 21, 7, 0, 0, 0, DateTimeKind.Utc) },
                    { 9, 72, 35.8f, 21.1f, -1, new DateTime(2024, 4, 21, 8, 0, 0, 0, DateTimeKind.Utc) },
                    { 10, 75, 37.3f, 22.4f, -1, new DateTime(2024, 4, 21, 9, 0, 0, 0, DateTimeKind.Utc) },
                    { 11, 78, 39f, 23.2f, -1, new DateTime(2024, 4, 21, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { 12, 80, 40.2f, 24f, -1, new DateTime(2024, 4, 21, 11, 0, 0, 0, DateTimeKind.Utc) },
                    { 13, 82, 41.9f, 24.8f, -1, new DateTime(2024, 4, 21, 12, 0, 0, 0, DateTimeKind.Utc) },
                    { 14, 79, 40.7f, 23.5f, -1, new DateTime(2024, 4, 21, 13, 0, 0, 0, DateTimeKind.Utc) },
                    { 15, 76, 38.9f, 22.1f, -1, new DateTime(2024, 4, 21, 14, 0, 0, 0, DateTimeKind.Utc) },
                    { 16, 70, 35.7f, 20.4f, -1, new DateTime(2024, 4, 21, 15, 0, 0, 0, DateTimeKind.Utc) },
                    { 17, 68, 34.2f, 19.6f, -1, new DateTime(2024, 4, 21, 16, 0, 0, 0, DateTimeKind.Utc) },
                    { 18, 66, 32.9f, 18.8f, -1, new DateTime(2024, 4, 21, 17, 0, 0, 0, DateTimeKind.Utc) },
                    { 19, 62, 30.4f, 17.5f, -1, new DateTime(2024, 4, 21, 18, 0, 0, 0, DateTimeKind.Utc) },
                    { 20, 58, 28.3f, 16.2f, -1, new DateTime(2024, 4, 21, 19, 0, 0, 0, DateTimeKind.Utc) },
                    { 21, 55, 26.5f, 15.1f, -1, new DateTime(2024, 4, 21, 20, 0, 0, 0, DateTimeKind.Utc) },
                    { 22, 50, 24.2f, 14f, -1, new DateTime(2024, 4, 21, 21, 0, 0, 0, DateTimeKind.Utc) },
                    { 23, 47, 23f, 13.2f, -1, new DateTime(2024, 4, 21, 22, 0, 0, 0, DateTimeKind.Utc) },
                    { 24, 44, 21.7f, 12.5f, -1, new DateTime(2024, 4, 21, 23, 0, 0, 0, DateTimeKind.Utc) },
                    { 25, 38, 18.5f, 10.1f, -2, new DateTime(2024, 4, 21, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 26, 40, 19.9f, 11.2f, -2, new DateTime(2024, 4, 21, 1, 0, 0, 0, DateTimeKind.Utc) },
                    { 27, 43, 20.8f, 12f, -2, new DateTime(2024, 4, 21, 2, 0, 0, 0, DateTimeKind.Utc) },
                    { 28, 47, 22.3f, 13.5f, -2, new DateTime(2024, 4, 21, 3, 0, 0, 0, DateTimeKind.Utc) },
                    { 29, 52, 24f, 14.8f, -2, new DateTime(2024, 4, 21, 4, 0, 0, 0, DateTimeKind.Utc) },
                    { 30, 54, 25.2f, 15.5f, -2, new DateTime(2024, 4, 21, 5, 0, 0, 0, DateTimeKind.Utc) },
                    { 31, 59, 27.4f, 16.7f, -2, new DateTime(2024, 4, 21, 6, 0, 0, 0, DateTimeKind.Utc) },
                    { 32, 62, 29f, 17.6f, -2, new DateTime(2024, 4, 21, 7, 0, 0, 0, DateTimeKind.Utc) },
                    { 33, 65, 30.1f, 18.9f, -2, new DateTime(2024, 4, 21, 8, 0, 0, 0, DateTimeKind.Utc) },
                    { 34, 68, 31.4f, 19.7f, -2, new DateTime(2024, 4, 21, 9, 0, 0, 0, DateTimeKind.Utc) },
                    { 35, 70, 32.8f, 20.5f, -2, new DateTime(2024, 4, 21, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { 36, 72, 34.3f, 21.2f, -2, new DateTime(2024, 4, 21, 11, 0, 0, 0, DateTimeKind.Utc) },
                    { 37, 71, 33.5f, 20.9f, -2, new DateTime(2024, 4, 21, 12, 0, 0, 0, DateTimeKind.Utc) },
                    { 38, 69, 32.2f, 20f, -2, new DateTime(2024, 4, 21, 13, 0, 0, 0, DateTimeKind.Utc) },
                    { 39, 66, 30.7f, 19.2f, -2, new DateTime(2024, 4, 21, 14, 0, 0, 0, DateTimeKind.Utc) },
                    { 40, 63, 29.1f, 18f, -2, new DateTime(2024, 4, 21, 15, 0, 0, 0, DateTimeKind.Utc) },
                    { 41, 60, 27.5f, 17.1f, -2, new DateTime(2024, 4, 21, 16, 0, 0, 0, DateTimeKind.Utc) },
                    { 42, 57, 25.9f, 16f, -2, new DateTime(2024, 4, 21, 17, 0, 0, 0, DateTimeKind.Utc) },
                    { 43, 54, 24.3f, 15f, -2, new DateTime(2024, 4, 21, 18, 0, 0, 0, DateTimeKind.Utc) },
                    { 44, 50, 22.7f, 13.9f, -2, new DateTime(2024, 4, 21, 19, 0, 0, 0, DateTimeKind.Utc) },
                    { 45, 46, 21f, 12.7f, -2, new DateTime(2024, 4, 21, 20, 0, 0, 0, DateTimeKind.Utc) },
                    { 46, 42, 19.2f, 11.3f, -2, new DateTime(2024, 4, 21, 21, 0, 0, 0, DateTimeKind.Utc) },
                    { 47, 39, 18f, 10.6f, -2, new DateTime(2024, 4, 21, 22, 0, 0, 0, DateTimeKind.Utc) },
                    { 48, 37, 17.1f, 9.8f, -2, new DateTime(2024, 4, 21, 23, 0, 0, 0, DateTimeKind.Utc) },
                    { 49, 60, 26.3f, 16.2f, -3, new DateTime(2024, 4, 21, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 50, 62, 27.5f, 17f, -3, new DateTime(2024, 4, 21, 1, 0, 0, 0, DateTimeKind.Utc) },
                    { 51, 65, 28.9f, 18.1f, -3, new DateTime(2024, 4, 21, 2, 0, 0, 0, DateTimeKind.Utc) },
                    { 52, 68, 30.1f, 19.3f, -3, new DateTime(2024, 4, 21, 3, 0, 0, 0, DateTimeKind.Utc) },
                    { 53, 72, 31.7f, 20.6f, -3, new DateTime(2024, 4, 21, 4, 0, 0, 0, DateTimeKind.Utc) },
                    { 54, 75, 33.4f, 21.5f, -3, new DateTime(2024, 4, 21, 5, 0, 0, 0, DateTimeKind.Utc) },
                    { 55, 78, 35.2f, 22.3f, -3, new DateTime(2024, 4, 21, 6, 0, 0, 0, DateTimeKind.Utc) },
                    { 56, 80, 36.8f, 23.1f, -3, new DateTime(2024, 4, 21, 7, 0, 0, 0, DateTimeKind.Utc) },
                    { 57, 83, 38.2f, 24.4f, -3, new DateTime(2024, 4, 21, 8, 0, 0, 0, DateTimeKind.Utc) },
                    { 58, 85, 39.6f, 25.2f, -3, new DateTime(2024, 4, 21, 9, 0, 0, 0, DateTimeKind.Utc) },
                    { 59, 88, 41f, 26.3f, -3, new DateTime(2024, 4, 21, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { 60, 90, 42.3f, 27f, -3, new DateTime(2024, 4, 21, 11, 0, 0, 0, DateTimeKind.Utc) },
                    { 61, 87, 41.2f, 26f, -3, new DateTime(2024, 4, 21, 12, 0, 0, 0, DateTimeKind.Utc) },
                    { 62, 84, 39.4f, 24.9f, -3, new DateTime(2024, 4, 21, 13, 0, 0, 0, DateTimeKind.Utc) },
                    { 63, 81, 37.8f, 23.7f, -3, new DateTime(2024, 4, 21, 14, 0, 0, 0, DateTimeKind.Utc) },
                    { 64, 78, 36f, 22.5f, -3, new DateTime(2024, 4, 21, 15, 0, 0, 0, DateTimeKind.Utc) },
                    { 65, 75, 33.9f, 21.2f, -3, new DateTime(2024, 4, 21, 16, 0, 0, 0, DateTimeKind.Utc) },
                    { 66, 72, 32.3f, 20.1f, -3, new DateTime(2024, 4, 21, 17, 0, 0, 0, DateTimeKind.Utc) },
                    { 67, 69, 30.6f, 19f, -3, new DateTime(2024, 4, 21, 18, 0, 0, 0, DateTimeKind.Utc) },
                    { 68, 65, 28.8f, 17.9f, -3, new DateTime(2024, 4, 21, 19, 0, 0, 0, DateTimeKind.Utc) },
                    { 69, 62, 26.7f, 16.5f, -3, new DateTime(2024, 4, 21, 20, 0, 0, 0, DateTimeKind.Utc) },
                    { 70, 59, 25f, 15.3f, -3, new DateTime(2024, 4, 21, 21, 0, 0, 0, DateTimeKind.Utc) },
                    { 71, 55, 23.5f, 14.1f, -3, new DateTime(2024, 4, 21, 22, 0, 0, 0, DateTimeKind.Utc) },
                    { 72, 52, 22f, 13f, -3, new DateTime(2024, 4, 21, 23, 0, 0, 0, DateTimeKind.Utc) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SensorDataRecords",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "SensorDataRecords",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "SensorDataRecords",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "SensorDataRecords",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "SensorDataRecords",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "SensorDataRecords",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "SensorDataRecords",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "SensorDataRecords",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "SensorDataRecords",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "SensorDataRecords",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "SensorDataRecords",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "SensorDataRecords",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "SensorDataRecords",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "SensorDataRecords",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "SensorDataRecords",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "SensorDataRecords",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "SensorDataRecords",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "SensorDataRecords",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "SensorDataRecords",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "SensorDataRecords",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "SensorDataRecords",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "SensorDataRecords",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "SensorDataRecords",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "SensorDataRecords",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "SensorDataRecords",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "SensorDataRecords",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "SensorDataRecords",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "SensorDataRecords",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "SensorDataRecords",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "SensorDataRecords",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "SensorDataRecords",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "SensorDataRecords",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "SensorDataRecords",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "SensorDataRecords",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "SensorDataRecords",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "SensorDataRecords",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "SensorDataRecords",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "SensorDataRecords",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "SensorDataRecords",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "SensorDataRecords",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "SensorDataRecords",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "SensorDataRecords",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "SensorDataRecords",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "SensorDataRecords",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "SensorDataRecords",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "SensorDataRecords",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "SensorDataRecords",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "SensorDataRecords",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "SensorDataRecords",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "SensorDataRecords",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "SensorDataRecords",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "SensorDataRecords",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "SensorDataRecords",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "SensorDataRecords",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "SensorDataRecords",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "SensorDataRecords",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "SensorDataRecords",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "SensorDataRecords",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "SensorDataRecords",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "SensorDataRecords",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "SensorDataRecords",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "SensorDataRecords",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "SensorDataRecords",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "SensorDataRecords",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "SensorDataRecords",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "SensorDataRecords",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "SensorDataRecords",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.UpdateData(
                table: "SensorDataRecords",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AQI", "PM10", "PM25", "Timestamp" },
                values: new object[] { 42, 0f, 0f, new DateTime(2024, 4, 21, 3, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "SensorDataRecords",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AQI", "PM10", "PM25", "Timestamp" },
                values: new object[] { 55, 0f, 0f, new DateTime(2024, 4, 21, 4, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "SensorDataRecords",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AQI", "PM10", "PM25", "Timestamp" },
                values: new object[] { 65, 0f, 0f, new DateTime(2024, 4, 21, 5, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "SensorDataRecords",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AQI", "PM10", "PM25", "Timestamp" },
                values: new object[] { 75, 0f, 0f, new DateTime(2024, 4, 21, 6, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "SensorDataRecords",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AQI", "PM10", "PM25", "Timestamp" },
                values: new object[] { 68, 0f, 0f, new DateTime(2024, 4, 21, 7, 0, 0, 0, DateTimeKind.Utc) });
        }
    }
}
