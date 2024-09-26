using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Memento.Gpx.Infrastructures.MementoMigrations
{
    /// <inheritdoc />
    public partial class AjoutWayPoint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WayPoint",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Lat = table.Column<float>(type: "real", nullable: false),
                    Lon = table.Column<float>(type: "real", nullable: false),
                    Ele = table.Column<float>(type: "real", nullable: true),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Magvar = table.Column<float>(type: "real", nullable: true),
                    Geoidheight = table.Column<float>(type: "real", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cmt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Desc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Src = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sym = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fix = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sat = table.Column<byte>(type: "tinyint", nullable: true),
                    Hdop = table.Column<float>(type: "real", nullable: true),
                    Vdop = table.Column<float>(type: "real", nullable: true),
                    Pdop = table.Column<float>(type: "real", nullable: true),
                    Ageofgpsdata = table.Column<float>(type: "real", nullable: true),
                    Dgpsid = table.Column<int>(type: "int", nullable: true),
                    Extensions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GpxTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WayPoint", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WayPoint_Gpx_GpxTypeId",
                        column: x => x.GpxTypeId,
                        principalTable: "Gpx",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GpxWptTypeLinkType",
                columns: table => new
                {
                    GpxWptTypesId = table.Column<int>(type: "int", nullable: false),
                    LinkTypesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GpxWptTypeLinkType", x => new { x.GpxWptTypesId, x.LinkTypesId });
                    table.ForeignKey(
                        name: "FK_GpxWptTypeLinkType_Link_LinkTypesId",
                        column: x => x.LinkTypesId,
                        principalTable: "Link",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GpxWptTypeLinkType_WayPoint_GpxWptTypesId",
                        column: x => x.GpxWptTypesId,
                        principalTable: "WayPoint",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GpxWptTypeLinkType_LinkTypesId",
                table: "GpxWptTypeLinkType",
                column: "LinkTypesId");

            migrationBuilder.CreateIndex(
                name: "IX_WayPoint_GpxTypeId",
                table: "WayPoint",
                column: "GpxTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GpxWptTypeLinkType");

            migrationBuilder.DropTable(
                name: "WayPoint");
        }
    }
}
