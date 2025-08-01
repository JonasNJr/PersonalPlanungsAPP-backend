using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonalPlanungsAPP.Migrations
{
    /// <inheritdoc />
    public partial class AddAbteilungAndBereichsnummer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Bereichsnummer",
                table: "Mitarbeiter",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "KostenstelleInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kostenstelle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Abteilung = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bereich = table.Column<int>(type: "int", nullable: false),
                    Bereichsnummer = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KostenstelleInfos", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KostenstelleInfos");

            migrationBuilder.AlterColumn<string>(
                name: "Bereichsnummer",
                table: "Mitarbeiter",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
