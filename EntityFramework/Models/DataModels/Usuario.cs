using EntityFramework.DataAccess;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EntityFramework.Models.DataModels
{
    public class Usuario 
    {
        [Key]
        [Required]
        public int UsuarioId { get; set; }
        [Required]
        public string Nombre { get; set; } = string.Empty;
        public ICollection<LibroUsuario> Libros { get; set; }
        [ForeignKey("Libro")]
        public int? LibroRefId { get; set; }
       
    }
}
