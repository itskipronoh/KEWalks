using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZWalks.API.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("1cff7579-3a13-4fba-8d9c-1e22c9e57db1"), "Hard" },
                    { new Guid("494667ce-47b6-4544-9c8a-0fa7e4db7ff1"), "Medium" },
                    { new Guid("5420d83f-e63e-4981-b768-d67935b9c7e1"), "Easy" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("0bb8403e-c4a6-410c-b2b1-117762a25b0d"), "KIS", "Kisumu", "https://example.com/images/kisumu.jpg" },
                    { new Guid("557fb860-ba91-46e2-b821-84433398319f"), "ELD", "Eldoret", "https://example.com/images/eldoret.jpg" },
                    { new Guid("5a46ef1b-f149-4be4-b627-0c5832128326"), "NKU", "Nakuru", "https://example.com/images/nakuru.jpg" },
                    { new Guid("7503ec2d-3354-4c65-bfdc-b9727caf7dd5"), "NRB", "Nairobi", "https://example.com/images/nairobi.jpg" },
                    { new Guid("94dbd6b3-31f2-48ed-b7e9-02f5e74a660d"), "MBA", "Mombasa", "https://example.com/images/mombasa.jpg" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("1cff7579-3a13-4fba-8d9c-1e22c9e57db1"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("494667ce-47b6-4544-9c8a-0fa7e4db7ff1"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("5420d83f-e63e-4981-b768-d67935b9c7e1"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("0bb8403e-c4a6-410c-b2b1-117762a25b0d"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("557fb860-ba91-46e2-b821-84433398319f"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("5a46ef1b-f149-4be4-b627-0c5832128326"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("7503ec2d-3354-4c65-bfdc-b9727caf7dd5"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("94dbd6b3-31f2-48ed-b7e9-02f5e74a660d"));
        }
    }
}
