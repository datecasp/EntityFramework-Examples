using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFramework.Models.DataModels
{
    public class LibrosBasicos
    {
        [ForeignKey("Libro")]
        [Required]
        public int LibroId { get; set; } = 0;
        
        [ForeignKey("Usuario")]
        [Required]
        public int UsuarioId { get; set; } = 0;
       
        public string tituloLibro { get; set; }
        public string autorLibro { get; set; }
    }
}
