using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class MigratonMapbd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    RegionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegionName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Climate = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.RegionID);
                });

            migrationBuilder.CreateTable(
                name: "Img",
                columns: table => new
                {
                    ImageID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegionID = table.Column<int>(type: "int", nullable: false),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Img", x => x.ImageID);
                    table.ForeignKey(
                        name: "FK_Img_Regions",
                        column: x => x.RegionID,
                        principalTable: "Regions",
                        principalColumn: "RegionID");
                });

            migrationBuilder.CreateTable(
                name: "﻿﻿kingdoms",
                columns: table => new
                {
                    KingdomID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    kingdomName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RegionID = table.Column<int>(type: "int", nullable: false),
                    GovernmentID = table.Column<int>(type: "int", nullable: false),
                    Language = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Trading = table.Column<string>(type: "nvarchar(270)", maxLength: 270, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_﻿﻿kingdoms", x => x.KingdomID);
                    table.ForeignKey(
                        name: "FK_﻿﻿kingdoms_Regions",
                        column: x => x.RegionID,
                        principalTable: "Regions",
                        principalColumn: "RegionID");
                });

            migrationBuilder.CreateTable(
                name: "Landscapes",
                columns: table => new
                {
                    LandscapeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LandscapeType = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    RegionID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Landscapes", x => x.LandscapeID);
                    table.ForeignKey(
                        name: "FK_Landscapes_Regions",
                        column: x => x.RegionID,
                        principalTable: "Regions",
                        principalColumn: "RegionID");
                });

            migrationBuilder.CreateTable(
                name: "NeighRegions",
                columns: table => new
                {
                    RegionID = table.Column<int>(type: "int", nullable: false),
                    RegionID1 = table.Column<int>(type: "int", nullable: false),
                    RegionID2 = table.Column<int>(type: "int", nullable: false),
                    RegionID3 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NeighRegions", x => x.RegionID);
                    table.ForeignKey(
                        name: "FK_NeighRegions_Regions1",
                        column: x => x.RegionID1,
                        principalTable: "Regions",
                        principalColumn: "RegionID");
                });

            migrationBuilder.CreateTable(
                name: "Temperatures",
                columns: table => new
                {
                    TemperatureID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegionID = table.Column<int>(type: "int", nullable: false),
                    Season = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    AverageTemperature = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Temperatures", x => x.TemperatureID);
                    table.ForeignKey(
                        name: "FK_Temperatures_Regions",
                        column: x => x.RegionID,
                        principalTable: "Regions",
                        principalColumn: "RegionID");
                });

            migrationBuilder.CreateTable(
                name: "Governments",
                columns: table => new
                {
                    GovernmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KingdomID = table.Column<int>(type: "int", nullable: false),
                    LeaderName = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Governments", x => x.GovernmentID);
                    table.ForeignKey(
                        name: "FK_Governments_﻿﻿kingdoms",
                        column: x => x.KingdomID,
                        principalTable: "﻿﻿kingdoms",
                        principalColumn: "KingdomID");
                });

            migrationBuilder.CreateTable(
                name: "Inhabitants",
                columns: table => new
                {
                    InhabitantID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KingdomID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Population = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inhabitants", x => x.InhabitantID);
                    table.ForeignKey(
                        name: "FK_Inhabitants_﻿﻿kingdoms",
                        column: x => x.KingdomID,
                        principalTable: "﻿﻿kingdoms",
                        principalColumn: "KingdomID");
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    LanguageID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LanguageName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    KingdomID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.LanguageID);
                    table.ForeignKey(
                        name: "FK_Languages_﻿﻿kingdoms",
                        column: x => x.KingdomID,
                        principalTable: "﻿﻿kingdoms",
                        principalColumn: "KingdomID");
                });

            migrationBuilder.CreateTable(
                name: "Settlements",
                columns: table => new
                {
                    SettlementID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SettlementName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    KingdomID = table.Column<int>(type: "int", nullable: false),
                    Population = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settlements", x => x.SettlementID);
                    table.ForeignKey(
                        name: "FK_Settlements_﻿﻿kingdoms",
                        column: x => x.KingdomID,
                        principalTable: "﻿﻿kingdoms",
                        principalColumn: "KingdomID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Governments_KingdomID",
                table: "Governments",
                column: "KingdomID");

            migrationBuilder.CreateIndex(
                name: "IX_Img_RegionID",
                table: "Img",
                column: "RegionID");

            migrationBuilder.CreateIndex(
                name: "IX_Inhabitants_KingdomID",
                table: "Inhabitants",
                column: "KingdomID");

            migrationBuilder.CreateIndex(
                name: "IX_﻿﻿kingdoms_RegionID",
                table: "﻿﻿kingdoms",
                column: "RegionID");

            migrationBuilder.CreateIndex(
                name: "IX_Landscapes_RegionID",
                table: "Landscapes",
                column: "RegionID");

            migrationBuilder.CreateIndex(
                name: "IX_Languages_KingdomID",
                table: "Languages",
                column: "KingdomID");

            migrationBuilder.CreateIndex(
                name: "IX_NeighRegions_RegionID1",
                table: "NeighRegions",
                column: "RegionID1");

            migrationBuilder.CreateIndex(
                name: "IX_Settlements_KingdomID",
                table: "Settlements",
                column: "KingdomID");

            migrationBuilder.CreateIndex(
                name: "IX_Temperatures_RegionID",
                table: "Temperatures",
                column: "RegionID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Governments");

            migrationBuilder.DropTable(
                name: "Img");

            migrationBuilder.DropTable(
                name: "Inhabitants");

            migrationBuilder.DropTable(
                name: "Landscapes");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "NeighRegions");

            migrationBuilder.DropTable(
                name: "Settlements");

            migrationBuilder.DropTable(
                name: "Temperatures");

            migrationBuilder.DropTable(
                name: "﻿﻿kingdoms");

            migrationBuilder.DropTable(
                name: "Regions");
        }
    }
}
