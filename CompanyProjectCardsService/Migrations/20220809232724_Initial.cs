using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompanyProjectCardsService.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cards",
                columns: table => new
                {
                    CardId = table.Column<Guid>(type: "uuid", nullable: false),
                    PageNameForCard = table.Column<string>(type: "text", nullable: true),
                    CardIsLink = table.Column<bool>(type: "boolean", nullable: false),
                    CardLinkAddress = table.Column<string>(type: "text", nullable: true),
                    CardHasHeader = table.Column<bool>(type: "boolean", nullable: false),
                    CardImage = table.Column<string>(type: "text", nullable: true),
                    CardContent = table.Column<string>(type: "text", nullable: true),
                    CardHasFooter = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.CardId);
                });

            migrationBuilder.CreateTable(
                name: "CardFooter",
                columns: table => new
                {
                    CardFooterId = table.Column<Guid>(type: "uuid", nullable: false),
                    CardFooterForeignKey = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardFooter", x => x.CardFooterId);
                    table.ForeignKey(
                        name: "FK_CardFooter_Cards_CardFooterForeignKey",
                        column: x => x.CardFooterForeignKey,
                        principalTable: "Cards",
                        principalColumn: "CardId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CardHeader",
                columns: table => new
                {
                    CardHeaderId = table.Column<Guid>(type: "uuid", nullable: false),
                    CardHeaderIsLink = table.Column<bool>(type: "boolean", nullable: false),
                    CardHeaderLinkAddress = table.Column<string>(type: "text", nullable: true),
                    CardHeaderTitle = table.Column<string>(type: "text", nullable: true),
                    CardHeaderIcon = table.Column<string>(type: "text", nullable: true),
                    CardHeaderForeignKey = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardHeader", x => x.CardHeaderId);
                    table.ForeignKey(
                        name: "FK_CardHeader_Cards_CardHeaderForeignKey",
                        column: x => x.CardHeaderForeignKey,
                        principalTable: "Cards",
                        principalColumn: "CardId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CardFooterItem",
                columns: table => new
                {
                    CardFooterItemId = table.Column<Guid>(type: "uuid", nullable: false),
                    CardFooterItemIsLink = table.Column<bool>(type: "boolean", nullable: false),
                    CardFooterItemLinkAddress = table.Column<string>(type: "text", nullable: true),
                    CardFooterItemContent = table.Column<string>(type: "text", nullable: true),
                    CardFooterId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardFooterItem", x => x.CardFooterItemId);
                    table.ForeignKey(
                        name: "FK_CardFooterItem_CardFooter_CardFooterId",
                        column: x => x.CardFooterId,
                        principalTable: "CardFooter",
                        principalColumn: "CardFooterId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CardFooter_CardFooterForeignKey",
                table: "CardFooter",
                column: "CardFooterForeignKey",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CardFooterItem_CardFooterId",
                table: "CardFooterItem",
                column: "CardFooterId");

            migrationBuilder.CreateIndex(
                name: "IX_CardHeader_CardHeaderForeignKey",
                table: "CardHeader",
                column: "CardHeaderForeignKey",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CardFooterItem");

            migrationBuilder.DropTable(
                name: "CardHeader");

            migrationBuilder.DropTable(
                name: "CardFooter");

            migrationBuilder.DropTable(
                name: "Cards");
        }
    }
}
