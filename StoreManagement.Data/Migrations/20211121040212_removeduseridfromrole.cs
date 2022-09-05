using Microsoft.EntityFrameworkCore.Migrations;

namespace StoreManagement.Data.Migrations
{
    public partial class removeduseridfromrole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "user_id",
                table: "mst_user_role");

            migrationBuilder.AddColumn<int>(
                name: "role_id",
                table: "mst_user",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "role_id",
                table: "mst_user");

            migrationBuilder.AddColumn<int>(
                name: "user_id",
                table: "mst_user_role",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
