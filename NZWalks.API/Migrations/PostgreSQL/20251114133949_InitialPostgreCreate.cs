using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZWalks.API.Migrations.PostgreSQL
{
    /// <inheritdoc />
    public partial class InitialPostgreCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Difficulties",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Difficulties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: false),
                    RegionImageUrl = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Walks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    LengthInKm = table.Column<double>(type: "double precision", nullable: false),
                    WalkImageUrl = table.Column<string>(type: "text", nullable: true),
                    RegionId = table.Column<Guid>(type: "uuid", nullable: false),
                    DifficultyId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Walks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Walks_Difficulties_DifficultyId",
                        column: x => x.DifficultyId,
                        principalTable: "Difficulties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Walks_Regions_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Regions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.InsertData(
                table: "Walks",
                columns: new[] { "Id", "Description", "DifficultyId", "LengthInKm", "Name", "RegionId", "WalkImageUrl" },
                values: new object[,]
                {
                    { new Guid("48e0242a-084f-4f75-b577-b7eca30a1b1a"), "A challenging walk around the lake.", new Guid("1cff7579-3a13-4fba-8d9c-1e22c9e57db1"), 10.0, "Lakeside Loop", new Guid("0bb8403e-c4a6-410c-b2b1-117762a25b0d"), null },
                    { new Guid("62e0c8ff-fba9-4059-9cbb-9a1e586cd13b"), "A beautiful walk to enjoy the sunset views.", new Guid("5420d83f-e63e-4981-b768-d67935b9c7e1"), 5.5, "Sunset Trail", new Guid("7503ec2d-3354-4c65-bfdc-b9727caf7dd5"), null },
                    { new Guid("8d9ccf12-bcf2-4abe-9789-8ffe72636fcd"), "A refreshing walk along the coast.", new Guid("494667ce-47b6-4544-9c8a-0fa7e4db7ff1"), 8.1999999999999993, "Coastal Breeze", new Guid("94dbd6b3-31f2-48ed-b7e9-02f5e74a660d"), null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Walks_DifficultyId",
                table: "Walks",
                column: "DifficultyId");

            migrationBuilder.CreateIndex(
                name: "IX_Walks_RegionId",
                table: "Walks",
                column: "RegionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Walks");

            migrationBuilder.DropTable(
                name: "Difficulties");

            migrationBuilder.DropTable(
                name: "Regions");
        }
    }
}
