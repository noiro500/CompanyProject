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
                values: new object[] { new Guid("eb550533-7e69-4850-9528-030a2ad3f209"), null, false, null, null, null });

            migrationBuilder.InsertData(
                table: "MainCards",
                columns: new[] { "MainCardId", "CardContent", "CardHasFooter", "CardHasHeader", "CardHasImage", "CardHeaderContent", "CardHeaderIcon", "CardHeaderIsLink", "CardHeaderLinkAction", "CardHeaderLinkController", "CardImage", "CardIsLink", "CardLinkAction", "CardLinkController", "PageNameForCard" },
                values: new object[,]
                {
                    { new Guid("3afb5150-3bb6-4196-8f28-235ca9d27f0f"), new[] { "Image_DataRecovery.png" }, false, true, false, new[] { "Восстановление данных" }, null, false, null, null, null, true, "DataRecovery", "Home", "Index" },
                    { new Guid("4d10ea4e-3bbc-4b60-8946-ab26e0afdd0f"), new[] { "Image_LaptopUpgrade.png" }, false, true, false, new[] { "Модернизация ноутбука" }, null, false, null, null, null, true, "LaptopUpgrade", "Home", "Index" },
                    { new Guid("9511c1d1-9ae9-419b-8435-01cc816ac4a6"), new[] { "Image_PcAssembly.png" }, false, true, false, new[] { "Сборка компьютера" }, null, false, null, null, null, true, "PcAssembly", "Home", "Index" },
                    { new Guid("ac0f78c6-7ab0-4489-9da4-a9ecf93b2828"), new[] { "Image_B2b.png" }, false, true, false, new[] { "ИТ-услуги для бизнеса" }, null, false, null, null, null, true, "B2b", "Home", "Index" },
                    { new Guid("b35fc5ec-5873-4937-9b8c-0aee5bbf1549"), new[] { "Image_HelpDesk.png" }, false, true, false, new[] { "Компьютерная помощь" }, null, false, null, null, null, true, "HelpDesk", "Home", "Index" },
                    { new Guid("da218596-e949-47ae-9eec-5adeca9642b0"), new[] { "Image_InternetNetworks.png" }, false, true, false, new[] { "Интернет и сети" }, null, false, null, null, null, true, "InternetNetworks", "Home", "Index" },
                    { new Guid("ec1c1d43-45d6-4c0b-99cf-bb410ed8b3be"), new[] { "Image_ComputersRepair.png" }, false, true, false, new[] { "Ремонт компьютеров" }, null, false, null, null, null, true, "ComputersRepair", "Home", "Index" },
                    { new Guid("ff51059b-dd49-438f-89e0-50329ff1e9ab"), new[] { "Image_LaptopsRepair.png" }, false, true, false, new[] { "Ремонт ноутбуков" }, null, false, null, null, null, true, "LaptopsRepair", "Home", "Index" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CardFooterItem_MainCardId",
                table: "CardFooterItem",
                column: "MainCardId");
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
