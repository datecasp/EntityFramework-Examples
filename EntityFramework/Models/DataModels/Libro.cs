using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFramework.Models.DataModels
{
    public class Libro
    {
        [Key]
        [Required]
        public int LibroId { get; set; }
        [Required]
        public string Titulo { get; set; } = string.Empty;
        [Required]
        public string Autor { get; set; } = string.Empty;
        public ICollection<LibroUsuario> Usuarios { get; set; }
        public int? UsuarioRefId { get; set; }
       
    }
}
