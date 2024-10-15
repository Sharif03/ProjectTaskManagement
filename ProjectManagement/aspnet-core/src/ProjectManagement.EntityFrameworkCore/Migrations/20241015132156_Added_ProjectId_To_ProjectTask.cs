using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectManagement.Migrations
{
    /// <inheritdoc />
    public partial class Added_ProjectId_To_ProjectTask : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ProjectId",
                table: "AppTasks",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_AppTasks_ProjectId",
                table: "AppTasks",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppTasks_AppProjects_ProjectId",
                table: "AppTasks",
                column: "ProjectId",
                principalTable: "AppProjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppTasks_AppProjects_ProjectId",
                table: "AppTasks");

            migrationBuilder.DropIndex(
                name: "IX_AppTasks_ProjectId",
                table: "AppTasks");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "AppTasks");
        }
    }
}
