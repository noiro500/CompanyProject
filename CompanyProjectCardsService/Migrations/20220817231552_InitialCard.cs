using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompanyProjectCardsService.Migrations
{
    public partial class InitialCard : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MainCards",
                columns: table => new
                {
                    MainCardId = table.Column<Guid>(type: "uuid", nullable: false),
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
                    CardFooterItemId = table.Column<Guid>(type: "uuid", nullable: false),
                    CardFooterItemIsLink = table.Column<bool>(type: "boolean", nullable: false),
                    CardFooterItemLinkController = table.Column<string>(type: "text", nullable: true),
                    CardFooterItemLinkAction = table.Column<string>(type: "text", nullable: true),
                    CardFooterItemContent = table.Column<string>(type: "text", nullable: true),
                    MainCardId = table.Column<Guid>(type: "uuid", nullable: true)
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
                values: new object[] { new Guid("aa78bffb-0326-4d35-b238-99404a20c4a8"), null, false, null, null, null });

            migrationBuilder.InsertData(
                table: "MainCards",
                columns: new[] { "MainCardId", "CardContent", "CardHasFooter", "CardHasHeader", "CardHasImage", "CardHeaderContent", "CardHeaderIcon", "CardHeaderIsLink", "CardHeaderLinkAction", "CardHeaderLinkController", "CardImage", "CardIsLink", "CardLinkAction", "CardLinkController", "PageNameForCard" },
                values: new object[,]
                {
                    { new Guid("1d4a6dab-3743-459d-97e2-5018a01b5e11"), new[] { "Image_LaptopsRepair.png" }, false, true, false, new[] { "Ремонт ноутбуков" }, null, false, null, null, null, true, "LaptopsRepair", "Home", "Index" },
                    { new Guid("31022cbe-59ba-46a4-a492-d143369416ed"), new[] { "Image_LaptopUpgrade.png" }, false, true, false, new[] { "Модернизация ноутбука" }, null, false, null, null, null, true, "LaptopUpgrade", "Home", "Index" },
                    { new Guid("47b3ce27-e5c0-4563-9219-5433684bcfb4"), new[] { "Image_PcAssembly.png" }, false, true, false, new[] { "Сборка компьютера" }, null, false, null, null, null, true, "PcAssembly", "Home", "Index" },
                    { new Guid("8baa4bdb-3534-4a09-b647-5baaeb935bc2"), new[] { "Image_DataRecovery.png" }, false, true, false, new[] { "Восстановление данных" }, null, false, null, null, null, true, "DataRecovery", "Home", "Index" },
                    { new Guid("a7b1e1e2-d028-4858-bff5-4e77dcaf2141"), new[] { "Image_B2b.png" }, false, true, false, new[] { "ИТ-услуги для бизнеса" }, null, false, null, null, null, true, "B2b", "Home", "Index" },
                    { new Guid("d527d592-ba09-4265-8eba-1a87346d200d"), new[] { "Image_ComputersRepair.png" }, false, true, false, new[] { "Ремонт компьютеров" }, null, false, null, null, null, true, "ComputersRepair", "Home", "Index" },
                    { new Guid("d81ce3ba-b404-43c5-a848-963ef8fdcd3f"), new[] { "Image_HelpDesk.png" }, false, true, false, new[] { "Компьютерная помощь" }, null, false, null, null, null, true, "HelpDesk", "Home", "Index" },
                    { new Guid("e8aa9a89-0472-4668-b182-9a3af235512a"), new[] { "Image_InternetNetworks.png" }, false, true, false, new[] { "Интернет и сети" }, null, false, null, null, null, true, "InternetNetworks", "Home", "Index" }
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
