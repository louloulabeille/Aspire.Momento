using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Memento.Gpx.Infrastructures.MementoMigrations
{
    /// <inheritdoc />
    public partial class InitCreationMemento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Gpx",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Version = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Creator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Extensions = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gpx", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Link",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Link", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LinkTypeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Person_Link_LinkTypeId",
                        column: x => x.LinkTypeId,
                        principalTable: "Link",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MetaData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Desc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuthorId = table.Column<int>(type: "int", nullable: true),
                    Copyright = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Keywords = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Extensions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GpxTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetaData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MetaData_Gpx_GpxTypeId",
                        column: x => x.GpxTypeId,
                        principalTable: "Gpx",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MetaData_Person_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Person",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Bounds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Minlat = table.Column<float>(type: "real", nullable: false),
                    Minlon = table.Column<float>(type: "real", nullable: false),
                    Maxlat = table.Column<float>(type: "real", nullable: false),
                    Maxlon = table.Column<float>(type: "real", nullable: false),
                    GpxMetadataTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bounds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bounds_MetaData_GpxMetadataTypeId",
                        column: x => x.GpxMetadataTypeId,
                        principalTable: "MetaData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GpxMetadataTypeLinkType",
                columns: table => new
                {
                    GpxMetadataTypesId = table.Column<int>(type: "int", nullable: false),
                    LinkTypesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GpxMetadataTypeLinkType", x => new { x.GpxMetadataTypesId, x.LinkTypesId });
                    table.ForeignKey(
                        name: "FK_GpxMetadataTypeLinkType_Link_LinkTypesId",
                        column: x => x.LinkTypesId,
                        principalTable: "Link",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GpxMetadataTypeLinkType_MetaData_GpxMetadataTypesId",
                        column: x => x.GpxMetadataTypesId,
                        principalTable: "MetaData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bounds_GpxMetadataTypeId",
                table: "Bounds",
                column: "GpxMetadataTypeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GpxMetadataTypeLinkType_LinkTypesId",
                table: "GpxMetadataTypeLinkType",
                column: "LinkTypesId");

            migrationBuilder.CreateIndex(
                name: "IX_MetaData_AuthorId",
                table: "MetaData",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_MetaData_GpxTypeId",
                table: "MetaData",
                column: "GpxTypeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Person_LinkTypeId",
                table: "Person",
                column: "LinkTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bounds");

            migrationBuilder.DropTable(
                name: "GpxMetadataTypeLinkType");

            migrationBuilder.DropTable(
                name: "MetaData");

            migrationBuilder.DropTable(
                name: "Gpx");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "Link");
        }
    }
}
