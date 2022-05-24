using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Starter.Entities.Migrations
{
    public partial class Attribute_DataType_EntityValue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
               name: "DataType",
               table: "Attributes");

            migrationBuilder.AddColumn<long>(
                name: "DataTypeId",
                table: "Attributes",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "DataTypeId",
                table: "EntityValues",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "AttributeDataTypes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DBType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<long>(type: "bigint", nullable: false),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttributeDataTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EntityValues_DataTypeId",
                table: "EntityValues",
                column: "DataTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Attributes_DataTypeId",
                table: "Attributes",
                column: "DataTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attributes_AttributeDataTypes_DataTypeId",
                table: "Attributes",
                column: "DataTypeId",
                principalTable: "AttributeDataTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EntityValues_AttributeDataTypes_DataTypeId",
                table: "EntityValues",
                column: "DataTypeId",
                principalTable: "AttributeDataTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EntityValues_Attributes_AttributeId",
                table: "EntityValues",
                column: "AttributeId",
                principalTable: "Attributes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attributes_AttributeDataTypes_DataTypeId",
                table: "Attributes");

            migrationBuilder.DropForeignKey(
                name: "FK_EntityValues_AttributeDataTypes_DataTypeId",
                table: "EntityValues");

            migrationBuilder.DropTable(
                name: "AttributeDataTypes");

            migrationBuilder.DropIndex(
                name: "IX_EntityValues_DataTypeId",
                table: "EntityValues");

            migrationBuilder.DropIndex(
                name: "IX_Attributes_DataTypeId",
                table: "Attributes");

            migrationBuilder.DropColumn(
                name: "DataTypeId",
                table: "EntityValues");

            migrationBuilder.DropColumn(
                name: "DataTypeId",
                table: "Attributes");

            migrationBuilder.AddColumn<string>(
                name: "DataType",
                table: "Attributes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DataType",
                table: "EntityValues",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
