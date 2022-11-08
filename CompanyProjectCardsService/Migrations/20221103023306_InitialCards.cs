using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CompanyProjectCardsService.Migrations
{
    public partial class InitialCards : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MainCards",
                columns: table => new
                {
                    MainCardId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PageNameForCard = table.Column<string>(type: "text", nullable: false),
                    CardIsLink = table.Column<bool>(type: "boolean", nullable: false),
                    CardLinkController = table.Column<string>(type: "text", nullable: true),
                    CardLinkAction = table.Column<string>(type: "text", nullable: true),
                    CardHasHeader = table.Column<bool>(type: "boolean", nullable: false),
                    CardHeaderIsLink = table.Column<bool>(type: "boolean", nullable: false),
                    CardHeaderLinkController = table.Column<string>(type: "text", nullable: true),
                    CardHeaderLinkAction = table.Column<string>(type: "text", nullable: true),
                    CardHeaderContent = table.Column<string[]>(type: "text[]", nullable: true),
                    CardHeaderIcon = table.Column<string>(type: "text", nullable: true),
                    CardHasImage = table.Column<bool>(type: "boolean", nullable: false),
                    CardImage = table.Column<string>(type: "text", nullable: true),
                    CardContent = table.Column<string[]>(type: "text[]", nullable: true),
                    CardHasFooter = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainCards", x => x.MainCardId);
                });

            migrationBuilder.CreateTable(
                name: "CardFooterItem",
                columns: table => new
                {
                    CardFooterItemId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CardFooterItemIsLink = table.Column<bool>(type: "boolean", nullable: false),
                    CardFooterItemLinkController = table.Column<string>(type: "text", nullable: true),
                    CardFooterItemLinkAction = table.Column<string>(type: "text", nullable: true),
                    CardFooterItemContent = table.Column<string>(type: "text", nullable: true),
                    MainCardId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardFooterItem", x => x.CardFooterItemId);
                    table.ForeignKey(
                        name: "FK_CardFooterItem_MainCards_MainCardId",
                        column: x => x.MainCardId,
                        principalTable: "MainCards",
                        principalColumn: "MainCardId");
                });

            migrationBuilder.InsertData(
                table: "CardFooterItem",
                columns: new[] { "CardFooterItemId", "CardFooterItemContent", "CardFooterItemIsLink", "CardFooterItemLinkAction", "CardFooterItemLinkController", "MainCardId" },
                values: new object[] { 1, null, false, null, null, null });

            migrationBuilder.InsertData(
                table: "MainCards",
                columns: new[] { "MainCardId", "CardContent", "CardHasFooter", "CardHasHeader", "CardHasImage", "CardHeaderContent", "CardHeaderIcon", "CardHeaderIsLink", "CardHeaderLinkAction", "CardHeaderLinkController", "CardImage", "CardIsLink", "CardLinkAction", "CardLinkController", "PageNameForCard" },
                values: new object[,]
                {
                    { 1, new[] { "ComputersRepair.png" }, false, true, false, new[] { "Ремонт компьютеров" }, null, false, null, null, null, true, "ComputersRepair", "Home", "index" },
                    { 2, new[] { "LaptopsRepair.png" }, false, true, false, new[] { "Ремонт ноутбуков" }, null, false, null, null, null, true, "LaptopsRepair", "Home", "index" },
                    { 3, new[] { "HelpDesk.png" }, false, true, false, new[] { "Компьютерная помощь" }, null, false, null, null, null, true, "HelpDesk", "Home", "index" },
                    { 4, new[] { "InternetNetworks.png" }, false, true, false, new[] { "Интернет и сети" }, null, false, null, null, null, true, "InternetNetworks", "Home", "index" },
                    { 5, new[] { "DataRecovery.png" }, false, true, false, new[] { "Восстановление данных" }, null, false, null, null, null, true, "DataRecovery", "Home", "index" },
                    { 6, new[] { "B2b.png" }, false, true, false, new[] { "ИТ-услуги для бизнеса" }, null, false, null, null, null, true, "B2b", "Home", "index" },
                    { 7, new[] { "LaptopUpgrade.png" }, false, true, false, new[] { "Модернизация ноутбука" }, null, false, null, null, null, true, "LaptopUpgrade", "Home", "index" },
                    { 8, new[] { "PcAssembly.png" }, false, true, false, new[] { "Сборка компьютера" }, null, false, null, null, null, true, "PcAssembly", "Home", "index" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CardFooterItem_MainCardId",
                table: "CardFooterItem",
                column: "MainCardId");

            migrationBuilder.CreateIndex(
                name: "IX_MainCards_PageNameForCard",
                table: "MainCards",
                column: "PageNameForCard");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CardFooterItem");

            migrationBuilder.DropTable(
                name: "MainCards");
        }
    }
}
