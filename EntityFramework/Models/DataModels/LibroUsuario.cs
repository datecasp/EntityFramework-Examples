using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace EntityFramework.Models.DataModels
{
    public class LibroUsuario
    {
        [Required]
        public int LibroId { get; set; } = 0;
        [Required]
        public int UsuarioId { get; set; } = 0;
    }
}
