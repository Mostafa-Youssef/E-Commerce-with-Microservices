using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ordering.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddInitialMigrationWithOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DeliveryMethods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShortName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliveryTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryMethods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DeliveryMethodId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressFirstName = table.Column<string>(name: "Address_FirstName", type: "nvarchar(max)", nullable: true),
                    AddressLastName = table.Column<string>(name: "Address_LastName", type: "nvarchar(max)", nullable: true),
                    AddressEmailAddress = table.Column<string>(name: "Address_EmailAddress", type: "nvarchar(max)", nullable: true),
                    AddressAddressLine = table.Column<string>(name: "Address_AddressLine", type: "nvarchar(max)", nullable: true),
                    AddressCountry = table.Column<string>(name: "Address_Country", type: "nvarchar(max)", nullable: true),
                    AddressState = table.Column<string>(name: "Address_State", type: "nvarchar(max)", nullable: true),
                    AddressZipCode = table.Column<string>(name: "Address_ZipCode", type: "nvarchar(max)", nullable: true),
                    PaymentCardName = table.Column<string>(name: "Payment_CardName", type: "nvarchar(max)", nullable: true),
                    PaymentCardNumber = table.Column<string>(name: "Payment_CardNumber", type: "nvarchar(max)", nullable: true),
                    PaymentExpiration = table.Column<string>(name: "Payment_Expiration", type: "nvarchar(max)", nullable: true),
                    PaymentCVV = table.Column<string>(name: "Payment_CVV", type: "nvarchar(max)", nullable: true),
                    PaymentPaymentMethod = table.Column<int>(name: "Payment_PaymentMethod", type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_orders_DeliveryMethods_DeliveryMethodId",
                        column: x => x.DeliveryMethodId,
                        principalTable: "DeliveryMethods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_orders_DeliveryMethodId",
                table: "orders",
                column: "DeliveryMethodId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "orders");

            migrationBuilder.DropTable(
                name: "DeliveryMethods");
        }
    }
}
