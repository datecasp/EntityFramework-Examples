using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityFramework.Migrations
{
    public partial class ntom : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Libros_Usuarios_UsuarioId",
                table: "Libros");

            migrationBuilder.DropIndex(
                name: "IX_Libros_UsuarioId",
                table: "Libros");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Libros");

            migrationBuilder.CreateTable(
                name: "LibroUsuario",
                columns: table => new
                {
                    LibrosId = table.Column<int>(type: "int", nullable: false),
                    UsuariosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LibroUsuario", x => new { x.LibrosId, x.UsuariosId });
                    table.ForeignKey(
                        name: "FK_LibroUsuario_Libros_LibrosId",
                        column: x => x.LibrosId,
                        principalTable: "Libros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LibroUsuario_Usuarios_UsuariosId",
                        column: x => x.UsuariosId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LibroUsuario_UsuariosId",
                table: "LibroUsuario",
                column: "UsuariosId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LibroUsuario");

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Libros",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Libros_UsuarioId",
                table: "Libros",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Libros_Usuarios_UsuarioId",
                table: "Libros",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id");
        }
    }
}
