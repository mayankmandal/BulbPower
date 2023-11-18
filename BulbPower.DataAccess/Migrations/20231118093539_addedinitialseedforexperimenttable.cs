using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BulbPower.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addedinitialseedforexperimenttable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Experiments",
                columns: new[] { "ExperimentId", "CreatedDateTime", "ExperimentName", "ExperimentStatus", "LastExitedDateTime", "LastExitedPersonNumber", "NumberOfBulbs", "NumberOfPeople" },
                values: new object[] { 4, new DateTime(2023, 11, 18, 15, 5, 38, 792, DateTimeKind.Local).AddTicks(565), "2-people-2-bulbs", 0, new DateTime(2023, 11, 18, 15, 5, 38, 792, DateTimeKind.Local).AddTicks(550), 0, 2, 2 });

            migrationBuilder.InsertData(
                table: "ExperimentBulbStates",
                columns: new[] { "ExperimentBulbStateId", "BulbNumber", "BulbState", "ExperimentId", "ToggledOnDateTime" },
                values: new object[,]
                {
                    { 4, 1, false, 4, new DateTime(2023, 11, 18, 9, 35, 38, 792, DateTimeKind.Utc).AddTicks(653) },
                    { 5, 2, false, 4, new DateTime(2023, 11, 18, 9, 35, 38, 792, DateTimeKind.Utc).AddTicks(655) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ExperimentBulbStates",
                keyColumn: "ExperimentBulbStateId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ExperimentBulbStates",
                keyColumn: "ExperimentBulbStateId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Experiments",
                keyColumn: "ExperimentId",
                keyValue: 4);
        }
    }
}
