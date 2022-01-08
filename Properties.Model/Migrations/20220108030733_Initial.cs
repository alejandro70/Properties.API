using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Properties.Model.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Owner",
                columns: table => new
                {
                    OwnerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owner", x => x.OwnerId);
                });

            migrationBuilder.CreateTable(
                name: "Property",
                columns: table => new
                {
                    PropertyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    CodeInternal = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    OwnerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Property", x => x.PropertyId);
                    table.ForeignKey(
                        name: "FK_Property_Owner_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Owner",
                        principalColumn: "OwnerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PropertyImage",
                columns: table => new
                {
                    PropertyImageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PropertyId = table.Column<int>(type: "int", nullable: false),
                    File = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Enabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyImage", x => x.PropertyImageId);
                    table.ForeignKey(
                        name: "FK_PropertyImage_Property_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "Property",
                        principalColumn: "PropertyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PropertyTrace",
                columns: table => new
                {
                    PropertyTraceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PropertyId = table.Column<int>(type: "int", nullable: false),
                    DateSale = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Value = table.Column<double>(type: "float", nullable: false),
                    Tax = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyTrace", x => x.PropertyTraceId);
                    table.ForeignKey(
                        name: "FK_PropertyTrace_Property_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "Property",
                        principalColumn: "PropertyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Owner",
                columns: new[] { "OwnerId", "Address", "Name" },
                values: new object[] { 1, "2000 Ponce de Leon Blvd #513, Coral Gables, FL 33134", "www.millionandup.com" });

            migrationBuilder.InsertData(
                table: "Property",
                columns: new[] { "PropertyId", "Address", "CodeInternal", "Name", "OwnerId", "Price", "Year" },
                values: new object[] { 1, "1451 BRICKELL-AVE #PH01,MIAMI,FL 33131", "A11108153", "BRICKELL-AVE #PH01", 1, 39500000.0, 2017 });

            migrationBuilder.InsertData(
                table: "Property",
                columns: new[] { "PropertyId", "Address", "CodeInternal", "Name", "OwnerId", "Price", "Year" },
                values: new object[] { 2, "3315 COLLINS AVE #PH-A,MIAMI BEACH,FL 33140", "A11016058", "COLLINS AVE #PH-A", 1, 34950000.0, 2015 });

            migrationBuilder.InsertData(
                table: "PropertyImage",
                columns: new[] { "PropertyImageId", "Enabled", "File", "PropertyId" },
                values: new object[] { 1, true, "https://millionandupprod.blob.core.windows.net/mls/resize/363144808_1-352X336.jpg", 1 });

            migrationBuilder.InsertData(
                table: "PropertyImage",
                columns: new[] { "PropertyImageId", "Enabled", "File", "PropertyId" },
                values: new object[] { 2, true, "https://millionandupprod.blob.core.windows.net/mls/resize/356973807_1-352X336.jpg", 2 });

            migrationBuilder.CreateIndex(
                name: "IX_Property_OwnerId",
                table: "Property",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyImage_PropertyId",
                table: "PropertyImage",
                column: "PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyTrace_PropertyId",
                table: "PropertyTrace",
                column: "PropertyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PropertyImage");

            migrationBuilder.DropTable(
                name: "PropertyTrace");

            migrationBuilder.DropTable(
                name: "Property");

            migrationBuilder.DropTable(
                name: "Owner");
        }
    }
}
