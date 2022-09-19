using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFramework.Models.DataModels
{
    public class LibroUsuario
    {
        [ForeignKey("Libro")]
        [Required]
        public int LibroId { get; set; } = 0;
        public Libro Libros { get; set; }
        [ForeignKey("Usuario")]
        [Required]
        public int UsuarioId { get; set; } = 0;
        public Usuario Usuarios { get; set; }

        /*
         * CREAR PARA PODER BUSCAR EN LIBROUSUARIO LOS LIBROS
         * Y LOS USUARIOS LEIDOS DESDE LA DB
         * AL BUSCAR TDOSO LOS USUARIOS, LO HARE EN ETSA TABLA LIBROUSUARIO
         * USUARIOCONTROLLER
         * VAR LU = FROM LUIN IN .CONTEXT.LIBROUSUARIO
         * O ALGO POR EL ESTILO
         * 
         */
    }
}
