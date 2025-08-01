using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonalPlanungsAPP.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kapazitaetsabweichungen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MitarbeiterId = table.Column<int>(type: "int", nullable: false),
                    Startdatum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Enddatum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NeueKapazitaet = table.Column<double>(type: "float", nullable: false),
                    Bemerkung = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kapazitaetsabweichungen", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mitarbeiter",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Vorname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Eintrittsdatum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Befristung = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Verlaengerung1 = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Verlaengerung2 = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BefristungMax = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Freistellung = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Kuendigung = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Austritt = table.Column<int>(type: "int", nullable: false),
                    Bemerkung = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Funktion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Kostenstelle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Abteilung = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bereichsnummer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fte = table.Column<double>(type: "float", nullable: false),
                    Bereich = table.Column<int>(type: "int", nullable: false),
                    Mengenabhaengigkeit = table.Column<int>(type: "int", nullable: false),
                    Arbeitsverhaeltnis = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mitarbeiter", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Kapazitaetsabweichungen");

            migrationBuilder.DropTable(
                name: "Mitarbeiter");
        }
    }
}
