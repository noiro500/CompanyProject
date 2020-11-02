using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace CompanyProject.API.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CompanyContacts",
                columns: table => new
                {
                    CompanyContactId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CompanyName = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    WorkTime = table.Column<string>(nullable: true),
                    WhatsApp = table.Column<string>(nullable: true),
                    ToUse = table.Column<bool>(nullable: false),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyContacts", x => x.CompanyContactId);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CustomerName = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: false),
                    AnotherPhoneNumber = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    District = table.Column<string>(nullable: false),
                    Locality = table.Column<string>(nullable: false),
                    Street = table.Column<string>(nullable: false),
                    HouseNumber = table.Column<string>(nullable: false),
                    ApartmentOrOffice = table.Column<string>(nullable: true),
                    IsAdoptedPrivacyPolicy = table.Column<bool>(nullable: false),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: false),
                    Surname = table.Column<string>(nullable: false),
                    SecondName = table.Column<string>(nullable: true),
                    Passport = table.Column<string>(nullable: false),
                    Telephone = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: false),
                    Rating = table.Column<double>(nullable: false),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    MessageId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PeopleName = table.Column<string>(nullable: false),
                    WhatsAppNumber = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    SubjectMessage = table.Column<string>(maxLength: 50, nullable: false),
                    Content = table.Column<string>(maxLength: 2000, nullable: false),
                    IsAdoptedPrivacyPolicy = table.Column<bool>(nullable: false),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.MessageId);
                });

            migrationBuilder.CreateTable(
                name: "Pages",
                columns: table => new
                {
                    PageId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: false),
                    ScreenName = table.Column<string>(nullable: true),
                    Icon = table.Column<string>(nullable: true),
                    ToNavbar = table.Column<bool>(nullable: false),
                    ToCard = table.Column<bool>(nullable: false),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pages", x => x.PageId);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeCustomer",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(nullable: false),
                    CustomerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeCustomer", x => new { x.EmployeeId, x.CustomerId });
                    table.ForeignKey(
                        name: "FK_EmployeeCustomer_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeCustomer_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TypeOfFailure = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: false),
                    CreateTime = table.Column<string>(nullable: false, defaultValue: "03.11.2020 0:00"),
                    VisitTime = table.Column<string>(nullable: false),
                    SpecialInstruction = table.Column<string>(nullable: true),
                    IsCompleted = table.Column<bool>(nullable: false, defaultValue: false),
                    Price = table.Column<decimal>(nullable: false),
                    RealPrice = table.Column<decimal>(nullable: false),
                    CustomerId = table.Column<int>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: false),
                    FeedbackId = table.Column<int>(nullable: false),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Paragraphs",
                columns: table => new
                {
                    ParagraphId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IsGlobalTitle = table.Column<bool>(nullable: false),
                    IsSubtitle = table.Column<bool>(nullable: false),
                    HasPicture = table.Column<bool>(nullable: false),
                    PicturePath = table.Column<string>(nullable: true),
                    IsList = table.Column<bool>(nullable: false),
                    IsMobileVisible = table.Column<bool>(nullable: false),
                    Content = table.Column<string[]>(nullable: true),
                    PageId = table.Column<int>(nullable: false),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true)
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

            migrationBuilder.CreateTable(
                name: "PriceLists",
                columns: table => new
                {
                    PriceListId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ServiceName = table.Column<string>(nullable: true),
                    IdServiceName = table.Column<string>(nullable: true),
                    Service = table.Column<string>(nullable: true),
                    NeedWorks = table.Column<string[]>(nullable: true),
                    ServicePrice = table.Column<string>(nullable: true),
                    PageId = table.Column<int>(nullable: false),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceLists", x => x.PriceListId);
                    table.ForeignKey(
                        name: "FK_PriceLists_Pages_PageId",
                        column: x => x.PageId,
                        principalTable: "Pages",
                        principalColumn: "PageId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Feedbacks",
                columns: table => new
                {
                    FeedbackId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Rating = table.Column<long>(maxLength: 1, nullable: false),
                    FeedbackText = table.Column<string>(maxLength: 280, nullable: true),
                    OrderForeignKey = table.Column<int>(nullable: false),
                    OrderId = table.Column<int>(nullable: false),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedbacks", x => x.FeedbackId);
                    table.ForeignKey(
                        name: "FK_Feedbacks_Orders_OrderForeignKey",
                        column: x => x.OrderForeignKey,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CompanyContacts",
                columns: new[] { "CompanyContactId", "Address", "CompanyName", "PhoneNumber", "ToUse", "WhatsApp", "WorkTime" },
                values: new object[] { 1, "РФ, Ставропольский край, Минераловодский городской округ, п. Бородыновка, ул. Железнодорожная 7а, 2", "<span class=\"has-text-black\">Нова<span> <span class=\"color-title\">Компьютерс</span>", "+7-(900)-000-00-00", true, "+7-(900)-000-00-00", "9:00 - 19:00, выходной: понедельник" });

            migrationBuilder.InsertData(
                table: "Pages",
                columns: new[] { "PageId", "Icon", "Name", "ScreenName", "ToCard", "ToNavbar" },
                values: new object[,]
                {
                    { 1, null, "Index", null, false, false },
                    { 2, "fas fa-wrench", "ComputersRepair", "Ремонт компьютеров", true, true },
                    { 3, "fas fa-laptop-medical", "LaptopsRepair", "Ремонт ноутбуков", true, true },
                    { 4, "fas fa-ambulance", "HelpDesk", "Компьютерная помощь", true, false },
                    { 5, "fas fa-network-wired", "InternetNetworks", "Интернет и сети", true, true },
                    { 6, "fas fa-database", "DataRecovery", "Восстановление данных", true, false },
                    { 7, "fas fa-industry", "B2b", "ИТ-услуги для бизнеса", true, true },
                    { 8, "fas fa-laptop", "LaptopUpgrade", "Модернизация ноутбука", true, false },
                    { 9, "fas fa-tv", "PcAssembly", "Сборка компьютера", true, false },
                    { 10, "fas fa-print", "OfficeEquipment", "Oргтехника", false, true }
                });

            migrationBuilder.InsertData(
                table: "Paragraphs",
                columns: new[] { "ParagraphId", "Content", "HasPicture", "IsGlobalTitle", "IsList", "IsMobileVisible", "IsSubtitle", "PageId", "PicturePath" },
                values: new object[,]
                {
                    { 1, new[] { "Компьютерный мастер на Кавказских Минеральных Водах" }, false, true, false, true, false, 1, null },
                    { 18, new[] { "В число компьютерных услуг входит так же помощь по установке антивирусов, драйверов, обучение пользователей работе на компьютере и прочее;", "Учтем все Ваши пожелания, обращайтесь! Мы поможем!" }, false, false, true, true, false, 1, null },
                    { 17, new[] { "Какие услуги компьютерной помощи мы можем оказать?" }, false, false, false, true, true, 1, null },
                    { 15, new[] { "Компьютерная помощь срочно и без проблем!" }, false, false, false, true, true, 1, null },
                    { 14, new[] { "Ремонт стационарных компьютеров может выполняться как у Вас на дому или в офисе, так и у нас в сервисном центре;", "Может потребоваться специальное оборудование или дополнительные запчасти. В этом случае наш специалист при Вашем желании может доставить компьютер в сервисный центр, провести работы по ремонту, а затем привезти обратно к Вам." }, false, false, true, true, false, 1, null },
                    { 13, new[] { "Каков порядок ремонта компьютеров? Где будут выполняться работы?" }, false, false, false, true, true, 1, null },
                    { 12, new[] { "Мы готовы помочь Вам с ремонтом компьютера. Специалисты нашей компании выполняют профессиональный ремонт компьютеров любых производителей недорого и в минимально возможные сроки." }, true, false, false, true, false, 1, "~/Resources/Images/remont-komputerov.jpg" },
                    { 11, new[] { "Ремонт компьютеров на дому или в офисе" }, false, false, false, true, true, 1, null },
                    { 10, new[] { "Мастер приедет в заранее согласованное с Вами время;", "Перед началом работ по настройке или ремонту компьютера, ноутбука или офисной техники специалисту необходимо будет провести диагностику;", "Подробные цены на ремонт и компьютерные услуги компании «Нова Компьютерс» Вы можете узнать в соответствующем разделе" }, false, false, true, true, false, 1, null },
                    { 16, new[] { "Компания «Nova Computers» всегда рада оказать Вам срочную компьютерную помощь! Мы выполним любые Ваши пожелания по ремонту и настройке компьютера, ноутбука, роутера, МФУ, принтера. Так же поможем установить Windows или иную операционную систему, скачать и установить любые программы и утилиты." }, true, false, false, true, false, 1, "~/Resources/Images/komputernaya-pomosh.png" },
                    { 8, new[] { "Оказываем услуги по ремонту в городах Кавказских Минеральных Вод (Минеральные Воды, Пятигорск, Ессентуки, Кисловодск) и в прилегающих носеленных пунктах." }, false, false, false, true, false, 1, null },
                    { 7, new[] { "Позвоните нам или оставьте заявку на сайте в соответствующей форме;", "Опишите Вашу проблему;", "Согласуйте время приезда компьютерного мастера." }, false, false, true, true, false, 1, null },
                    { 6, new[] { "Как вызвать компьютерного мастера на дом или в офис?" }, false, false, false, true, true, 1, null },
                    { 5, new[] { "Высококвалифицированные специалисты компании «Nova Computers» имеют большой опыт в ремонте и обслуживании любых моделей компьютеров, ноутбуков, роутеров и других видов цифровой и вычислительной техники.", "Для определения неполадок компьютера или ноутбука нашему специалисту необходимо провести начальную диагностику Вашего оборудования, с целью составления сметы на ремонт.", "Наши мастера делают только те работы, которые необходимы; мы никогда не занимамся навязыванием дополнительных, зачастую ненужных, услуг." }, false, false, false, true, false, 1, null },
                    { 4, new[] { "Вызов компьютерного мастера на дом" }, false, false, false, true, true, 1, null },
                    { 3, new[] { "_NeedHelpAndPicturePartial" }, false, false, false, false, false, 1, null },
                    { 2, new[] { "Компания «Nova Computers» предлагает Вам качественные и недорогие компьютерные услуги по обслуживанию, ремонту компьютеров, ноутбуков и офисной техники в регионе Кавказских Минеральных Вод (Минеральные Воды, Пятигорск, Ессентуки, Кисловодск). Ремонт может проводиться мастером как территории заказчика, так и в нашем сервисном центре. Мы всегда рады оперативно оказать Вам профессиональную компьютерную помощь, обращайтесь!" }, false, false, false, true, false, 1, null },
                    { 9, new[] { "Как скоро приедет мастер? Сколько будут стоить услуги по ремонту?" }, false, false, false, true, true, 1, null }
                });

            migrationBuilder.InsertData(
                table: "PriceLists",
                columns: new[] { "PriceListId", "IdServiceName", "NeedWorks", "PageId", "Service", "ServiceName", "ServicePrice" },
                values: new object[,]
                {
                    { 43, "internet-config", new[] { "Диагностика оборудования", "Антивирусная профилактика", "Настройка сетевой платы для обеспечения доступа к сети Интернет", "Поиск и устранение неисправностей сетевого оборудования", "Прочие необходимые работы" }, 5, "Устранение неполадок сети Инернет", "Интернет", "1500" },
                    { 42, "internet-config", new[] { "Диагностика оборудования", "Установка сетевого оборудования", "Прокладка сетевого кабеля", "Обжим кабеля коннектором RJ-45", "Прочие необходимые работы" }, 5, "Прокладка сетевого кабеля", "Интернет", "За метр 500" },
                    { 41, "internet-config", new[] { "Диагностика оборудования", "Установка и базовая настройка роутера", "Настройка сетевой платы", "Настройка сети Интернет по Wi-Fi сети", "Обжим кабеля коннектором RJ-45", "Прочие необходимые работы" }, 5, "Настройка доступа к сети Интернет", "Интернет", "1000" },
                    { 40, "router-config", new[] { "Диагностика оборудования", "Работы по улучшению сигнала Wi-Fi сети", "Сброс настроек, повторная настройка роутера", "Замена прошивки роутера", "Ремонт роутера", "Прочие необходимые работы" }, 5, "Устранение неполадок роутера", "Настройка роутера", "1500" },
                    { 39, "router-config", new[] { "Диагностика оборудования", "Установка и базовая настройка Wi-Fi роутера", "Индивидуальная настройка Wi-Fi роутера (настройка \"проброса\" портов, удаленного доступа, выбор оптимального канала вещания WiFi)", "Работы по улучшению сигнала Wi-Fi сети", "Настройка безопасности Wi-Fi сети", "Сброс настроек, повторная настройка Wi-Fi роутера", "Замена прошивки Wi-Fi роутера", "Прочие необходимые работы" }, 5, "Настройка Wi-Fi сети", "Настройка роутера", "1500" },
                    { 35, "laptop-upgrade", new[] { "Диагностика аппаратной части ноутбука", "Подбор и замена модулей оперативной памяти ноутбука", "Подбор и установка нового жесткого диска или SSD" }, 3, "Расширение памяти ноутбука", "Модернизация ноутбука", "1500" },
                    { 37, "laptop-service", new[] { "Частичная разборка ноутбука", "Чистка системы охлаждения процессора от пыли", "Чистка системы охлаждения видеокарты от пыли", "Чистка системы охлаждения материнмкой платы от пыли", "Замена пермопасты на процессоре", "Замена пермопасты на чипе видеокарты" }, 3, "Чистка ноутбука от пыли с заменой термопасты", "Обслуживание ноутбука", "2000" },
                    { 36, "laptop-upgrade", new[] { "Диагностика аппаратной части ноутбука", "Подбор и замена модулей оперативной памяти ноутбука", "Подбор и установка скоростного жесткого диска или SSD", "Подбор и установка новой видеокарты или процессора", "Прочие необходимые работы" }, 3, "Увеличение скорости работы ноутбука", "Модернизация ноутбука", "2000" },
                    { 34, "computer-assistance-laptop", new[] { "Диагностика оборудования", "Восстановление корректной работы, обеспечение совместимости драйвера с текущей версией операционной системы", "Настройка автозагрузки Windows", "Индивидуальные настройки операционной системы", "Удаление временных, мусорных системных файлов", "Чистка системного реестра Windows", "Индивидуальная тонкая настройка антивируса, межсетевго экрана (фаервола или брандмауэра)", "Выявление и устранение неполадок программного обеспечения", "Прочие необходимые работы" }, 3, "Настройка ноутбука", "Компьютерная помощь (ноутбук)", "1500" },
                    { 33, "computer-assistance-laptop", new[] { "Диагностика оборудования", "Поиск и установка драйвера устройства", "Восстановление корректной работы, обеспечение совместимости драйвера с текущей версией операционной системы" }, 3, "Установка драйверов (один экземпляр)", "Компьютерная помощь (ноутбук)", "600" },
                    { 44, "lan-config", new[] { "Диагностика оборудования", "Настройка работы роутера в локальной сети", "Настройка сетевой платы", "Прочие необходимые работы" }, 5, "Настройка локальной сети", "Локальная сеть", "1000" },
                    { 38, "router-config", new[] { "Диагностика оборудования", "Установка и базовая настройка роутера", "Индивидуальная настройка роутера (настройка \"проброса\" портов, удаленного доступа, выбор оптимального канала вещания WiFi)", "Сброс настроек, повторная настройка роутера", "Замена прошивки роутера", "Прочие необходимые работы" }, 5, "Установка роутера", "Настройка роутера", "1500" },
                    { 45, "lan-config", new[] { "Диагностика оборудования", "Антивирусная профилактика", "Настройка сетевой платы", "Настройка сетевого оборудования", "Поиск и устранение неисправностей сетевого оборудования", "Прочие необходимые работы" }, 5, "Устранение неполадок локальной сети", "Локальная сеть", "1500" },
                    { 54, "printer-config", new[] { "Диагностика оборудования", "Поиск и установка драйвера устройства", "Подключение и базовая настройка принтера", "Настройка работы принтера по Wi-Fi сети", "Индивидуальная настройка принтера", "Прочие необходимые работы" }, 10, "Настройка принтера", "Принтеры", "1500" },
                    { 47, "data-recovery", new[] { "Восстановление данных (случайно удаленные фотографии, документы. Случаи, когда повреждена таблица файловой системы)" }, 6, "Восстановление данных с жесткого диска", "Восстановление данных", "6000" },
                    { 48, "data-recovery", new[] { "Восстановление данных (случайно удаленные фотографии, документы; cлучаи, когда повреждена таблица файловой системы)" }, 6, "Восстановление информации с флеш-накопителя", "Восстановление данных", "6000" },
                    { 49, "data-recovery", new[] { "Восстановление данных (случайно удаленные фотографии, документы; cлучаи, когда повреждена таблица файловой системы)" }, 6, "Восстановление данных с SD-карты", "Восстановление данных", "6000" },
                    { 50, "data-recovery", new[] { "Восстановление данных (случайно удаленные фотографии, документы; cлучаи, когда повреждена таблица файловой системы)" }, 6, "Восстановление данных с SSD-диска", "Восстановление данных", "6000" },
                    { 51, "b2b", new[] { "1 (один) плановый выезд специалиста в месяц", "Полная техническая профилактика всего парка компьютеров", "Полная антивирусная профилактика всего парка компьютеров", "Устранение текущих неполадок (возможно, силами стороннего подрядчика)", "Консультации сотрудников по работе с компьютерами" }, 7, "Абонентское обслуживание компьютеров", "ИТ-услуги для бизнеса", "1000 рублей в месяц за один компьютер" },
                    { 52, "b2b", new[] { "1 (один) плановый выезд специалиста в месяц", "Полная техническая профилактика всего парка оргтехники", "Устранение текущих неполадок (возможно, силами стороннего подрядчика)", "Консультации сотрудников по работе с оргтехникой" }, 7, "Абонентское обслуживание оргтехники", "ИТ-услуги для бизнеса", "1000 рублей в месяц за единицу оборудования" },
                    { 53, "b2b", new[] { "Необходимые работы определяются заказчиком" }, 7, "Внеплановый выезд специалиста", "ИТ-услуги для бизнеса", "1000 рублей за внеплановый выезд" },
                    { 32, "computer-assistance-laptop", new[] { "Диагностика оборудования", "Подбор и установка любого антивируса", "Подбор и установка фаервола", "Индивидуальная тонкая настройка антивируса, фаервола или брандмауэра", "Прочие необходимые работы" }, 3, "Установка и настройка антивируса", "Компьютерная помощь (ноутбук)", "1000" },
                    { 55, "printer-config", new[] { "Диагностика оборудования", "Чистка и профилактика принтера", "Полная чистка и смазка с частичной разборкой принтера", "Прочие необходимые работы" }, 10, "Очистка принтера", "Принтеры", "2000" },
                    { 56, "printer-config", new[] { "Диагностика оборудования", "Восстановление работоспособности печатающей головки струйного принтера", "Ремонт электроники принтера", "Замена фотоцилиндра, магнитного вала или ракеля лазерного принтера", "Прочие необходимые работы" }, 10, "Ремонт принтера", "Принтеры", "5000" },
                    { 57, "mfd-config", new[] { "Поиск и установка драйвера устройства", "Подключение и базовая настройка МФУ", "Калибровка сканирующей части МФУ", "Настройка работы МФУ по Wi-Fi сети", "Настройка работы МФУ по локальной сети", "Индивидуальная настройка МФУ", "Прочие необходимые работы" }, 10, "Настройка МФУ", "Многофункциональное устройство (МФУ)", "2000" },
                    { 58, "mfd-config", new[] { "Диагностика оборудования", "Чистка и профилактика МФУ", "Полная чистка и смазка с частичной разборкой МФУ", "Калибровка сканирующей части МФУ", "Прочие необходимые работы" }, 10, "Очистка МФУ", "Многофункциональное устройство (МФУ)", "2500" },
                    { 59, "mfd-config", new[] { "Диагностика оборудования", "Восстановление работоспособности печатающей головки струйного МФУ", "Ремонт электроники МФУ", "Замена фотоцилиндра, магнитного вала или ракеля лазерного МФУ", "Ремонт сканирующей части МФУ", "Прочие необходимые работы" }, 10, "Ремонт МФУ", "Многофункциональное устройство (МФУ)", "5500" },
                    { 46, "lan-config", new[] { "Диагностика оборудования", "Установка сетевого оборудования", "Прокладка сетевого кабеля", "Обжим кабеля коннектором RJ-45", "Прочие необходимые работы" }, 5, "Прокладка сетевого кабеля", "Локальная сеть", "За метр 500" },
                    { 31, "computer-assistance-laptop", new[] { "Диагностика оборудования", "Установка программ" }, 3, "Установка программ (один экземпляр)", "Компьютерная помощь (ноутбук)", "400" },
                    { 22, "laptop-repair", new[] { "Диагностика оборудования", "Замена материнской платы ноутбука", "Замена блока питания ноутбука", "Работы по замене шлейфов или питающих кабелей", "Ремонт блока питания (проводится в сервисном центре)", "Замена отдельных комплектующих ноутбука", "Прочие необходимые работы" }, 3, "Красный экран на ноутбуке", "Ремонт ноутбуков", "2500" },
                    { 29, "computer-assistance-laptop", new[] { "Диагностика оборудования", "Установка Windows XP - Windows 10", "Поиск и установка драйвера устройства", "Индивидуальные настройки операционной системы", "Разбивка жесткого диска на разделы", "Прочие необходимые работы" }, 3, "Установка Windows (включая установку драйверов на оборудование)", "Компьютерная помощь (ноутбук)", "2000" },
                    { 1, "computers-repair", new[] { "Диагностика оборудования", "Замена материнской платы компьютера", "Замена блока питания компьютера", "Работы по замене шлейфов или питающих кабелей", "Ремонт блока питания (проводится в сервисном центре)", "Восстановление работоспособности (замена) кнопки включения", "Прочие необходимые работы" }, 2, "Не включается компьютер", "Ремонт компьютеров", "2000" },
                    { 2, "computers-repair", new[] { "Диагностика оборудования", "Замена материнской платы компьютера", "Замена блока питания компьютера", "Работы по замене шлейфов или питающих кабелей", "Ремонт блока питания (проводится в сервисном центре)", "Восстановление работоспособности (замена) кнопки включения", "Прочие необходимые работы" }, 2, "Красный экран на компьютере", "Ремонт компьютеров", "2000" },
                    { 3, "computers-repair", new[] { "Диагностика оборудования", "Установка Windows XP - Windows 10", "Поиск и установка драйверов устройств", "Восстановление корректной работы, обеспечение совместимости драйвера с текущей версией операционной системы", "Удаление временных, мусорных системных файлов", "Чистка системного реестра Windows", "Устранение последствий действия вирусов, восстановление работы операционной системы", "Выявление и устранение неполадок программного обеспечения", "Поиск и исправление ошибок системного реестра Windows", "Настройка таймингов оперативной памяти в BIOS", "Устранение перегрева компьютера, профилактические работы, чистка от пыли, замена термопасты и термопрокладок", "Основная антивирусная профилактика (удаление СМС-вымогателя, трояна, баннера, других вирусов)", "Прочие необходимые работы" }, 2, "Синий экран на компьютере", "Ремонт компьютеров", "1500" },
                    { 4, "computers-repair", new[] { "Диагностика оборудования", "Восстановление корректной работы, обеспечение совместимости драйвера с текущей версией операционной системы", "Настройка автозагрузки Windows", "Удаление временных, мусорных системных файлов", "Чистка системного реестра Windows", "Выявление и устранение неполадок программного обеспечения", "Поиск и исправление ошибок системного реестра Windows", "Настройка таймингов оперативной памяти в BIOS", "Основная антивирусная профилактика (удаление СМС-вымогателя, трояна, баннера, других вирусов)", "Прочие необходимые работы" }, 2, "Ошибки в работе компьютера", "Ремонт компьютеров", "2500" },
                    { 5, "computers-repair", new[] { "Диагностика оборудования", "Установка Windows XP - Windows 10", "Настройка автозагрузки Windows", "Удаление временных, мусорных системных файлов", "Чистка системного реестра Windows", "Поиск и исправление ошибок системного реестра Windows", "Устранение перегрева компьютера, профилактические работы, чистка от пыли, замена термопасты и термопрокладок", "Основная антивирусная профилактика (удаление СМС-вымогателя, трояна, баннера, других вирусов)", "Глубокая антивирусная профилактика (устранение последствий действия вирусов, восстановление работы операционной системы)", "Прочие необходимые работы" }, 2, "Зависает компьютер", "Ремонт компьютеров", "2000" },
                    { 6, "computers-repair", new[] { "Диагностика оборудования", "Выявление и устранение неполадок программного обеспечения", "Замена оперативной памяти компьютера", "Устранение перегрева компьютера, профилактические работы, чистка от пыли, замена термопасты и термопрокладок", "Прочие необходимые работы" }, 2, "Самопроизвольная перезагрузка компьютера", "Ремонт компьютеров", "2000" },
                    { 7, "computers-repair", new[] { "Диагностика оборудования", "Замена вентилятора (кулера) компьютера", "Замена системы охлаждения компьютера", "Устранение перегрева компьютера, профилактические работы, чистка от пыли, замена термопасты и термопрокладок", "Прочие необходимые работы" }, 2, "Шумит компьютер", "Ремонт компьютеров", "1500" },
                    { 8, "computers-repair", new[] { "Диагностика оборудования", "Замена вентилятора (кулера) компьютера", "Замена системы охлаждения компьютера", "Устранение перегрева компьютера, профилактические работы, чистка от пыли, замена термопасты и термопрокладок", "Прочие необходимые работы" }, 2, "Перегревается компьютер", "Ремонт компьютеров", "1500" },
                    { 9, "computers-repair", new[] { "Диагностика оборудования", "Установка Windows XP - Windows 10", "Основная антивирусная профилактика (удаление СМС-вымогателя, трояна, баннера, других вирусов)", "Замена материнской платы компьютера", "Замена блока питания компьютера", "Замена жесткого диска компьютера", "Замена вентилятора (кулера) компьютера", "Замена системы охлаждения компьютера", "Работы по замене шлейфов или питающих кабелей", "Прочие необходимые работы" }, 2, "Прочие проблемы с компьютером", "Ремонт компьютеров", "2000" },
                    { 10, "computer-assistance-pc", new[] { "Диагностика оборудования", "Установка Windows XP - Windows 10", "Поиск и установка драйвера устройства", "Индивидуальные настройки операционной системы", "Разбивка жесткого диска на разделы", "Прочие необходимые работы" }, 2, "Установка Windows (включая установку драйверов на оборудование)", "Компьютерная помощь (компьютер)", "1500" },
                    { 11, "computer-assistance-pc", new[] { "Диагностика оборудования", "Основная антивирусная профилактика (удаление СМС-вымогателя, трояна, баннера, других вирусов)", "Глубокая антивирусная профилактика (Устранение последствий действия вирусов, восстановление работы операционной системы)", "Установка Windows XP - Windows 10", "Прочие необходимые работы" }, 2, "Удаление вирусов", "Компьютерная помощь (компьютер)", "1000" },
                    { 12, "computer-assistance-pc", new[] { "Диагностика оборудования", "Установка программ" }, 2, "Установка программ (один экземпляр)", "Компьютерная помощь (компьютер)", "200" },
                    { 13, "computer-assistance-pc", new[] { "Диагностика оборудования", "Подбор и установка любого антивируса", "Подбор и установка фаервола", "Индивидуальная тонкая настройка антивируса, фаервола или брандмауэра", "Прочие необходимые работы" }, 2, "Установка и настройка антивируса", "Компьютерная помощь (компьютер)", "700" },
                    { 30, "computer-assistance-laptop", new[] { "Диагностика оборудования", "Основная антивирусная профилактика (удаление СМС-вымогателя, трояна, баннера, других вирусов)", "Глубокая антивирусная профилактика (Устранение последствий действия вирусов, восстановление работы операционной системы)", "Установка Windows XP - Windows 10", "Прочие необходимые работы" }, 3, "Удаление вирусов", "Компьютерная помощь (ноутбук)", "1500" },
                    { 14, "computer-assistance-pc", new[] { "Диагностика оборудования", "Поиск и установка драйвера устройства", "Восстановление корректной работы, обеспечение совместимости драйвера с текущей версией операционной системы" }, 2, "Установка драйверов (один экземпляр)", "Компьютерная помощь (компьютер)", "300" },
                    { 16, "pc-assembly", new[] { "Сборка компьютера на заказ" }, 2, "Сборка компьютера на заказ", "Сборка компьютера", "10% от стоимости компьютера + 500" },
                    { 17, "pc-assembly", new[] { "Диагностика оборудования", "Модернизация компьютера на заказ" }, 2, "Модернизация компьютера на заказ", "Сборка компьютера", "10% от стоимости новых комплектующих + 500" },
                    { 18, "pc-service", new[] { "Частичная разборка системного блока", "Чистка системы охлаждения процессора от пыли", "Чистка системы охлаждения видеокарты от пыли", "Чистка системы охлаждения материнмкой платы от пыли", "Замена пермопасты на процессоре", "Замена пермопасты на чипе видеокарты" }, 2, "Чистка компьютера от пыли с заменой термопасты", "Обслуживание компьютера", "1500" },
                    { 19, "pc-service", new[] { "Чистка системы охлаждения процессора от пыли", "Чистка системы охлаждения видеокарты от пыли", "Чистка системы охлаждения материнмкой платы от пыли" }, 2, "Чистка компьютера от пыли без разборки системного блока", "Обслуживание компьютера", "1000" },
                    { 20, "laptop-repair", new[] { "Диагностика оборудования", "Замена материнской платы ноутбука", "Замена жесткого диска ноутбука", "Замена оперативной памяти ноутбука", "Замена видеокарты ноутбука", "Работы по замене шлейфа или питающих кабелей ноутбука", "Ремонт цепи питания ноутбука", "Ремонт материнской платы ноутбука", "Устранение перегрева ноутбука, профилактические работы, чистка от пыли, замена термопасты и термопрокладок", "Прочие необходимые работы" }, 3, "Не включается ноутбук", "Ремонт ноутбуков", "2500" },
                    { 21, "laptop-repair", new[] { "Диагностика оборудования", "Замена оперативной памяти ноутбука", "Замена видеокарты ноутбука", "Замена жесткого диска ноутбука", "Замена материнской платы ноутбука", "Ремонт системы охлаждения ноутбука", "Восстановление работоспособности жесткого диска ноутбука, повторная разметка секторов (Remap)", "Устранение перегрева ноутбука, профилактические работы, чистка от пыли, замена термопасты и термопрокладок", "Прочие необходимые работы" }, 3, "Синий экран на ноутбуке", "Ремонт ноутбуков", "2500" },
                    { 60, "scanner-config", new[] { "Диагностика оборудования", "Поиск и установка драйвера устройства", "Подключение и базовая настройка сканера", "Калибровка сканера", "Настройка работы сканера по Wi-Fi сети", "Настройка работы сканера по локальной сети", "Индивидуальная настройка сканера", "Прочие необходимые работы" }, 10, "Настройка сканера", "Сканирующие устройства (сканеры)", "1500" },
                    { 23, "laptop-repair", new[] { "Диагностика оборудования", "Восстановление корректной работы, обеспечение совместимости драйвера с текущей версией операционной системы", "Настройка автозагрузки Windows", "Удаление временных, мусорных системных файлов", "Чистка системного реестра Windows", "Основная антивирусная профилактика (удаление СМС-вымогателя, трояна, баннера, других вирусов) ", "Выявление и устранение неполадок программного обеспечения", "Поиск и исправление ошибок системного реестра Windows", "Восстановление работоспособности жесткого диска ноутбука, повторная разметка секторов (Remap)", "Прочие необходимые работы" }, 3, "Ошибки в работе ноутбука", "Ремонт ноутбуков", "3000" },
                    { 24, "laptop-repair", new[] { "Диагностика оборудования", "Установка Windows XP - Windows 10", "Восстановление корректной работы, обеспечение совместимости драйвера с текущей версией операционной системы", "Удаление временных, мусорных системных файлов", "Чистка системного реестра Windows", "Глубокая антивирусная профилактика (устранение последствий действия вирусов, восстановление работы операционной системы)", "Выявление и устранение неполадок программного обеспечения", "Поиск и исправление ошибок системного реестра Windows", "Ремонт системы охлаждения ноутбука", "Устранение перегрева ноутбука, профилактические работы, чистка от пыли, замена термопасты и термопрокладок", "Прочие необходимые работы" }, 3, "Зависает ноутбук", "Ремонт ноутбуков", "2500" },
                    { 25, "laptop-repair", new[] { "Диагностика оборудования", "Восстановление корректной работы, обеспечение совместимости драйвера с текущей версией операционной системы", "Чистка системного реестра Windows", "Выявление и устранение неполадок программного обеспечения", "Поиск и исправление ошибок системного реестра Windows", "Ремонт системы охлаждения ноутбука", "Устранение перегрева ноутбука, профилактические работы, чистка от пыли, замена термопасты и термопрокладок", "Замена оперативной памяти ноутбука", "Ремонт цепи питания ноутбука", "Прочие необходимые работы" }, 3, "Самопроизвольная перезагрузка ноутбука", "Ремонт ноутбуков", "2500" },
                    { 26, "laptop-repair", new[] { "Диагностика оборудования", "Замена вентилятора (кулера) ноутбука", "Ремонт системы охлаждения ноутбука", "Устранение перегрева ноутбука, профилактические работы, чистка от пыли, замена термопасты и термопрокладок", "Прочие необходимые работы" }, 3, "Шумит ноутбук", "Ремонт ноутбуков", "2000" },
                    { 27, "laptop-repair", new[] { "Диагностика оборудования", "Замена вентилятора (кулера) ноутбука", "Ремонт системы охлаждения ноутбука", "Устранение перегрева ноутбука, профилактические работы, чистка от пыли, замена термопасты и термопрокладок", "Прочие необходимые работы" }, 3, "Перегревается ноутбук", "Ремонт ноутбуков", "2000" },
                    { 28, "laptop-repair", new[] { "Диагностика оборудования", "Прочие необходимые работы" }, 3, "Прочие проблемы с ноутбуком", "Ремонт ноутбуков", "2500" },
                    { 15, "computer-assistance-pc", new[] { "Диагностика оборудования", "Восстановление корректной работы, обеспечение совместимости драйвера с текущей версией операционной системы", "Настройка автозагрузки Windows", "Индивидуальные настройки операционной системы", "Удаление временных, мусорных системных файлов", "Чистка системного реестра Windows", "Индивидуальная тонкая настройка антивируса, фаервола или брандмауэра", "Выявление и устранение неполадок программного обеспечения", "Прочие необходимые работы" }, 2, "Настройка компьютера", "Компьютерная помощь (компьютер)", "1000" },
                    { 61, "scanner-config", new[] { "Диагностика оборудования", "Ремонт инвертора лампы подсветки", "Замена лампы подсветки", "Ремонт других электронных узлов сканера", "Ремонт механики сканирующей головки", "Прочие необходимые работы" }, 10, "Ремонт сканера", "Сканирующие устройства (сканеры)", "5000" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_PhoneNumber",
                table: "Customers",
                column: "PhoneNumber");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeCustomer_CustomerId",
                table: "EmployeeCustomer",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_OrderForeignKey",
                table: "Feedbacks",
                column: "OrderForeignKey",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_FeedbackId_FeedbackText_Rating",
                table: "Feedbacks",
                columns: new[] { "FeedbackId", "FeedbackText", "Rating" });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_EmployeeId",
                table: "Orders",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_VisitTime",
                table: "Orders",
                column: "VisitTime");

            migrationBuilder.CreateIndex(
                name: "IX_Pages_Name",
                table: "Pages",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Paragraphs_Content",
                table: "Paragraphs",
                column: "Content");

            migrationBuilder.CreateIndex(
                name: "IX_Paragraphs_PageId",
                table: "Paragraphs",
                column: "PageId");

            migrationBuilder.CreateIndex(
                name: "IX_PriceLists_PageId",
                table: "PriceLists",
                column: "PageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyContacts");

            migrationBuilder.DropTable(
                name: "EmployeeCustomer");

            migrationBuilder.DropTable(
                name: "Feedbacks");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Paragraphs");

            migrationBuilder.DropTable(
                name: "PriceLists");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Pages");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
