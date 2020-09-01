using Microsoft.EntityFrameworkCore.Migrations;

namespace FasttrackIT_Project.Migrations
{
    public partial class UpdateOfferHeader : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_OfferHeader_ClientId",
                table: "OfferHeader",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_OfferHeader_Client_ClientId",
                table: "OfferHeader",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OfferHeader_Client_ClientId",
                table: "OfferHeader");

            migrationBuilder.DropIndex(
                name: "IX_OfferHeader_ClientId",
                table: "OfferHeader");
        }
    }
}
