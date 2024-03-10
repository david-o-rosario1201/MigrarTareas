using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MigrarTareas.Api.Migrations
{
    /// <inheritdoc />
    public partial class ClientesConDetalles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Celular",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "Telefono",
                table: "Clientes");

            migrationBuilder.CreateTable(
                name: "ClientesDetalleCelulares",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClienteId = table.Column<int>(type: "INTEGER", nullable: false),
                    Celular = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientesDetalleCelulares", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientesDetalleCelulares_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClientesDetalleTelefonos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClienteId = table.Column<int>(type: "INTEGER", nullable: false),
                    Telefono = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientesDetalleTelefonos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientesDetalleTelefonos_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClientesDetalleCelulares_ClienteId",
                table: "ClientesDetalleCelulares",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientesDetalleTelefonos_ClienteId",
                table: "ClientesDetalleTelefonos",
                column: "ClienteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientesDetalleCelulares");

            migrationBuilder.DropTable(
                name: "ClientesDetalleTelefonos");

            migrationBuilder.AddColumn<string>(
                name: "Celular",
                table: "Clientes",
                type: "TEXT",
                maxLength: 11,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Telefono",
                table: "Clientes",
                type: "TEXT",
                maxLength: 10,
                nullable: false,
                defaultValue: "");
        }
    }
}
