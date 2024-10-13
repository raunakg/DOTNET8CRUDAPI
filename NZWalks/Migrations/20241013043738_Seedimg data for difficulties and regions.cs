using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZWalks.Migrations
{
    /// <inheritdoc />
    public partial class Seedimgdatafordifficultiesandregions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("f5b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3b"), "Easy" },
                    { new Guid("f5b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3c"), "Moderate" },
                    { new Guid("f5b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3d"), "Hard" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("f5b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b30"), "W", "Waikato", "waikato.jpg" },
                    { new Guid("f5b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b31"), "B", "Bay of Plenty", "bayofplenty.jpg" },
                    { new Guid("f5b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b32"), "T", "Taranaki", "taranaki.jpg" },
                    { new Guid("f5b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3e"), "N", "Northland", "northland.jpg" },
                    { new Guid("f5b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3f"), "A", "Auckland", "auckland.jpg" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("f5b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3b"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("f5b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3c"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("f5b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3d"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("f5b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b30"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("f5b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b31"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("f5b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b32"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("f5b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3e"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("f5b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3f"));
        }
    }
}
