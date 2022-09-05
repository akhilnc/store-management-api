using Microsoft.EntityFrameworkCore.Migrations;

namespace StoreManagement.Data.Migrations
{
    public partial class renameduserrole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "role_id",
                table: "mst_user_role",
                newName: "user_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "mst_user_role",
                newName: "role_id");
        }
    }
}
