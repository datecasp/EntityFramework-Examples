using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityFramework.Migrations
{
    public partial class ResetDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LibroUsuarios");

            migrationBuilder.AddColumn<int>(
                name: "LibroId",
                table: "Usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Libros",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.InsertData(
                table: "Libros",
                columns: new[] { "Id", "Autor", "Titulo", "UsuarioId" },
                values: new object[,]
                {
                    { -6, "aut6", "tit6", -3 },
                    { -5, "aut5", "tit5", -3 },
                    { -4, "aut4", "tit4", -3 },
                    { -3, "aut3", "tit3", -2 },
                    { -2, "aut2", "tit2", -1 },
                    { -1, "aut1", "tit1", -1 }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "LibroId", "Nombre" },
                values: new object[,]
                {
                    { -3, 0, "Usu3" },
                    { -2, 0, "Usu2" },
                    { -1, 0, "Usu1" }
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

            migrationBuilder.DeleteData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: -6);

            migrationBuilder.DeleteData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: -5);

            migrationBuilder.DeleteData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: -4);

            migrationBuilder.DeleteData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: -1);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: -1);

            migrationBuilder.DropColumn(
                name: "LibroId",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Libros");

            migrationBuilder.CreateTable(
                name: "LibroUsuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LibroUsuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LibroUsuarios_Libros_Id",
                        column: x => x.Id,
                        principalTable: "Libros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LibroUsuarios_Usuarios_Id",
                        column: x => x.Id,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }
    }
}
