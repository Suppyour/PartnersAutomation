using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class ProductsUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductImageEntity_Products_ProductEntityId",
                table: "ProductImageEntity");

            migrationBuilder.DropIndex(
                name: "IX_ProductImageEntity_ProductEntityId",
                table: "ProductImageEntity");

            migrationBuilder.DropColumn(
                name: "IsMain",
                table: "ProductImageEntity");

            migrationBuilder.DropColumn(
                name: "ProductEntityId",
                table: "ProductImageEntity");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImageEntity_ProductId",
                table: "ProductImageEntity",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductImageEntity_Products_ProductId",
                table: "ProductImageEntity",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductImageEntity_Products_ProductId",
                table: "ProductImageEntity");

            migrationBuilder.DropIndex(
                name: "IX_ProductImageEntity_ProductId",
                table: "ProductImageEntity");

            migrationBuilder.AddColumn<bool>(
                name: "IsMain",
                table: "ProductImageEntity",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "ProductEntityId",
                table: "ProductImageEntity",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductImageEntity_ProductEntityId",
                table: "ProductImageEntity",
                column: "ProductEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductImageEntity_Products_ProductEntityId",
                table: "ProductImageEntity",
                column: "ProductEntityId",
                principalTable: "Products",
                principalColumn: "Id");
        }
    }
}
