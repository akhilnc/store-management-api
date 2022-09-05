using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace StoreManagement.Data.Migrations
{
    public partial class add : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "admin_app_logs",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    u_id = table.Column<string>(type: "text", nullable: true),
                    message = table.Column<string>(type: "text", nullable: true),
                    exception = table.Column<string>(type: "text", nullable: true),
                    user_u_id = table.Column<string>(type: "text", nullable: true),
                    log_level = table.Column<string>(type: "text", nullable: true),
                    issue_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_admin_app_logs", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "admin_user_refresh_token",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    u_id = table.Column<string>(type: "text", nullable: true),
                    user_u_id = table.Column<string>(type: "text", nullable: true),
                    refresh_token = table.Column<string>(type: "text", nullable: true),
                    refresh_token_expiry = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_admin_user_refresh_token", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "mst_user",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    u_id = table.Column<string>(type: "text", nullable: false),
                    user_name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    email_id = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    password_hash = table.Column<string>(type: "text", nullable: true),
                    password_salt = table.Column<string>(type: "text", nullable: true),
                    profile_image = table.Column<string>(type: "text", nullable: true),
                    mobile_no = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    full_name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: true),
                    created_on = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    created_by = table.Column<string>(type: "text", nullable: false),
                    modified_on = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    modified_by = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_mst_user", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "mst_user_role",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false),
                    u_id = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    short_name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: true),
                    created_by = table.Column<string>(type: "text", nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    modified_by = table.Column<string>(type: "text", nullable: false),
                    modified_on = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    role_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_mst_user_role", x => x.id);
                    table.ForeignKey(
                        name: "fk_mst_user_role_mst_user_id",
                        column: x => x.id,
                        principalTable: "mst_user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "admin_app_logs");

            migrationBuilder.DropTable(
                name: "admin_user_refresh_token");

            migrationBuilder.DropTable(
                name: "mst_user_role");

            migrationBuilder.DropTable(
                name: "mst_user");
        }
    }
}
