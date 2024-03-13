using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DDDExample.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialDemoCuentasDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    ClienteID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dni = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApellidoPaterno = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApellidoMaterno = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombres = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.ClienteID);
                });

            migrationBuilder.CreateTable(
                name: "TiposCuenta",
                columns: table => new
                {
                    TipoCuentaID = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposCuenta", x => x.TipoCuentaID);
                });

            migrationBuilder.CreateTable(
                name: "Cuentas",
                columns: table => new
                {
                    CuentaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteID = table.Column<int>(type: "int", nullable: false),
                    SaldoDisponible = table.Column<decimal>(type: "decimal(16,4)", precision: 16, scale: 4, nullable: false),
                    SaldoContable = table.Column<decimal>(type: "decimal(16,4)", precision: 16, scale: 4, nullable: false),
                    NumeroCuenta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoCuentaId = table.Column<int>(type: "int", nullable: false),
                    CuentaType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cuentas", x => x.CuentaID);
                    table.ForeignKey(
                        name: "FK_Cuentas_Clientes_ClienteID",
                        column: x => x.ClienteID,
                        principalTable: "Clientes",
                        principalColumn: "ClienteID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cuentas_TiposCuenta_TipoCuentaId",
                        column: x => x.TipoCuentaId,
                        principalTable: "TiposCuenta",
                        principalColumn: "TipoCuentaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cuentas_ClienteID",
                table: "Cuentas",
                column: "ClienteID");

            migrationBuilder.CreateIndex(
                name: "IX_Cuentas_TipoCuentaId",
                table: "Cuentas",
                column: "TipoCuentaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cuentas");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "TiposCuenta");
        }
    }
}
