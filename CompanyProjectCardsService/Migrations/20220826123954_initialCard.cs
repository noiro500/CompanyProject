using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompanyProjectCardsService.Migrations
{
    public partial class initialCard : Migration
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
                values: new object[] { new Guid("d1686e4d-6ae2-4d5d-84cf-067a363ffa65"), null, false, null, null, null });

            migrationBuilder.InsertData(
                table: "MainCards",
                columns: new[] { "MainCardId", "CardContent", "CardHasFooter", "CardHasHeader", "CardHasImage", "CardHeaderContent", "CardHeaderIcon", "CardHeaderIsLink", "CardHeaderLinkAction", "CardHeaderLinkController", "CardImage", "CardIsLink", "CardLinkAction", "CardLinkController", "PageNameForCard" },
                values: new object[,]
                {
                    { new Guid("01f679e5-07af-464e-b761-5a480344ad4e"), new[] { "InternetNetworks.png" }, false, true, false, new[] { "Интернет и сети" }, null, false, null, null, null, true, "InternetNetworks", "Home", "index" },
                    { new Guid("11fb093c-7ffd-45ed-b55e-a0fa1fe6b73e"), new[] { "DataRecovery.png" }, false, true, false, new[] { "Восстановление данных" }, null, false, null, null, null, true, "DataRecovery", "Home", "index" },
                    { new Guid("206f086c-562e-482b-b7b3-f223d0efe18d"), new[] { "PcAssembly.png" }, false, true, false, new[] { "Сборка компьютера" }, null, false, null, null, null, true, "PcAssembly", "Home", "index" },
                    { new Guid("50116b54-4127-435d-9577-8eb4675434f6"), new[] { "B2b.png" }, false, true, false, new[] { "ИТ-услуги для бизнеса" }, null, false, null, null, null, true, "B2b", "Home", "index" },
                    { new Guid("660663db-c6de-4161-93c7-00c6ffeb29a6"), new[] { "ComputersRepair.png" }, false, true, false, new[] { "Ремонт компьютеров" }, null, false, null, null, null, true, "ComputersRepair", "Home", "index" },
                    { new Guid("7e304405-ccca-4477-a572-cbb95771e6e7"), new[] { "HelpDesk.png" }, false, true, false, new[] { "Компьютерная помощь" }, null, false, null, null, null, true, "HelpDesk", "Home", "index" },
                    { new Guid("94010429-5c8e-4ff2-b1a3-f2d0b8e59bf0"), new[] { "LaptopsRepair.png" }, false, true, false, new[] { "Ремонт ноутбуков" }, null, false, null, null, null, true, "LaptopsRepair", "Home", "index" },
                    { new Guid("9756643a-e4c5-40ad-aca4-5a04feee0e1f"), new[] { "LaptopUpgrade.png" }, false, true, false, new[] { "Модернизация ноутбука" }, null, false, null, null, null, true, "LaptopUpgrade", "Home", "index" }
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
