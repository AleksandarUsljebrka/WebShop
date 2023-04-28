using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebShopBackend.Migrations
{
    public partial class ModelCorrection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Salesmen_UserName",
                table: "Salesmen");

            migrationBuilder.DropIndex(
                name: "IX_Customers_UserName",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Admins_UserName",
                table: "Admins");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Salesmen");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Salesmen");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Admins");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Admins");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Salesmen",
                newName: "Username");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Customers",
                newName: "Username");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Admins",
                newName: "Username");

            migrationBuilder.CreateIndex(
                name: "IX_Salesmen_Username",
                table: "Salesmen",
                column: "Username",
                unique: true,
                filter: "[Username] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_Username",
                table: "Customers",
                column: "Username",
                unique: true,
                filter: "[Username] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Admins_Username",
                table: "Admins",
                column: "Username",
                unique: true,
                filter: "[Username] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Salesmen_Username",
                table: "Salesmen");

            migrationBuilder.DropIndex(
                name: "IX_Customers_Username",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Admins_Username",
                table: "Admins");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "Salesmen",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "Customers",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "Admins",
                newName: "UserName");

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "Salesmen",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Salesmen",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "Customers",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "Admins",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Admins",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Salesmen_UserName",
                table: "Salesmen",
                column: "UserName",
                unique: true,
                filter: "[UserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_UserName",
                table: "Customers",
                column: "UserName",
                unique: true,
                filter: "[UserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Admins_UserName",
                table: "Admins",
                column: "UserName",
                unique: true,
                filter: "[UserName] IS NOT NULL");
        }
    }
}
