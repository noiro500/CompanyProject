﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompanyProjectPriceListService.Migrations
{
    public partial class initialPriceList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PriceLists",
                columns: table => new
                {
                    PriceListId = table.Column<Guid>(type: "uuid", nullable: false),
                    ServiceName = table.Column<string>(type: "text", nullable: false),
                    PageName = table.Column<string>(type: "text", nullable: false),
                    IdServiceName = table.Column<string>(type: "text", nullable: false),
                    Service = table.Column<string>(type: "text", nullable: false),
                    NeedWorks = table.Column<string[]>(type: "text[]", nullable: true),
                    ServicePrice = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceLists", x => x.PriceListId);
                });

            migrationBuilder.InsertData(
                table: "PriceLists",
                columns: new[] { "PriceListId", "IdServiceName", "NeedWorks", "PageName", "Service", "ServiceName", "ServicePrice" },
                values: new object[,]
                {
                    { new Guid("02072a71-02be-4b71-8102-2840c993b404"), "laptop-repair", new[] { "Диагностика оборудования", "Восстановление корректной работы, обеспечение совместимости драйвера с текущей версией операционной системы", "Настройка автозагрузки Windows", "Удаление временных, мусорных системных файлов", "Чистка системного реестра Windows", "Основная антивирусная профилактика (удаление СМС-вымогателя, трояна, баннера, других вирусов) ", "Выявление и устранение неполадок программного обеспечения", "Поиск и исправление ошибок системного реестра Windows", "Восстановление работоспособности жесткого диска ноутбука, повторная разметка секторов (Remap)", "Прочие необходимые работы" }, "LaptopsRepair", "Устарнение ошибок при работе ноутбука", "Ремонт ноутбуков", "6000" },
                    { new Guid("02dd5a94-8993-4f86-85f0-88a4433a9bd7"), "b2b", new[] { "1 (один) плановый выезд специалиста в месяц", "Полная техническая профилактика всего парка оргтехники", "Устранение текущих неполадок (возможно, силами стороннего подрядчика)", "Консультации сотрудников по работе с оргтехникой" }, "B2b", "Абонентское обслуживание оргтехники", "ИТ-услуги для бизнеса", "в месяц за единицу оборудования - 2000" },
                    { new Guid("142e9697-0611-472b-ae36-f50cfda48ad1"), "data-recovery", new[] { "Восстановление данных (случайно удаленные фотографии, документы; cлучаи, когда повреждена таблица файловой системы)" }, "DataRecovery", "Восстановление данных с SSD-диска", "Восстановление данных", "12000" },
                    { new Guid("187c80ee-0757-4691-9d4c-88f412a1a99a"), "data-recovery", new[] { "Восстановление данных (случайно удаленные фотографии, документы; cлучаи, когда повреждена таблица файловой системы)" }, "DataRecovery", "Восстановление данных с SD-карты", "Восстановление данных", "12000" },
                    { new Guid("1ac3c2c7-2960-467c-8762-db7ccc42b034"), "computer-assistance-laptop", new[] { "Диагностика оборудования", "Основная антивирусная профилактика (удаление СМС-вымогателя, трояна, баннера, других вирусов)", "Глубокая антивирусная профилактика (Устранение последствий действия вирусов, восстановление работы операционной системы)", "Установка Windows XP - Windows 10", "Прочие необходимые работы" }, "LaptopsRepair", "Удаление вирусов", "Компьютерная помощь (ноутбук)", "3000" },
                    { new Guid("1af837bb-0c1f-40ae-8c46-10e0c81678fa"), "scanner-config", new[] { "Диагностика оборудования", "Ремонт инвертора лампы подсветки", "Замена лампы подсветки", "Ремонт других электронных узлов сканера", "Ремонт механики сканирующей головки", "Прочие необходимые работы" }, "OfficeEquipment", "Ремонт сканера", "Сканирующие устройства (сканеры)", "10000" },
                    { new Guid("1eaf4860-71dd-4fcc-94de-e8effe676242"), "computer-assistance-pc", new[] { "Диагностика оборудования", "Поиск и установка драйвера устройства", "Восстановление корректной работы, обеспечение совместимости драйвера с текущей версией операционной системы" }, "ComputersRepair", "Установка драйверов (один экземпляр)", "Компьютерная помощь (компьютер)", "600" },
                    { new Guid("26dcc5c0-8588-4610-ae83-303372e0a73b"), "computer-assistance-pc", new[] { "Диагностика оборудования", "Восстановление корректной работы, обеспечение совместимости драйвера с текущей версией операционной системы", "Настройка автозагрузки Windows", "Индивидуальные настройки операционной системы", "Удаление временных, мусорных системных файлов", "Чистка системного реестра Windows", "Индивидуальная тонкая настройка антивируса, фаервола или брандмауэра", "Выявление и устранение неполадок программного обеспечения", "Прочие необходимые работы" }, "ComputersRepair", "Настройка компьютера", "Компьютерная помощь (компьютер)", "2000" },
                    { new Guid("30ef3f42-2dd3-4f66-b1a1-a5e18f7cb273"), "computers-repair", new[] { "Диагностика оборудования", "Замена материнской платы компьютера", "Замена блока питания компьютера", "Работы по замене шлейфов или питающих кабелей", "Ремонт блока питания (проводится в сервисном центре)", "Восстановление работоспособности (замена) кнопки включения", "Прочие необходимые работы" }, "ComputersRepair", "Устранение \"красного экрана\" на компьютере", "Ремонт компьютеров", "4000" },
                    { new Guid("3519f203-7d93-4b0f-a348-830d7f50d509"), "computers-repair", new[] { "Диагностика оборудования", "Установка Windows XP - Windows 10", "Настройка автозагрузки Windows", "Удаление временных, мусорных системных файлов", "Чистка системного реестра Windows", "Поиск и исправление ошибок системного реестра Windows", "Устранение перегрева компьютера, профилактические работы, чистка от пыли, замена термопасты и термопрокладок", "Основная антивирусная профилактика (удаление СМС-вымогателя, трояна, баннера, других вирусов)", "Глубокая антивирусная профилактика (устранение последствий действия вирусов, восстановление работы операционной системы)", "Прочие необходимые работы" }, "ComputersRepair", "Устранение зависания компьютера", "Ремонт компьютеров", "4000" },
                    { new Guid("362d6a15-05ed-4164-94dd-aef7147a2c99"), "computers-repair", new[] { "Диагностика оборудования", "Замена вентилятора (кулера) компьютера", "Замена системы охлаждения компьютера", "Устранение перегрева компьютера, профилактические работы, чистка от пыли, замена термопасты и термопрокладок", "Прочие необходимые работы" }, "ComputersRepair", "Устранение перегрева компьютера", "Ремонт компьютеров", "3000" },
                    { new Guid("3d58ad51-dee5-49aa-99d8-3bcf2b5e3736"), "laptop-repair", new[] { "Диагностика оборудования", "Замена вентилятора (кулера) ноутбука", "Ремонт системы охлаждения ноутбука", "Устранение перегрева ноутбука, профилактические работы, чистка от пыли, замена термопасты и термопрокладок", "Прочие необходимые работы" }, "LaptopsRepair", "Устранение перегрева ноутбука", "Ремонт ноутбуков", "4000" },
                    { new Guid("3f9b1e33-2204-418e-8386-db2c14f3c46a"), "lan-config", new[] { "Диагностика оборудования", "Антивирусная профилактика", "Настройка сетевой платы", "Настройка сетевого оборудования", "Поиск и устранение неисправностей сетевого оборудования", "Прочие необходимые работы" }, "InternetNetworks", "Устранение неполадок локальной сети", "Локальная сеть", "3000" },
                    { new Guid("3ffecd42-202b-4610-801e-ba4c90463d22"), "computer-assistance-laptop", new[] { "Диагностика оборудования", "Подбор и установка любого антивируса", "Подбор и установка фаервола", "Индивидуальная тонкая настройка антивируса, фаервола или брандмауэра", "Прочие необходимые работы" }, "LaptopsRepair", "Установка и настройка антивируса", "Компьютерная помощь (ноутбук)", "2000" },
                    { new Guid("437354db-11ac-4507-8634-664fea125b22"), "laptop-service", new[] { "Частичная разборка ноутбука", "Чистка системы охлаждения процессора от пыли", "Чистка системы охлаждения видеокарты от пыли", "Чистка системы охлаждения материнмкой платы от пыли", "Замена пермопасты на процессоре", "Замена пермопасты на чипе видеокарты" }, "LaptopsRepair", "Чистка ноутбука от пыли с заменой термопасты", "Обслуживание ноутбука", "4000" },
                    { new Guid("4c70f54f-f09b-4b90-a697-03779e5c69cb"), "laptop-repair", new[] { "Диагностика оборудования", "Замена вентилятора (кулера) ноутбука", "Ремонт системы охлаждения ноутбука", "Устранение перегрева ноутбука, профилактические работы, чистка от пыли, замена термопасты и термопрокладок", "Прочие необходимые работы" }, "LaptopsRepair", "Устарнение повышенного шума ноутбука", "Ремонт ноутбуков", "4000" },
                    { new Guid("4da64841-e4ac-4d84-8f5d-e619212f95b6"), "laptop-repair", new[] { "Диагностика оборудования", "Прочие необходимые работы" }, "LaptopsRepair", "Прочие проблемы с ноутбуком", "Ремонт ноутбуков", "5000" },
                    { new Guid("53118410-1df3-4f6b-8d06-a1b02c099fb2"), "internet-config", new[] { "Диагностика оборудования", "Установка сетевого оборудования", "Прокладка сетевого кабеля", "Обжим кабеля коннектором RJ-45", "Прочие необходимые работы" }, "InternetNetworks", "Прокладка сетевого кабеля", "Интернет", "За метр 700" },
                    { new Guid("5a9fc48c-26ff-446a-8c89-10c322762102"), "printer-config", new[] { "Диагностика оборудования", "Чистка и профилактика принтера", "Полная чистка и смазка с частичной разборкой принтера", "Прочие необходимые работы" }, "OfficeEquipment", "Очистка принтера", "Принтеры", "4000" },
                    { new Guid("5be1369e-ccfd-42f3-b494-4b930342b348"), "computers-repair", new[] { "Диагностика оборудования", "Замена материнской платы компьютера", "Замена блока питания компьютера", "Работы по замене шлейфов или питающих кабелей", "Ремонт блока питания (проводится в сервисном центре)", "Восстановление работоспособности (замена) кнопки включения", "Прочие необходимые работы" }, "ComputersRepair", "Компьютер не включается", "Ремонт компьютеров", "4000" },
                    { new Guid("5e9a2641-ab55-46f9-9808-8d23f0a1c4f9"), "mfd-config", new[] { "Диагностика оборудования", "Чистка и профилактика МФУ", "Полная чистка и смазка с частичной разборкой МФУ", "Калибровка сканирующей части МФУ", "Прочие необходимые работы" }, "OfficeEquipment", "Очистка МФУ", "Многофункциональное устройство (МФУ)", "5000" },
                    { new Guid("62f80580-b2b2-4421-9c1b-b5f5788dc59e"), "mfd-config", new[] { "Диагностика оборудования", "Восстановление работоспособности печатающей головки струйного МФУ", "Ремонт электроники МФУ", "Замена фотоцилиндра, магнитного вала или ракеля лазерного МФУ", "Ремонт сканирующей части МФУ", "Прочие необходимые работы" }, "OfficeEquipment", "Ремонт МФУ", "Многофункциональное устройство (МФУ)", "11000" },
                    { new Guid("66b30977-2e72-441e-a39d-66b039862d24"), "laptop-repair", new[] { "Диагностика оборудования", "Замена материнской платы ноутбука", "Замена блока питания ноутбука", "Работы по замене шлейфов или питающих кабелей", "Ремонт блока питания (проводится в сервисном центре)", "Замена отдельных комплектующих ноутбука", "Прочие необходимые работы" }, "LaptopsRepair", "Устранение \"синего экрана\" на ноутбуке", "Ремонт ноутбуков", "5000" },
                    { new Guid("6c761a07-d494-47d9-becf-6d14d7e2e3c3"), "computer-assistance-pc", new[] { "Диагностика оборудования", "Подбор и установка любого антивируса", "Подбор и установка фаервола", "Индивидуальная тонкая настройка антивируса, фаервола или брандмауэра", "Прочие необходимые работы" }, "ComputersRepair", "Установка и настройка антивируса", "Компьютерная помощь (компьютер)", "1400" },
                    { new Guid("6d55642f-800b-44f7-932d-3b2da255fbec"), "printer-config", new[] { "Диагностика оборудования", "Восстановление работоспособности печатающей головки струйного принтера", "Ремонт электроники принтера", "Замена фотоцилиндра, магнитного вала или ракеля лазерного принтера", "Прочие необходимые работы" }, "OfficeEquipment", "Ремонт принтера", "Принтеры", "10000" },
                    { new Guid("6ebffd05-8bd7-46d7-9736-82a003cf7278"), "computers-repair", new[] { "Диагностика оборудования", "Выявление и устранение неполадок программного обеспечения", "Замена оперативной памяти компьютера", "Устранение перегрева компьютера, профилактические работы, чистка от пыли, замена термопасты и термопрокладок", "Прочие необходимые работы" }, "ComputersRepair", "Устранение самопроизвольной перезагрузки компьютера", "Ремонт компьютеров", "4000" },
                    { new Guid("6f239129-abde-4ac0-86d1-e417fd915a59"), "router-config", new[] { "Диагностика оборудования", "Установка и базовая настройка роутера", "Индивидуальная настройка роутера (настройка \"проброса\" портов, удаленного доступа, выбор оптимального канала вещания WiFi)", "Сброс настроек, повторная настройка роутера", "Замена прошивки роутера", "Прочие необходимые работы" }, "InternetNetworks", "Установка роутера", "Настройка роутера", "3000" },
                    { new Guid("74c31114-797a-4a78-b8bf-d299c886a1ba"), "b2b", new[] { "Необходимые работы определяются заказчиком" }, "B2b", "Внеплановый выезд специалиста", "ИТ-услуги для бизнеса", "за внеплановый выезд - 3000" },
                    { new Guid("7a75876c-e2e8-4bb4-b62c-1e41e6020ee2"), "computers-repair", new[] { "Диагностика оборудования", "Установка Windows XP - Windows 10", "Основная антивирусная профилактика (удаление СМС-вымогателя, трояна, баннера, других вирусов)", "Замена материнской платы компьютера", "Замена блока питания компьютера", "Замена жесткого диска компьютера", "Замена вентилятора (кулера) компьютера", "Замена системы охлаждения компьютера", "Работы по замене шлейфов или питающих кабелей", "Прочие необходимые работы" }, "ComputersRepair", "Прочие проблемы с компьютером", "Ремонт компьютеров", "4000" },
                    { new Guid("7aed5a77-d1a4-40ac-8473-f2164ea78f05"), "laptop-upgrade", new[] { "Диагностика аппаратной части ноутбука", "Подбор и замена модулей оперативной памяти ноутбука", "Подбор и установка скоростного жесткого диска или SSD", "Подбор и установка новой видеокарты или процессора", "Прочие необходимые работы" }, "LaptopsRepair", "Увеличение скорости работы ноутбука", "Модернизация ноутбука", "4000" },
                    { new Guid("7f2981b8-b55a-42ad-a670-56fa1aca8a55"), "computers-repair", new[] { "Диагностика оборудования", "Установка Windows XP - Windows 11", "Поиск и установка драйверов устройств", "Восстановление корректной работы, обеспечение совместимости драйвера с текущей версией операционной системы", "Удаление временных, мусорных системных файлов", "Чистка системного реестра Windows", "Устранение последствий действия вирусов, восстановление работы операционной системы", "Выявление и устранение неполадок программного обеспечения", "Поиск и исправление ошибок системного реестра Windows", "Настройка таймингов оперативной памяти в BIOS", "Устранение перегрева компьютера, профилактические работы, чистка от пыли, замена термопасты и термопрокладок", "Основная антивирусная профилактика (удаление СМС-вымогателя, трояна, баннера, других вирусов)", "Прочие необходимые работы" }, "ComputersRepair", "Устранение \"синего экрана\" на компьютере", "Ремонт компьютеров", "3000" },
                    { new Guid("8019781d-50d8-4c54-9989-340fd5b3ffe3"), "laptop-repair", new[] { "Диагностика оборудования", "Замена оперативной памяти ноутбука", "Замена видеокарты ноутбука", "Замена жесткого диска ноутбука", "Замена материнской платы ноутбука", "Ремонт системы охлаждения ноутбука", "Восстановление работоспособности жесткого диска ноутбука, повторная разметка секторов (Remap)", "Устранение перегрева ноутбука, профилактические работы, чистка от пыли, замена термопасты и термопрокладок", "Прочие необходимые работы" }, "LaptopsRepair", "Устранение \"красного экрана\" на ноутбуке", "Ремонт ноутбуков", "5000" },
                    { new Guid("812658bb-a145-4a37-8272-56dca4d47b02"), "printer-config", new[] { "Диагностика оборудования", "Поиск и установка драйвера устройства", "Подключение и базовая настройка принтера", "Настройка работы принтера по Wi-Fi сети", "Индивидуальная настройка принтера", "Прочие необходимые работы" }, "OfficeEquipment", "Настройка принтера", "Принтеры", "3000" },
                    { new Guid("82776ae9-715e-4bcc-b743-a2543a13eab5"), "internet-config", new[] { "Диагностика оборудования", "Установка и базовая настройка роутера", "Настройка сетевой платы", "Настройка сети Интернет по Wi-Fi сети", "Обжим кабеля коннектором RJ-45", "Прочие необходимые работы" }, "InternetNetworks", "Настройка доступа к сети Интернет", "Интернет", "2000" },
                    { new Guid("8bbd8982-ce82-49f9-ac80-7f33aa9496a9"), "scanner-config", new[] { "Диагностика оборудования", "Поиск и установка драйвера устройства", "Подключение и базовая настройка сканера", "Калибровка сканера", "Настройка работы сканера по Wi-Fi сети", "Настройка работы сканера по локальной сети", "Индивидуальная настройка сканера", "Прочие необходимые работы" }, "OfficeEquipment", "Настройка сканера", "Сканирующие устройства (сканеры)", "3000" },
                    { new Guid("9727600e-30e3-411e-827d-e02ddae1edc6"), "laptop-repair", new[] { "Диагностика оборудования", "Установка Windows XP - Windows 10", "Восстановление корректной работы, обеспечение совместимости драйвера с текущей версией операционной системы", "Удаление временных, мусорных системных файлов", "Чистка системного реестра Windows", "Глубокая антивирусная профилактика (устранение последствий действия вирусов, восстановление работы операционной системы)", "Выявление и устранение неполадок программного обеспечения", "Поиск и исправление ошибок системного реестра Windows", "Ремонт системы охлаждения ноутбука", "Устранение перегрева ноутбука, профилактические работы, чистка от пыли, замена термопасты и термопрокладок", "Прочие необходимые работы" }, "LaptopsRepair", "Устранение зависания ноутбука", "Ремонт ноутбуков", "5000" },
                    { new Guid("9a969020-9f70-4514-9629-7631584811a8"), "lan-config", new[] { "Диагностика оборудования", "Настройка работы роутера в локальной сети", "Настройка сетевой платы", "Прочие необходимые работы" }, "InternetNetworks", "Настройка локальной сети", "Локальная сеть", "2000" },
                    { new Guid("9ab15977-6020-47b6-bc37-1783275ad078"), "computer-assistance-pc", new[] { "Диагностика оборудования", "Установка Windows XP - Windows 10", "Поиск и установка драйвера устройства", "Индивидуальные настройки операционной системы", "Разбивка жесткого диска на разделы", "Прочие необходимые работы" }, "ComputersRepair", "Установка Windows (включая установку драйверов на оборудование)", "Компьютерная помощь (компьютер)", "3000" },
                    { new Guid("9f158b87-e404-4a74-b446-5adcdb9e7901"), "pc-assembly", new[] { "Сборка компьютера на заказ" }, "ComputersRepair", "Сборка компьютера на заказ", "Сборка компьютера", "10% от стоимости компьютера + 500" },
                    { new Guid("a2d020f7-6b7e-44d2-89f8-2564f1be6def"), "computer-assistance-pc", new[] { "Диагностика оборудования", "Установка программ" }, "ComputersRepair", "Установка программ (один экземпляр)", "Компьютерная помощь (компьютер)", "400" },
                    { new Guid("a545741c-123e-4a88-8a25-5a0084c4b07e"), "b2b", new[] { "1 (один) плановый выезд специалиста в месяц", "Полная техническая профилактика всего парка компьютеров", "Полная антивирусная профилактика всего парка компьютеров", "Устранение текущих неполадок (возможно, силами стороннего подрядчика)", "Консультации сотрудников по работе с компьютерами" }, "B2b", "Абонентское обслуживание компьютеров", "ИТ-услуги для бизнеса", "в месяц за один компьютер - 2000" },
                    { new Guid("a78b4b23-61c0-4590-a926-95be189916a2"), "computers-repair", new[] { "Диагностика оборудования", "Восстановление корректной работы, обеспечение совместимости драйвера с текущей версией операционной системы", "Настройка автозагрузки Windows", "Удаление временных, мусорных системных файлов", "Чистка системного реестра Windows", "Выявление и устранение неполадок программного обеспечения", "Поиск и исправление ошибок системного реестра Windows", "Настройка таймингов оперативной памяти в BIOS", "Основная антивирусная профилактика (удаление СМС-вымогателя, трояна, баннера, других вирусов)", "Прочие необходимые работы" }, "ComputersRepair", "Устарнение ошибок при работе компьютера", "Ремонт компьютеров", "5000" },
                    { new Guid("ab744dbd-4b04-4452-9f75-4bfc8610e43a"), "laptop-upgrade", new[] { "Диагностика аппаратной части ноутбука", "Подбор и замена модулей оперативной памяти ноутбука", "Подбор и установка нового жесткого диска или SSD" }, "LaptopsRepair", "Расширение памяти ноутбука", "Модернизация ноутбука", "3000" },
                    { new Guid("ac248403-9d3a-4198-a9eb-47437c2faf8a"), "computer-assistance-laptop", new[] { "Диагностика оборудования", "Установка Windows XP - Windows 10", "Поиск и установка драйвера устройства", "Индивидуальные настройки операционной системы", "Разбивка жесткого диска на разделы", "Прочие необходимые работы" }, "LaptopsRepair", "Установка Windows (включая установку драйверов на оборудование)", "Компьютерная помощь (ноутбук)", "4000" },
                    { new Guid("ad0cee0e-5ef1-47c3-b222-f048cad9ff7e"), "router-config", new[] { "Диагностика оборудования", "Работы по улучшению сигнала Wi-Fi сети", "Сброс настроек, повторная настройка роутера", "Замена прошивки роутера", "Ремонт роутера", "Прочие необходимые работы" }, "InternetNetworks", "Устранение неполадок роутера", "Настройка роутера", "3000" },
                    { new Guid("b6c414dc-ca45-4ffe-80fc-edc4aa3b2b71"), "data-recovery", new[] { "Восстановление данных (случайно удаленные фотографии, документы. Случаи, когда повреждена таблица файловой системы)" }, "DataRecovery", "Восстановление данных с жесткого диска", "Восстановление данных", "12000" },
                    { new Guid("b8b8a2b5-ef75-4176-ba69-a57559bcc58d"), "pc-service", new[] { "Частичная разборка системного блока", "Чистка системы охлаждения процессора от пыли", "Чистка системы охлаждения видеокарты от пыли", "Чистка системы охлаждения материнмкой платы от пыли", "Замена пермопасты на процессоре", "Замена пермопасты на чипе видеокарты" }, "ComputersRepair", "Чистка компьютера от пыли с заменой термопасты", "Обслуживание компьютера", "3000" },
                    { new Guid("b93b0817-986a-4160-8396-0ef79618cbf3"), "pc-service", new[] { "Чистка системы охлаждения процессора от пыли", "Чистка системы охлаждения видеокарты от пыли", "Чистка системы охлаждения материнмкой платы от пыли" }, "ComputersRepair", "Чистка компьютера от пыли без замены термопасты", "Обслуживание компьютера", "2000" },
                    { new Guid("c03fa110-4892-4eef-9e38-80649795131b"), "laptop-repair", new[] { "Диагностика оборудования", "Замена материнской платы ноутбука", "Замена жесткого диска ноутбука", "Замена оперативной памяти ноутбука", "Замена видеокарты ноутбука", "Работы по замене шлейфа или питающих кабелей ноутбука", "Ремонт цепи питания ноутбука", "Ремонт материнской платы ноутбука", "Устранение перегрева ноутбука, профилактические работы, чистка от пыли, замена термопасты и термопрокладок", "Прочие необходимые работы" }, "LaptopsRepair", "Не включается ноутбук", "Ремонт ноутбуков", "5000" },
                    { new Guid("c35c1b4d-03af-4459-8c3a-a630c47102a4"), "data-recovery", new[] { "Восстановление данных (случайно удаленные фотографии, документы; cлучаи, когда повреждена таблица файловой системы)" }, "DataRecovery", "Восстановление информации с флеш-накопителя", "Восстановление данных", "12000" },
                    { new Guid("cbb30756-1eeb-40dc-ba84-1ee518eed923"), "computer-assistance-laptop", new[] { "Диагностика оборудования", "Восстановление корректной работы, обеспечение совместимости драйвера с текущей версией операционной системы", "Настройка автозагрузки Windows", "Индивидуальные настройки операционной системы", "Удаление временных, мусорных системных файлов", "Чистка системного реестра Windows", "Индивидуальная тонкая настройка антивируса, межсетевго экрана (фаервола или брандмауэра)", "Выявление и устранение неполадок программного обеспечения", "Прочие необходимые работы" }, "LaptopsRepair", "Настройка ноутбука", "Компьютерная помощь (ноутбук)", "3000" },
                    { new Guid("d1b6493a-75c9-4d36-9e35-76333da6b71a"), "lan-config", new[] { "Диагностика оборудования", "Установка сетевого оборудования", "Прокладка сетевого кабеля", "Обжим кабеля коннектором RJ-45", "Прочие необходимые работы" }, "InternetNetworks", "Прокладка сетевого кабеля", "Локальная сеть", "За метр 700" },
                    { new Guid("db59b798-4fb8-4740-833e-72f94bfece16"), "pc-assembly", new[] { "Диагностика оборудования", "Модернизация компьютера на заказ" }, "ComputersRepair", "Модернизация компьютера на заказ", "Сборка компьютера", "10% от стоимости новых комплектующих + 500" },
                    { new Guid("dc95b505-b43a-46e9-9a75-2a53abbba4e2"), "computer-assistance-pc", new[] { "Диагностика оборудования", "Основная антивирусная профилактика (удаление СМС-вымогателя, трояна, баннера, других вирусов)", "Глубокая антивирусная профилактика (Устранение последствий действия вирусов, восстановление работы операционной системы)", "Установка Windows XP - Windows 10", "Прочие необходимые работы" }, "ComputersRepair", "Удаление вирусов", "Компьютерная помощь (компьютер)", "2000" },
                    { new Guid("de53cb63-9192-489e-affb-64110cbef6ff"), "router-config", new[] { "Диагностика оборудования", "Установка и базовая настройка Wi-Fi роутера", "Индивидуальная настройка Wi-Fi роутера (настройка \"проброса\" портов, удаленного доступа, выбор оптимального канала вещания WiFi)", "Работы по улучшению сигнала Wi-Fi сети", "Настройка безопасности Wi-Fi сети", "Сброс настроек, повторная настройка Wi-Fi роутера", "Замена прошивки Wi-Fi роутера", "Прочие необходимые работы" }, "InternetNetworks", "Настройка Wi-Fi сети", "Настройка роутера", "3000" },
                    { new Guid("e51a815c-f51d-4e1a-af42-78512de81e04"), "laptop-repair", new[] { "Диагностика оборудования", "Восстановление корректной работы, обеспечение совместимости драйвера с текущей версией операционной системы", "Чистка системного реестра Windows", "Выявление и устранение неполадок программного обеспечения", "Поиск и исправление ошибок системного реестра Windows", "Ремонт системы охлаждения ноутбука", "Устранение перегрева ноутбука, профилактические работы, чистка от пыли, замена термопасты и термопрокладок", "Замена оперативной памяти ноутбука", "Ремонт цепи питания ноутбука", "Прочие необходимые работы" }, "LaptopsRepair", "Устранение самопроизвольной перезагрузки ноутбука", "Ремонт ноутбуков", "5000" },
                    { new Guid("e6eed92e-1aec-40be-99cb-6453e038cca3"), "computer-assistance-laptop", new[] { "Диагностика оборудования", "Установка программ" }, "LaptopsRepair", "Установка программ (один экземпляр)", "Компьютерная помощь (ноутбук)", "800" },
                    { new Guid("ea570c49-3832-4188-9401-044788c52fdd"), "mfd-config", new[] { "Поиск и установка драйвера устройства", "Подключение и базовая настройка МФУ", "Калибровка сканирующей части МФУ", "Настройка работы МФУ по Wi-Fi сети", "Настройка работы МФУ по локальной сети", "Индивидуальная настройка МФУ", "Прочие необходимые работы" }, "OfficeEquipment", "Настройка МФУ", "Многофункциональное устройство (МФУ)", "4000" },
                    { new Guid("edbd2b97-2f00-49d0-bc97-8d73332e4a6d"), "computer-assistance-laptop", new[] { "Диагностика оборудования", "Поиск и установка драйвера устройства", "Восстановление корректной работы, обеспечение совместимости драйвера с текущей версией операционной системы" }, "LaptopsRepair", "Установка драйверов (один экземпляр)", "Компьютерная помощь (ноутбук)", "1200" },
                    { new Guid("fe9fd491-c2be-4894-9556-c378f6710486"), "computers-repair", new[] { "Диагностика оборудования", "Замена вентилятора (кулера) компьютера", "Замена системы охлаждения компьютера", "Устранение перегрева компьютера, профилактические работы, чистка от пыли, замена термопасты и термопрокладок", "Прочие необходимые работы" }, "ComputersRepair", "Устарнение повышенного шума компьютера", "Ремонт компьютеров", "3000" },
                    { new Guid("ff44e018-814e-4dc8-8c35-65ee31ca923d"), "internet-config", new[] { "Диагностика оборудования", "Антивирусная профилактика", "Настройка сетевой платы для обеспечения доступа к сети Интернет", "Поиск и устранение неисправностей сетевого оборудования", "Прочие необходимые работы" }, "InternetNetworks", "Устранение неполадок сети Инернет", "Интернет", "3000" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PriceLists");
        }
    }
}
