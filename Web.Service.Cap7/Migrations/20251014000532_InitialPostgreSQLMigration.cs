using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web.Service.Cap7.Migrations
{
    /// <inheritdoc />
    public partial class InitialPostgreSQLMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence<int>(
                name: "SEQ_EQUIPMENTS");

            migrationBuilder.CreateSequence<int>(
                name: "SEQ_SECTORS");

            migrationBuilder.CreateSequence<int>(
                name: "SEQ_USERS");

            migrationBuilder.CreateTable(
                name: "USERS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, defaultValueSql: "SEQ_USERS.NEXTVAL"),
                    NAME = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    EMAIL = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    PASSWORD_HASH = table.Column<byte[]>(type: "BLOB", nullable: false),
                    PASSWORD_SALT = table.Column<byte[]>(type: "BLOB", nullable: false),
                    ROLE = table.Column<int>(type: "integer", nullable: false),
                    CREATED_AT = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    UPDATED_AT = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USERS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SECTORS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, defaultValueSql: "SEQ_SECTORS.NEXTVAL"),
                    NAME = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    DESCRIPTION = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    CONSUMPTION_LIMIT = table.Column<double>(type: "double precision", nullable: false),
                    USER_ID = table.Column<int>(type: "integer", nullable: false),
                    CREATED_AT = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    UPDATED_AT = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SECTORS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SECTORS_USERS_USER_ID",
                        column: x => x.USER_ID,
                        principalTable: "USERS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EQUIPMENTS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, defaultValueSql: "SEQ_EQUIPMENTS.NEXTVAL"),
                    NAME = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    IS_ACTIVE = table.Column<int>(type: "integer", nullable: false),
                    CONSUMPTION_PER_HOUR = table.Column<double>(type: "double precision", nullable: false),
                    MAX_ACTIVE_HOURS = table.Column<int>(type: "integer", nullable: false),
                    ConsumptionTotal = table.Column<double>(type: "double precision", nullable: false),
                    LAST_ACTIVED_AT = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    SECTOR_ID = table.Column<int>(type: "integer", nullable: false),
                    CREATED_AT = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    UPDATED_AT = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EQUIPMENTS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EQUIPMENTS_SECTORS_SECTOR_ID",
                        column: x => x.SECTOR_ID,
                        principalTable: "SECTORS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EQUIPMENTS_SECTOR_ID",
                table: "EQUIPMENTS",
                column: "SECTOR_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SECTORS_USER_ID",
                table: "SECTORS",
                column: "USER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_USERS_EMAIL",
                table: "USERS",
                column: "EMAIL",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EQUIPMENTS");

            migrationBuilder.DropTable(
                name: "SECTORS");

            migrationBuilder.DropTable(
                name: "USERS");

            migrationBuilder.DropSequence(
                name: "SEQ_EQUIPMENTS");

            migrationBuilder.DropSequence(
                name: "SEQ_SECTORS");

            migrationBuilder.DropSequence(
                name: "SEQ_USERS");
        }
    }
}
