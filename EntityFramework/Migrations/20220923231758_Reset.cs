using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityFramework.Migrations
{
    public partial class Reset : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Libros_Usuarios_UsuarioId",
                table: "Libros");

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioId",
                table: "Libros",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Nombre" },
                values: new object[] { -3, "Usu3" });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Nombre" },
                values: new object[] { -2, "Usu2" });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Nombre" },
                values: new object[] { -1, "Usu1" });

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

            migrationBuilder.AddForeignKey(
                name: "FK_Libros_Usuarios_UsuarioId",
                table: "Libros",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Libros_Usuarios_UsuarioId",
                table: "Libros");

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

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioId",
                table: "Libros",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Libros_Usuarios_UsuarioId",
                table: "Libros",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id");
        }
    }
}
