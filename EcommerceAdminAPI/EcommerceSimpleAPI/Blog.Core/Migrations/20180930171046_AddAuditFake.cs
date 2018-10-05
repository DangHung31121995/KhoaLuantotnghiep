using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ecommerce.Core.Migrations
{
    public partial class AddAuditFake : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Audits",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateOn = table.Column<DateTime>(nullable: false),
                    CreateBy = table.Column<Guid>(nullable: false),
                    DeleteOn = table.Column<DateTime>(nullable: true),
                    DeleteBy = table.Column<Guid>(nullable: true),
                    ChangeOn = table.Column<DateTime>(nullable: true),
                    ChangeBy = table.Column<Guid>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    Level = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Audits", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Audits");
        }
    }
}
