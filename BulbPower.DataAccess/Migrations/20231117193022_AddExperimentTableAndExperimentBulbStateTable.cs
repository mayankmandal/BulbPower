using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BulbPower.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddExperimentTableAndExperimentBulbStateTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Experiments",
                columns: table => new
                {
                    ExperimentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumberOfPeople = table.Column<int>(type: "int", nullable: false),
                    NumberOfBulbs = table.Column<int>(type: "int", nullable: false),
                    ExperimentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExperimentStatus = table.Column<int>(type: "int", nullable: false),
                    LastExitedPersonNumber = table.Column<int>(type: "int", nullable: false),
                    LastExitedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Experiments", x => x.ExperimentId);
                });

            migrationBuilder.CreateTable(
                name: "ExperimentBulbStates",
                columns: table => new
                {
                    ExperimentBulbStateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExperimentId = table.Column<int>(type: "int", nullable: false),
                    BulbNumber = table.Column<int>(type: "int", nullable: false),
                    BulbState = table.Column<bool>(type: "bit", nullable: false),
                    ToggledOnDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExperimentBulbStates", x => x.ExperimentBulbStateId);
                    table.ForeignKey(
                        name: "FK_ExperimentBulbStates_Experiments_ExperimentId",
                        column: x => x.ExperimentId,
                        principalTable: "Experiments",
                        principalColumn: "ExperimentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExperimentBulbStates_ExperimentId",
                table: "ExperimentBulbStates",
                column: "ExperimentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExperimentBulbStates");

            migrationBuilder.DropTable(
                name: "Experiments");
        }
    }
}
