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
                values: new object[] { new Guid("b562c9b0-6a99-4a82-b796-a8bd7fbeb2d9"), null, false, null, null, null });

            migrationBuilder.InsertData(
                table: "MainCards",
                columns: new[] { "MainCardId", "CardContent", "CardHasFooter", "CardHasHeader", "CardHasImage", "CardHeaderContent", "CardHeaderIcon", "CardHeaderIsLink", "CardHeaderLinkAction", "CardHeaderLinkController", "CardImage", "CardIsLink", "CardLinkAction", "CardLinkController", "PageNameForCard" },
                values: new object[,]
                {
                    { new Guid("254c77f0-d88e-4b95-bf48-e5f2b654a50b"), new[] { "PcAssembly.png" }, false, true, false, new[] { "Сборка компьютера" }, null, false, null, null, null, true, "PcAssembly", "Home", "Index" },
                    { new Guid("4032986d-f4b7-4237-880a-694836aa56d1"), new[] { "B2b.png" }, false, true, false, new[] { "ИТ-услуги для бизнеса" }, null, false, null, null, null, true, "B2b", "Home", "Index" },
                    { new Guid("54a49128-67ce-4a96-ab1d-130eba60d103"), new[] { "LaptopsRepair.png" }, false, true, false, new[] { "Ремонт ноутбуков" }, null, false, null, null, null, true, "LaptopsRepair", "Home", "Index" },
                    { new Guid("5fd1ac9a-1804-46ea-852e-43add5b296b0"), new[] { "InternetNetworks.png" }, false, true, false, new[] { "Интернет и сети" }, null, false, null, null, null, true, "InternetNetworks", "Home", "Index" },
                    { new Guid("9165b85d-a41f-483d-81d5-99c2933419aa"), new[] { "LaptopUpgrade.png" }, false, true, false, new[] { "Модернизация ноутбука" }, null, false, null, null, null, true, "LaptopUpgrade", "Home", "Index" },
                    { new Guid("bd37250c-2559-4658-8d0f-907dd5f5c62e"), new[] { "DataRecovery.png" }, false, true, false, new[] { "Восстановление данных" }, null, false, null, null, null, true, "DataRecovery", "Home", "Index" },
                    { new Guid("d4e3f3e2-737a-40c2-8d90-70bd4e1db161"), new[] { "ComputersRepair.png" }, false, true, false, new[] { "Ремонт компьютеров" }, null, false, null, null, null, true, "ComputersRepair", "Home", "Index" },
                    { new Guid("da56262f-7e59-4ab5-a5b7-a5d30f491c7d"), new[] { "HelpDesk.png" }, false, true, false, new[] { "Компьютерная помощь" }, null, false, null, null, null, true, "HelpDesk", "Home", "Index" }
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
