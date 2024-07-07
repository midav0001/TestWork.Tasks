using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TestWork.Tasks.Dal.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FileStorages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileStorages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaskFileStorages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FileStorageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TaskId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskFileStorages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaskFileStorages_FileStorages_FileStorageId",
                        column: x => x.FileStorageId,
                        principalTable: "FileStorages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaskFileStorages_Tasks_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "FileStorages",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("583c1460-501c-444f-b6ef-a1d0e6c6753a"), "Test2.png" },
                    { new Guid("9fa47a41-01b8-47d5-8b4c-2c29cda16bb9"), "Test.png" }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "CreateDate", "Name", "State" },
                values: new object[,]
                {
                    { new Guid("147fcc75-5a47-4684-a2c9-1a071d323b70"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Задача 1", 3 },
                    { new Guid("6fa9a90e-0189-4179-83b0-30c80790a517"), new DateTime(2024, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Задача 2", 2 },
                    { new Guid("e228d8f9-e2e9-4724-bed4-3222fba66ae2"), new DateTime(2024, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Задача 3", 1 }
                });

            migrationBuilder.InsertData(
                table: "TaskFileStorages",
                columns: new[] { "Id", "FileStorageId", "TaskId" },
                values: new object[,]
                {
                    { new Guid("bf112e43-78aa-4ace-9f88-bfbb8edae945"), new Guid("583c1460-501c-444f-b6ef-a1d0e6c6753a"), new Guid("6fa9a90e-0189-4179-83b0-30c80790a517") },
                    { new Guid("e167f406-9583-498f-905c-7acaf7c39478"), new Guid("9fa47a41-01b8-47d5-8b4c-2c29cda16bb9"), new Guid("147fcc75-5a47-4684-a2c9-1a071d323b70") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TaskFileStorages_FileStorageId",
                table: "TaskFileStorages",
                column: "FileStorageId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskFileStorages_TaskId",
                table: "TaskFileStorages",
                column: "TaskId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaskFileStorages");

            migrationBuilder.DropTable(
                name: "FileStorages");

            migrationBuilder.DropTable(
                name: "Tasks");
        }
    }
}
