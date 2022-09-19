using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityFramework.Migrations
{
    public partial class initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Libros_LibroId",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_LibroId",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "LibroId",
                table: "Usuarios");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LibroId",
                table: "Usuarios",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_LibroId",
                table: "Usuarios",
                column: "LibroId");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Libros_LibroId",
                table: "Usuarios",
                column: "LibroId",
                principalTable: "Libros",
                principalColumn: "LibroId");
        }
    }
}
