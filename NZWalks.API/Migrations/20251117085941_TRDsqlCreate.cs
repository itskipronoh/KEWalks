using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZWalks.API.Migrations
{
    /// <inheritdoc />
    public partial class TRDsqlCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Walks",
                columns: new[] { "Id", "Description", "DifficultyId", "LengthInKm", "Name", "RegionId", "WalkImageUrl" },
                values: new object[,]
                {
                    { new Guid("48e0242a-084f-4f75-b577-b7eca30a1b1a"), "A challenging walk around the lake.", new Guid("1cff7579-3a13-4fba-8d9c-1e22c9e57db1"), 10.0, "Lakeside Loop", new Guid("0bb8403e-c4a6-410c-b2b1-117762a25b0d"), null },
                    { new Guid("62e0c8ff-fba9-4059-9cbb-9a1e586cd13b"), "A beautiful walk to enjoy the sunset views.", new Guid("5420d83f-e63e-4981-b768-d67935b9c7e1"), 5.5, "Sunset Trail", new Guid("7503ec2d-3354-4c65-bfdc-b9727caf7dd5"), null },
                    { new Guid("8d9ccf12-bcf2-4abe-9789-8ffe72636fcd"), "A refreshing walk along the coast.", new Guid("494667ce-47b6-4544-9c8a-0fa7e4db7ff1"), 8.1999999999999993, "Coastal Breeze", new Guid("94dbd6b3-31f2-48ed-b7e9-02f5e74a660d"), null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Walks",
                keyColumn: "Id",
                keyValue: new Guid("48e0242a-084f-4f75-b577-b7eca30a1b1a"));

            migrationBuilder.DeleteData(
                table: "Walks",
                keyColumn: "Id",
                keyValue: new Guid("62e0c8ff-fba9-4059-9cbb-9a1e586cd13b"));

            migrationBuilder.DeleteData(
                table: "Walks",
                keyColumn: "Id",
                keyValue: new Guid("8d9ccf12-bcf2-4abe-9789-8ffe72636fcd"));
        }
    }
}
