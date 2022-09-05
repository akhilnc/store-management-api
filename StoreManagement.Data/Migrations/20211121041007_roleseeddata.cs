using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StoreManagement.Data.Migrations
{
    public partial class roleseeddata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "mst_user_role",
                columns: new[] { "id", "created_by", "created_on", "is_active", "modified_by", "modified_on", "name", "short_name", "u_id" },
                values: new object[] { 1L, "test", new DateTime(2021, 11, 21, 9, 40, 7, 7, DateTimeKind.Local).AddTicks(6036), true, "asda", new DateTime(2021, 11, 21, 9, 40, 7, 8, DateTimeKind.Local).AddTicks(7823), "admin", "Ad", "7ee285f6-9669-43d9-802a-b1ea58a2e461" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "mst_user_role",
                keyColumn: "id",
                keyValue: 1L);
        }
    }
}
