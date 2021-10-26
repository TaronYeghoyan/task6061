using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Infrastructure.Data.Migrations
{
    public partial class _1614 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Products",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("3fbc0b70-17bc-407c-b717-8b1fc3fa1d91"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("c6def471-acfd-4679-8da1-4df2aa42ccb6"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Employees",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("76362afd-3228-4e93-b0cd-aadd0296752c"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("bb64980f-b4ad-40b5-9ce1-57a039c00023"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Departments",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("ef999320-b694-4820-8bf4-4621d309aa16"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("78b6976b-9c97-463a-bae3-028551e465d9"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Products",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("c6def471-acfd-4679-8da1-4df2aa42ccb6"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("3fbc0b70-17bc-407c-b717-8b1fc3fa1d91"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Employees",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("bb64980f-b4ad-40b5-9ce1-57a039c00023"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("76362afd-3228-4e93-b0cd-aadd0296752c"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Departments",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("78b6976b-9c97-463a-bae3-028551e465d9"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("ef999320-b694-4820-8bf4-4621d309aa16"));
        }
    }
}