﻿// <auto-generated />
using System;
using CompanyProjectContentService.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CompanyProjectContentService.Migrations
{
    [DbContext(typeof(CompanyProjectContentDbContext))]
    partial class CompanyProjectContentDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CompanyProjectContentService.Models.Page.Page", b =>
                {
                    b.Property<int>("PageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("PageId"));

                    b.Property<string>("Icon")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ScreenName")
                        .HasColumnType("text");

                    b.Property<bool>("ToNavbar")
                        .HasColumnType("boolean");

                    b.HasKey("PageId");

                    b.ToTable("Pages");

                    b.HasData(
                        new
                        {
                            PageId = 1,
                            Name = "Index",
                            ToNavbar = false
                        },
                        new
                        {
                            PageId = 2,
                            Icon = "fas fa-wrench",
                            Name = "ComputersRepair",
                            ScreenName = "Ремонт компьютеров",
                            ToNavbar = true
                        },
                        new
                        {
                            PageId = 3,
                            Icon = "fas fa-laptop-medical",
                            Name = "LaptopsRepair",
                            ScreenName = "Ремонт ноутбуков",
                            ToNavbar = true
                        },
                        new
                        {
                            PageId = 4,
                            Icon = "fas fa-ambulance",
                            Name = "HelpDesk",
                            ScreenName = "Компьютерная помощь",
                            ToNavbar = true
                        },
                        new
                        {
                            PageId = 5,
                            Icon = "fas fa-network-wired",
                            Name = "InternetNetworks",
                            ScreenName = "Интернет и сети",
                            ToNavbar = true
                        },
                        new
                        {
                            PageId = 6,
                            Icon = "fas fa-database",
                            Name = "DataRecovery",
                            ScreenName = "Восстановление данных",
                            ToNavbar = false
                        },
                        new
                        {
                            PageId = 7,
                            Icon = "fas fa-industry",
                            Name = "B2b",
                            ScreenName = "ИТ-услуги для бизнеса",
                            ToNavbar = true
                        },
                        new
                        {
                            PageId = 8,
                            Icon = "fas fa-laptop",
                            Name = "LaptopUpgrade",
                            ScreenName = "Модернизация ноутбука",
                            ToNavbar = false
                        },
                        new
                        {
                            PageId = 9,
                            Icon = "fas fa-tv",
                            Name = "PcAssembly",
                            ScreenName = "Сборка компьютера",
                            ToNavbar = false
                        },
                        new
                        {
                            PageId = 10,
                            Icon = "fas fa-print",
                            Name = "OfficeEquipment",
                            ScreenName = "Oргтехника",
                            ToNavbar = true
                        });
                });

            modelBuilder.Entity("CompanyProjectContentService.Models.Paragraph.Paragraph", b =>
                {
                    b.Property<int>("ParagraphId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ParagraphId"));

                    b.Property<string[]>("Content")
                        .IsRequired()
                        .HasColumnType("text[]");

                    b.Property<bool>("HasPicture")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsGlobalTitle")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsList")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsMobileVisible")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsSubtitle")
                        .HasColumnType("boolean");

                    b.Property<int>("PageId")
                        .HasColumnType("integer");

                    b.Property<string>("PicturePath")
                        .HasColumnType("text");

                    b.HasKey("ParagraphId");

                    b.HasIndex("PageId");

                    b.ToTable("Paragraphs");

                    b.HasData(
                        new
                        {
                            ParagraphId = 1,
                            Content = new[] { "Ремонт и обслуживание компьютерной техники на Кавказских Минеральных Водах" },
                            HasPicture = false,
                            IsGlobalTitle = true,
                            IsList = false,
                            IsMobileVisible = true,
                            IsSubtitle = false,
                            PageId = 1
                        },
                        new
                        {
                            ParagraphId = 2,
                            Content = new[] { "Компания «Нова Компьютерс» предлагает Вам качественные и недорогие компьютерные услуги по обслуживанию, ремонту компьютеров, ноутбуков и офисной техники в регионе Кавказских Минеральных Вод (Минеральные Воды, Пятигорск, Ессентуки, Кисловодск). Ремонт может проводиться как территории заказчика, так и в нашем сервисном центре. Мы всегда рады оперативно оказать Вам профессиональную компьютерную помощь, обращайтесь!" },
                            HasPicture = false,
                            IsGlobalTitle = false,
                            IsList = false,
                            IsMobileVisible = true,
                            IsSubtitle = false,
                            PageId = 1
                        },
                        new
                        {
                            ParagraphId = 3,
                            Content = new[] { "_NeedHelpAndPicturePartial" },
                            HasPicture = false,
                            IsGlobalTitle = false,
                            IsList = false,
                            IsMobileVisible = false,
                            IsSubtitle = false,
                            PageId = 1
                        },
                        new
                        {
                            ParagraphId = 4,
                            Content = new[] { "Вызов компьютерного мастера на дом" },
                            HasPicture = false,
                            IsGlobalTitle = false,
                            IsList = false,
                            IsMobileVisible = true,
                            IsSubtitle = true,
                            PageId = 1
                        },
                        new
                        {
                            ParagraphId = 5,
                            Content = new[] { "Высококвалифицированные специалисты компании «Нова Компьютерс» имеют большой опыт в ремонте и обслуживании любых моделей компьютеров, ноутбуков, роутеров и других видов цифровой и вычислительной техники.", "Для определения неполадок компьютера или ноутбука нашему специалисту необходимо провести начальную диагностику Вашего оборудования, с целью составления сметы на ремонт.", "Наши мастера делают только те работы, которые необходимы; <b>мы никогда не занимаемся навязыванием дополнительных, зачастую ненужных, услуг.</b>" },
                            HasPicture = false,
                            IsGlobalTitle = false,
                            IsList = false,
                            IsMobileVisible = true,
                            IsSubtitle = false,
                            PageId = 1
                        },
                        new
                        {
                            ParagraphId = 6,
                            Content = new[] { "Как вызвать компьютерного мастера на дом или в офис?" },
                            HasPicture = false,
                            IsGlobalTitle = false,
                            IsList = false,
                            IsMobileVisible = true,
                            IsSubtitle = true,
                            PageId = 1
                        },
                        new
                        {
                            ParagraphId = 7,
                            Content = new[] { "Позвоните нам или оставьте заявку на сайте в соответствующей форме;", "Опишите Вашу проблему;", "Согласуйте время приезда компьютерного мастера." },
                            HasPicture = false,
                            IsGlobalTitle = false,
                            IsList = true,
                            IsMobileVisible = true,
                            IsSubtitle = false,
                            PageId = 1
                        },
                        new
                        {
                            ParagraphId = 8,
                            Content = new[] { "Оказываем услуги по ремонту в городах Кавказских Минеральных Вод (Минеральные Воды, Пятигорск, Ессентуки, Кисловодск) и в прилегающих населенных пунктах." },
                            HasPicture = false,
                            IsGlobalTitle = false,
                            IsList = false,
                            IsMobileVisible = true,
                            IsSubtitle = false,
                            PageId = 1
                        },
                        new
                        {
                            ParagraphId = 9,
                            Content = new[] { "Как скоро приедет мастер? Сколько будут стоить услуги по ремонту?" },
                            HasPicture = false,
                            IsGlobalTitle = false,
                            IsList = false,
                            IsMobileVisible = true,
                            IsSubtitle = true,
                            PageId = 1
                        },
                        new
                        {
                            ParagraphId = 10,
                            Content = new[] { "Мастер приедет в заранее согласованное с Вами время;", "Перед началом работ по настройке или ремонту компьютера, ноутбука или офисной техники специалисту необходимо будет провести диагностику;", "Подробные цены на ремонт и компьютерные услуги компании «Нова Компьютерс» Вы можете узнать в разделе \"Цены\"." },
                            HasPicture = false,
                            IsGlobalTitle = false,
                            IsList = true,
                            IsMobileVisible = true,
                            IsSubtitle = false,
                            PageId = 1
                        },
                        new
                        {
                            ParagraphId = 11,
                            Content = new[] { "Ремонт компьютеров на дому или в офисе" },
                            HasPicture = false,
                            IsGlobalTitle = false,
                            IsList = false,
                            IsMobileVisible = true,
                            IsSubtitle = true,
                            PageId = 1
                        },
                        new
                        {
                            ParagraphId = 12,
                            Content = new[] { "Мы готовы помочь Вам с ремонтом компьютерной техники. Специалисты нашей компании выполняют профессиональный ремонт компьютеров любых производителей недорого и в минимально возможные сроки." },
                            HasPicture = true,
                            IsGlobalTitle = false,
                            IsList = false,
                            IsMobileVisible = true,
                            IsSubtitle = false,
                            PageId = 1,
                            PicturePath = "~/Resources/Images/remont-komputerov.jpg"
                        },
                        new
                        {
                            ParagraphId = 13,
                            Content = new[] { "Каков порядок ремонта компьютерной техники? Где будут выполняться работы?" },
                            HasPicture = false,
                            IsGlobalTitle = false,
                            IsList = false,
                            IsMobileVisible = true,
                            IsSubtitle = true,
                            PageId = 1
                        },
                        new
                        {
                            ParagraphId = 14,
                            Content = new[] { "Ремонт стационарных компьютеров может выполняться как у Вас на дому или в офисе, так и у нас в сервисном центре;", "Может потребоваться специальное оборудование или дополнительные запчасти. В этом случае наш специалист при Вашем желании может доставить компьютер в сервисный центр, провести работы по ремонту, а затем привезти обратно к Вам." },
                            HasPicture = false,
                            IsGlobalTitle = false,
                            IsList = true,
                            IsMobileVisible = true,
                            IsSubtitle = false,
                            PageId = 1
                        },
                        new
                        {
                            ParagraphId = 15,
                            Content = new[] { "Компьютерная помощь срочно и без проблем!" },
                            HasPicture = false,
                            IsGlobalTitle = false,
                            IsList = false,
                            IsMobileVisible = true,
                            IsSubtitle = true,
                            PageId = 1
                        },
                        new
                        {
                            ParagraphId = 16,
                            Content = new[] { "Компания «Нова Компьютерс» всегда рада оказать Вам срочную компьютерную помощь! Мы выполним любые Ваши пожелания по ремонту и настройке компьютера, ноутбука, роутера, МФУ, принтера. Так же поможем установить Windows или иную операционную систему, скачать и установить любые программы и утилиты." },
                            HasPicture = true,
                            IsGlobalTitle = false,
                            IsList = false,
                            IsMobileVisible = true,
                            IsSubtitle = false,
                            PageId = 1,
                            PicturePath = "~/Resources/Images/komputernaya-pomosh.png"
                        },
                        new
                        {
                            ParagraphId = 17,
                            Content = new[] { "Какие услуги компьютерной помощи мы можем оказать?" },
                            HasPicture = false,
                            IsGlobalTitle = false,
                            IsList = false,
                            IsMobileVisible = true,
                            IsSubtitle = true,
                            PageId = 1
                        },
                        new
                        {
                            ParagraphId = 18,
                            Content = new[] { "В число компьютерных услуг входит так же помощь по установке антивирусов, драйверов, обучение пользователей работе на компьютере и прочее;", "Учтем все Ваши пожелания, обращайтесь! Мы поможем!" },
                            HasPicture = false,
                            IsGlobalTitle = false,
                            IsList = true,
                            IsMobileVisible = true,
                            IsSubtitle = false,
                            PageId = 1
                        });
                });

            modelBuilder.Entity("CompanyProjectContentService.Models.TopMenu.TopMenuEntity", b =>
                {
                    b.Property<Guid>("TopMenuEntityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("AspAction")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("AspController")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("FirstLine")
                        .HasColumnType("boolean");

                    b.Property<string>("Icon")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("IconColor")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("NavBar")
                        .HasColumnType("boolean");

                    b.Property<bool>("NeedStar")
                        .HasColumnType("boolean");

                    b.Property<string>("ScreenName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("TopMenuEntityId");

                    b.ToTable("TopMenuEntities");

                    b.HasData(
                        new
                        {
                            TopMenuEntityId = new Guid("f1f5dc6d-1a43-4539-93e6-225e91ea5510"),
                            AspAction = "Comments",
                            AspController = "MenuFirstLine",
                            FirstLine = true,
                            Icon = "fas fa-star",
                            IconColor = "orange",
                            NavBar = false,
                            NeedStar = true,
                            ScreenName = "Отзывы"
                        },
                        new
                        {
                            TopMenuEntityId = new Guid("1fa80a66-7dfa-424a-bdd5-5723b2e1e062"),
                            AspAction = "FullPriceList",
                            AspController = "MenuFirstLine",
                            FirstLine = true,
                            Icon = "fas fa-ruble-sign",
                            IconColor = "gray",
                            NavBar = false,
                            NeedStar = false,
                            ScreenName = "Цены"
                        },
                        new
                        {
                            TopMenuEntityId = new Guid("e8a047eb-ff30-4f51-8da3-23a7d12a998f"),
                            AspAction = "About",
                            AspController = "MenuFirstLine",
                            FirstLine = true,
                            Icon = "fas fa-info",
                            IconColor = "gray",
                            NavBar = false,
                            NeedStar = false,
                            ScreenName = "О Компании"
                        },
                        new
                        {
                            TopMenuEntityId = new Guid("cdab1277-d33c-47cd-b10e-f7cc106c147b"),
                            AspAction = "Contacts",
                            AspController = "MenuFirstLine",
                            FirstLine = true,
                            Icon = "fas fa-map-marker-alt",
                            IconColor = "gray",
                            NavBar = false,
                            NeedStar = false,
                            ScreenName = "Контакты"
                        },
                        new
                        {
                            TopMenuEntityId = new Guid("c45e0efd-7d7c-45a2-88ed-6660eac6701c"),
                            AspAction = "ComputersRepair",
                            AspController = "Home",
                            FirstLine = false,
                            Icon = "fas fa-wrench",
                            IconColor = "black",
                            NavBar = true,
                            NeedStar = false,
                            ScreenName = "Ремонт компьютеров"
                        },
                        new
                        {
                            TopMenuEntityId = new Guid("d8b1ed10-0253-4096-b5d2-3fd7c1b06838"),
                            AspAction = "LaptopsRepair",
                            AspController = "Home",
                            FirstLine = false,
                            Icon = "fas fa-laptop-medical",
                            IconColor = "black",
                            NavBar = true,
                            NeedStar = false,
                            ScreenName = "Ремонт ноутбуков"
                        },
                        new
                        {
                            TopMenuEntityId = new Guid("88d06219-997d-4f20-9930-629626c9ce8d"),
                            AspAction = "HelpDesk",
                            AspController = "Home",
                            FirstLine = false,
                            Icon = "fas fa-ambulance",
                            IconColor = "black",
                            NavBar = true,
                            NeedStar = false,
                            ScreenName = "Компьютерная помощь"
                        },
                        new
                        {
                            TopMenuEntityId = new Guid("61f30d4b-556c-40e7-89c4-3954726e84dd"),
                            AspAction = "InternetNetworks",
                            AspController = "Home",
                            FirstLine = false,
                            Icon = "fas fa-network-wired",
                            IconColor = "black",
                            NavBar = true,
                            NeedStar = false,
                            ScreenName = "Интернет и сети"
                        },
                        new
                        {
                            TopMenuEntityId = new Guid("2abdd9c1-9103-45e5-9b88-c7a13d9cfefe"),
                            AspAction = "DataRecovery",
                            AspController = "Home",
                            FirstLine = false,
                            Icon = "fas fa-database",
                            IconColor = "black",
                            NavBar = false,
                            NeedStar = false,
                            ScreenName = "Восстановление данных"
                        },
                        new
                        {
                            TopMenuEntityId = new Guid("44c744b5-6358-4077-8401-d74ff4c6ee13"),
                            AspAction = "B2b",
                            AspController = "Home",
                            FirstLine = false,
                            Icon = "fas fa-industry",
                            IconColor = "black",
                            NavBar = true,
                            NeedStar = false,
                            ScreenName = "ИТ-услуги для бизнеса"
                        },
                        new
                        {
                            TopMenuEntityId = new Guid("5b8ac044-b28f-4931-90d3-63637e2c89a8"),
                            AspAction = "LaptopUpgrade",
                            AspController = "Home",
                            FirstLine = false,
                            Icon = "fas fa-laptop",
                            IconColor = "black",
                            NavBar = false,
                            NeedStar = false,
                            ScreenName = "LaptopUpgrade"
                        },
                        new
                        {
                            TopMenuEntityId = new Guid("499b2a3c-ab84-4411-b689-9a52f799410a"),
                            AspAction = "PcAssembly",
                            AspController = "Home",
                            FirstLine = false,
                            Icon = "fas fa-tv",
                            IconColor = "black",
                            NavBar = false,
                            NeedStar = false,
                            ScreenName = "Сборка компьютера"
                        },
                        new
                        {
                            TopMenuEntityId = new Guid("3dae453f-30c7-4cce-8324-9a977f4dd335"),
                            AspAction = "OfficeEquipment",
                            AspController = "Home",
                            FirstLine = false,
                            Icon = "fas fa-print",
                            IconColor = "black",
                            NavBar = true,
                            NeedStar = false,
                            ScreenName = "Oргтехника"
                        });
                });

            modelBuilder.Entity("CompanyProjectContentService.Models.Paragraph.Paragraph", b =>
                {
                    b.HasOne("CompanyProjectContentService.Models.Page.Page", "Page")
                        .WithMany("Paragraphs")
                        .HasForeignKey("PageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Page");
                });

            modelBuilder.Entity("CompanyProjectContentService.Models.Page.Page", b =>
                {
                    b.Navigation("Paragraphs");
                });
#pragma warning restore 612, 618
        }
    }
}
