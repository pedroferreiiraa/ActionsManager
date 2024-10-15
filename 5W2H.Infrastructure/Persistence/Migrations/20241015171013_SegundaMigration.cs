using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _5W2H.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SegundaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Actions_Projects_ProjectId",
                table: "Actions");

            migrationBuilder.DropForeignKey(
                name: "FK_Actions_Users_UserId1",
                table: "Actions");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Users_UserId1",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Projects_UserId1",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Actions_UserId1",
                table: "Actions");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Actions");

            migrationBuilder.RenameColumn(
                name: "ConclusionText",
                table: "Projects",
                newName: "OriginDate");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectId",
                table: "Actions",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Actions_Projects_ProjectId",
                table: "Actions",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Actions_Projects_ProjectId",
                table: "Actions");

            migrationBuilder.RenameColumn(
                name: "OriginDate",
                table: "Projects",
                newName: "ConclusionText");

            migrationBuilder.AddColumn<int>(
                name: "UserId1",
                table: "Projects",
                type: "integer",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProjectId",
                table: "Actions",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "UserId1",
                table: "Actions",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Projects_UserId1",
                table: "Projects",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Actions_UserId1",
                table: "Actions",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Actions_Projects_ProjectId",
                table: "Actions",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Actions_Users_UserId1",
                table: "Actions",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Users_UserId1",
                table: "Projects",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
