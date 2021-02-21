using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PaymentGateway.Core.Migrations
{
    public partial class Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                table: "ProcessPayment",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ModifiedBy",
                table: "ProcessPayment",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "ProcessPayment",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                table: "PaymentState",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ModifiedBy",
                table: "PaymentState",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "PaymentState",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "ProcessPayment");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "ProcessPayment");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "ProcessPayment");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "PaymentState");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "PaymentState");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "PaymentState");
        }
    }
}
