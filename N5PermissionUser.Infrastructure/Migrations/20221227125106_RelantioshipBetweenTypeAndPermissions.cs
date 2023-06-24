using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace N5PermissionUser.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RelantioshipBetweenTypeAndPermissions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "TypeId",
                schema: "dbo",
                table: "Permissions",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Permission_TypeEntityId",
                schema: "dbo",
                table: "Permissions",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Permission_TypeEntity_TypeEntityId",
                schema: "dbo",
                table: "Permissions",
                column: "TypeId",
                principalSchema: "dbo",
                principalTable: "TypeEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Permission_TypeEntity_TypeEntityId",
                schema: "dbo",
                table: "Permissions");

            migrationBuilder.DropIndex(
                name: "IX_Permission_TypeEntityId",
                schema: "dbo",
                table: "Permissions");

            migrationBuilder.DropColumn(
                name: "TypeEntity",
                schema: "dbo",
                table: "Permissions");
        }
    }
}
