using Microsoft.EntityFrameworkCore.Migrations;

namespace BankApp.Data.Migrations
{
    public partial class UpdatedClientBalance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClientRefNumber",
                table: "ClientBalance");

            migrationBuilder.DropColumn(
                name: "OtherRefNumber",
                table: "ClientBalance");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ClientRefNumber",
                table: "ClientBalance",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OtherRefNumber",
                table: "ClientBalance",
                nullable: true);
        }
    }
}
