using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Customers.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    ContactName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ContactTitle = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    City = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Region = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    PostalCold = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(24)", maxLength: 24, nullable: false),
                    Fax = table.Column<string>(type: "nvarchar(24)", maxLength: 24, nullable: false),
                    SystemCreationTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
