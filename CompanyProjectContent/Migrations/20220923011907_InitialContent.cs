using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CompanyProjectContentService.Migrations
{
    public partial class InitialContent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pages",
                columns: table => new
                {
                    PageId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    ScreenName = table.Column<string>(type: "text", nullable: true),
                    Icon = table.Column<string>(type: "text", nullable: true),
                    ToNavbar = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pages", x => x.PageId);
                });

            migrationBuilder.CreateTable(
                name: "TopMenuEntities",
                columns: table => new
                {
                    TopMenuEntityId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstLine = table.Column<bool>(type: "boolean", nullable: false),
                    AspAction = table.Column<string>(type: "text", nullable: false),
                    AspController = table.Column<string>(type: "text", nullable: false),
                    Icon = table.Column<string>(type: "text", nullable: false),
                    IconColor = table.Column<string>(type: "text", nullable: false),
                    NavBar = table.Column<bool>(type: "boolean", nullable: false),
                    NeedStar = table.Column<bool>(type: "boolean", nullable: false),
                    ScreenName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TopMenuEntities", x => x.TopMenuEntityId);
                });

            migrationBuilder.CreateTable(
                name: "Paragraphs",
                columns: table => new
                {
                    ParagraphId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IsGlobalTitle = table.Column<bool>(type: "boolean", nullable: false),
                    IsSubtitle = table.Column<bool>(type: "boolean", nullable: false),
                    HasPicture = table.Column<bool>(type: "boolean", nullable: false),
                    PicturePath = table.Column<string>(type: "text", nullable: true),
                    IsList = table.Column<bool>(type: "boolean", nullable: false),
                    IsMobileVisible = table.Column<bool>(type: "boolean", nullable: false),
                    Content = table.Column<string[]>(type: "text[]", nullable: false),
                    PageId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paragraphs", x => x.ParagraphId);
                    table.ForeignKey(
                        name: "FK_Paragraphs_Pages_PageId",
                        column: x => x.PageId,
                        principalTable: "Pages",
                        principalColumn: "PageId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Pages",
                columns: new[] { "PageId", "Icon", "Name", "ScreenName", "ToNavbar" },
                values: new object[,]
                {
                    { 1, null, "Index", null, false },
                    { 2, "fas fa-wrench", "ComputersRepair", "Ремонт компьютеров", true },
                    { 3, "fas fa-laptop-medical", "LaptopsRepair", "Ремонт ноутбуков", true },
                    { 4, "fas fa-ambulance", "HelpDesk", "Компьютерная помощь", true },
                    { 5, "fas fa-network-wired", "InternetNetworks", "Интернет и сети", true },
                    { 6, "fas fa-database", "DataRecovery", "Восстановление данных", false },
                    { 7, "fas fa-industry", "B2b", "ИТ-услуги для бизнеса", true },
                    { 8, "fas fa-laptop", "LaptopUpgrade", "Модернизация ноутбука", false },
                    { 9, "fas fa-tv", "PcAssembly", "Сборка компьютера", false },
                    { 10, "fas fa-print", "OfficeEquipment", "Oргтехника", true }
                });

            migrationBuilder.InsertData(
                table: "TopMenuEntities",
                columns: new[] { "TopMenuEntityId", "AspAction", "AspController", "FirstLine", "Icon", "IconColor", "NavBar", "NeedStar", "ScreenName" },
                values: new object[,]
                {
                    { 1, "Comments", "MenuFirstLine", true, "fas fa-star", "orange", false, true, "Отзывы" },
                    { 2, "FullPriceList", "MenuFirstLine", true, "fas fa-ruble-sign", "gray", false, false, "Цены" },
                    { 3, "About", "MenuFirstLine", true, "fas fa-info", "gray", false, false, "О Компании" },
                    { 4, "Contacts", "MenuFirstLine", true, "fas fa-map-marker-alt", "gray", false, false, "Контакты" },
                    { 5, "ComputersRepair", "Home", false, "fas fa-wrench", "black", true, false, "Ремонт компьютеров" },
                    { 6, "LaptopsRepair", "Home", false, "fas fa-laptop-medical", "black", true, false, "Ремонт ноутбуков" },
                    { 7, "HelpDesk", "Home", false, "fas fa-ambulance", "black", true, false, "Компьютерная помощь" },
                    { 8, "InternetNetworks", "Home", false, "fas fa-network-wired", "black", true, false, "Интернет и сети" },
                    { 9, "DataRecovery", "Home", false, "fas fa-database", "black", false, false, "Восстановление данных" },
                    { 10, "B2b", "Home", false, "fas fa-industry", "black", true, false, "ИТ-услуги для бизнеса" },
                    { 11, "LaptopUpgrade", "Home", false, "fas fa-laptop", "black", false, false, "LaptopUpgrade" },
                    { 12, "PcAssembly", "Home", false, "fas fa-tv", "black", false, false, "Сборка компьютера" },
                    { 13, "OfficeEquipment", "Home", false, "fas fa-print", "black", true, false, "Oргтехника" }
                });

            migrationBuilder.InsertData(
                table: "Paragraphs",
                columns: new[] { "ParagraphId", "Content", "HasPicture", "IsGlobalTitle", "IsList", "IsMobileVisible", "IsSubtitle", "PageId", "PicturePath" },
                values: new object[,]
                {
                    { 1, new[] { "Ремонт и обслуживание компьютерной техники на Кавказских Минеральных Водах" }, false, true, false, true, false, 1, null },
                    { 2, new[] { "Компания «Нова Компьютерс» предлагает Вам качественные и недорогие компьютерные услуги по обслуживанию, ремонту компьютеров, ноутбуков и офисной техники в регионе Кавказских Минеральных Вод (Минеральные Воды, Пятигорск, Ессентуки, Кисловодск). Ремонт может проводиться как территории заказчика, так и в нашем сервисном центре. Мы всегда рады оперативно оказать Вам профессиональную компьютерную помощь, обращайтесь!" }, false, false, false, true, false, 1, null },
                    { 3, new[] { "_NeedHelpAndPicturePartial" }, false, false, false, false, false, 1, null },
                    { 4, new[] { "Вызов компьютерного мастера на дом" }, false, false, false, true, true, 1, null },
                    { 5, new[] { "Высококвалифицированные специалисты компании «Нова Компьютерс» имеют большой опыт в ремонте и обслуживании любых моделей компьютеров, ноутбуков, роутеров и других видов цифровой и вычислительной техники.", "Для определения неполадок компьютера или ноутбука нашему специалисту необходимо провести начальную диагностику Вашего оборудования, с целью составления сметы на ремонт.", "Наши мастера делают только те работы, которые необходимы; <b>мы никогда не занимаемся навязыванием дополнительных, зачастую ненужных, услуг.</b>" }, false, false, false, true, false, 1, null },
                    { 6, new[] { "Как вызвать компьютерного мастера на дом или в офис?" }, false, false, false, true, true, 1, null },
                    { 7, new[] { "Позвоните нам или оставьте заявку на сайте в соответствующей форме;", "Опишите Вашу проблему;", "Согласуйте время приезда компьютерного мастера." }, false, false, true, true, false, 1, null },
                    { 8, new[] { "Оказываем услуги по ремонту в городах Кавказских Минеральных Вод (Минеральные Воды, Пятигорск, Ессентуки, Кисловодск) и в прилегающих населенных пунктах." }, false, false, false, true, false, 1, null },
                    { 9, new[] { "Как скоро приедет мастер? Сколько будут стоить услуги по ремонту?" }, false, false, false, true, true, 1, null },
                    { 10, new[] { "Мастер приедет в заранее согласованное с Вами время;", "Перед началом работ по настройке или ремонту компьютера, ноутбука или офисной техники специалисту необходимо будет провести диагностику;", "Подробные цены на ремонт и компьютерные услуги компании «Нова Компьютерс» Вы можете узнать в разделе \"Цены\"." }, false, false, true, true, false, 1, null },
                    { 11, new[] { "Ремонт компьютеров на дому или в офисе" }, false, false, false, true, true, 1, null },
                    { 12, new[] { "Мы готовы помочь Вам с ремонтом компьютерной техники. Специалисты нашей компании выполняют профессиональный ремонт компьютеров любых производителей недорого и в минимально возможные сроки." }, true, false, false, true, false, 1, "~/Resources/Images/remont-komputerov.jpg" },
                    { 13, new[] { "Каков порядок ремонта компьютерной техники? Где будут выполняться работы?" }, false, false, false, true, true, 1, null },
                    { 14, new[] { "Ремонт стационарных компьютеров может выполняться как у Вас на дому или в офисе, так и у нас в сервисном центре;", "Может потребоваться специальное оборудование или дополнительные запчасти. В этом случае наш специалист при Вашем желании может доставить компьютер в сервисный центр, провести работы по ремонту, а затем привезти обратно к Вам." }, false, false, true, true, false, 1, null },
                    { 15, new[] { "Компьютерная помощь срочно и без проблем!" }, false, false, false, true, true, 1, null },
                    { 16, new[] { "Компания «Нова Компьютерс» всегда рада оказать Вам срочную компьютерную помощь! Мы выполним любые Ваши пожелания по ремонту и настройке компьютера, ноутбука, роутера, МФУ, принтера. Так же поможем установить Windows или иную операционную систему, скачать и установить любые программы и утилиты." }, true, false, false, true, false, 1, "~/Resources/Images/komputernaya-pomosh.png" },
                    { 17, new[] { "Какие услуги компьютерной помощи мы можем оказать?" }, false, false, false, true, true, 1, null },
                    { 18, new[] { "В число компьютерных услуг входит так же помощь по установке антивирусов, драйверов, обучение пользователей работе на компьютере и прочее;", "Учтем все Ваши пожелания, обращайтесь! Мы поможем!" }, false, false, true, true, false, 1, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Paragraphs_PageId",
                table: "Paragraphs",
                column: "PageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Paragraphs");

            migrationBuilder.DropTable(
                name: "TopMenuEntities");

            migrationBuilder.DropTable(
                name: "Pages");
        }
    }
}
