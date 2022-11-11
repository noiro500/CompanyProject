using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompanyProjectMessage.Migrations
{
    /// <inheritdoc />
    public partial class InitialMessage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    MessageId = table.Column<Guid>(type: "uuid", nullable: false),
                    PeopleName = table.Column<string>(type: "text", nullable: false),
                    WhatsAppTelegramNumber = table.Column<string>(type: "text", nullable: false),
                    MessageNumber = table.Column<decimal>(type: "numeric(20,0)", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: true),
                    SubjectMessage = table.Column<string>(type: "text", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false),
                    IsAnswered = table.Column<bool>(type: "boolean", nullable: false),
                    IsAdoptedPrivacyPolicy = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.MessageId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Messages");
        }
    }
}
