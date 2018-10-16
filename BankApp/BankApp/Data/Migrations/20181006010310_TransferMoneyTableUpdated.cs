using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BankApp.Data.Migrations
{
    public partial class TransferMoneyTableUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MoneyTransfer",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Amount = table.Column<double>(nullable: false),
                    ToAccount = table.Column<string>(nullable: true),
                    FromAccount = table.Column<string>(nullable: true),
                    ClientRef = table.Column<string>(nullable: true),
                    OtherRef = table.Column<string>(nullable: true),
                    ClientId = table.Column<string>(nullable: true),
                    ClientBalanceID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoneyTransfer", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MoneyTransfer_ClientBalance_ClientBalanceID",
                        column: x => x.ClientBalanceID,
                        principalTable: "ClientBalance",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MoneyTransfer_AspNetUsers_ClientId",
                        column: x => x.ClientId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MoneyTransfer_ClientBalanceID",
                table: "MoneyTransfer",
                column: "ClientBalanceID");

            migrationBuilder.CreateIndex(
                name: "IX_MoneyTransfer_ClientId",
                table: "MoneyTransfer",
                column: "ClientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MoneyTransfer");
        }
    }
}
