using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "RINovus");

            migrationBuilder.CreateTable(
                name: "Owners",
                schema: "RINovus",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Codia = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    IdentificationNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owners", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Properties",
                schema: "RINovus",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Area = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Region = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Surface = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ImmovableOwnerClassId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImmovablePropertyTypes = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Properties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Properties_Owners_ImmovableOwnerClassId",
                        column: x => x.ImmovableOwnerClassId,
                        principalSchema: "RINovus",
                        principalTable: "Owners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Properties_ImmovableOwnerClassId",
                schema: "RINovus",
                table: "Properties",
                column: "ImmovableOwnerClassId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Properties",
                schema: "RINovus");

            migrationBuilder.DropTable(
                name: "Owners",
                schema: "RINovus");
        }
    }
}
