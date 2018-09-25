using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BankApp.Data.Migrations
{
    public partial class UpdatedClientBalancesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientBalance_AspNetUsers_ClientId",
                table: "ClientBalance");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClientBalance",
                table: "ClientBalance");

            migrationBuilder.RenameTable(
                name: "ClientBalance",
                newName: "Balance");

            migrationBuilder.RenameIndex(
                name: "IX_ClientBalance_ClientId",
                table: "Balance",
                newName: "IX_Balance_ClientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Balance",
                table: "Balance",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Balance_AspNetUsers_ClientId",
                table: "Balance",
                column: "ClientId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Balance_AspNetUsers_ClientId",
                table: "Balance");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Balance",
                table: "Balance");

            migrationBuilder.RenameTable(
                name: "Balance",
                newName: "ClientBalance");

            migrationBuilder.RenameIndex(
                name: "IX_Balance_ClientId",
                table: "ClientBalance",
                newName: "IX_ClientBalance_ClientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClientBalance",
                table: "ClientBalance",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientBalance_AspNetUsers_ClientId",
                table: "ClientBalance",
                column: "ClientId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
